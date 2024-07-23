using Hris.Business.Config;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Hris.Business.Service.Common
{
    public class StorageCloudService
    {
        private readonly CloudBlobContainer _container;

        public StorageCloudService(CloudBlobContainer container)
        {
            _container = container;
        }

        private string GetPath(int req, Guid id)
        {
            switch (req)
            {
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return this.GetReference(req, id);
                default:
                    return string.Empty;
            }
        }

        private string GetReference(int req, Guid id)
        {
            var basePath = "employees";
            switch (req)
            {
                case 3:
                    return $"department/{id}/template";
                case 4:
                    return $"leave-application/{id}";
                case 5:
                    return $"employee/{id}/profile";
                case 6:
                    return $"{basePath}/{id}/201-files";
                case 7:
                    return $"task/{id}";
                case 8:
                    return $"employee/{id}/avatar";
                case 9:
                    return $"{basePath}/{id}/201-files/coe";
                case 10:
                    return $"payroll/config/template/{id}";
                default:
                    return string.Empty;
            }
        }

        public async Task UploadAttachment(int req, IFormFile file, Guid id, string? uri = null)
        {
            try
            {
                var path = this.GetPath(req, id);
                var filePath = uri != null && !string.IsNullOrEmpty(uri) ? $"{uri}/{file.FileName}" : $"{path}/{file.FileName}";
                await RemoveFile(path);
                using (var fileStream = file.OpenReadStream())
                using (var memStream = new MemoryStream())
                    await (_container.GetBlockBlobReference(filePath))
                        .UploadFromStreamAsync(fileStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task RemoveFile(string path)
        {
            try
            {
                var list = await (_container.GetDirectoryReference(path)).ListBlobsSegmentedAsync(null);
                var cloudBlobList = list.Results.Select(blb => blb as ICloudBlob);
                foreach (var item in cloudBlobList)
                {
                    if (item == null)
                        continue;
                    var result = await item!.DeleteIfExistsAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<bool> Remove(int req, Guid id, string fileName)
        {
            try
            {
                var list = await (_container.GetDirectoryReference(GetReference(req, id))).ListBlobsSegmentedAsync(null);
                var cloudBlobList = list.Results.Select(blb => blb as ICloudBlob);
                foreach (var item in cloudBlobList)
                {
                    if (item == null || !item.Name.Contains(fileName))
                        continue;
                    var result = await item!.DeleteIfExistsAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task RemoveFileOrFolder(int req, Guid id, string? uri, string fileUri, bool isFile)
        {
            try
            {
                var list = await (_container.GetDirectoryReference(isFile ? uri != null ? uri : GetReference(req, id) : fileUri)).ListBlobsSegmentedAsync(null);
                if (isFile)
                {
                    var cloudBlobList = list.Results.Select(blb => blb as ICloudBlob);
                    foreach (var item in cloudBlobList)
                    {
                        if (item == null || !item.Name.Equals(fileUri))
                            continue;
                        var result = await item!.DeleteIfExistsAsync();
                    }
                }
                else
                    await RemoveFolderContents(fileUri);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        private async Task RemoveFolderContents(string uri)
        {
            try
            {
                var list = await (_container.GetDirectoryReference(uri)).ListBlobsSegmentedAsync(null);
                foreach (var item in list.Results)
                {
                    if (item == null)
                        return;
                    var type = item.GetType();
                    if (type == typeof(CloudBlockBlob))
                        await (item as ICloudBlob).DeleteIfExistsAsync();
                    else if (type == typeof(CloudBlobDirectory))
                        await RemoveFolderContents((item as CloudBlobDirectory).Prefix.Trim('/'));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string?> GetAttachmentUri(int req, Guid id)
        {
            try
            {
                var uri = string.Empty;
                var avatarContainer = _container.GetDirectoryReference(GetReference(req, id));
                var results = new List<IListBlobItem>();
                var response = await avatarContainer.ListBlobsSegmentedAsync(null);
                if (response != null)
                {
                    results.AddRange(response.Results);
                    uri = results.Select(e => e.Uri.ToString()).FirstOrDefault();
                }
                return uri;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<string>?> GoToFolder(Guid id, string? uri = null)
        {
            var response = await (_container.GetDirectoryReference(uri ?? GetReference(6, id))).ListBlobsSegmentedAsync(null);
            if (response == null)
                return null;
            return response.Results.Where(e => !e.Uri.ToString()
                .Contains(".tmp"))
                .Select(e => e.Uri.ToString().Substring((_container.Uri.ToString()).Length).Trim('/'))
                .ToList();
        }

        public async Task<bool> AddFolder(Guid id, string folderName, string? uri)
        {
            try
            {
                var path = $"{uri ?? GetReference(6, id)}/{folderName}/.tmp";
                await (_container.GetBlockBlobReference(path)).UploadTextAsync(path);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /* OLD */
        public async Task UploadDepartmentTemplate(IFormFile file, Guid departmentId)
        {
            try
            {
                await DeleteTemplate(departmentId);
                using (var fileStream = file.OpenReadStream())
                {
                    var blockBlob = _container.GetBlockBlobReference($"department/{departmentId}/template/template.xlsx");
                    using (var memStream = new MemoryStream())
                    {
                        await blockBlob.UploadFromStreamAsync(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteTemplate(Guid departmentId)
        {
            try
            {
                var avatarContainer = _container.GetDirectoryReference($"department/{departmentId}/template/template.xlsx");

                var avatarList = await avatarContainer.ListBlobsSegmentedAsync(null);
                var cloudBlobList = avatarList.Results.Select(blb => blb as ICloudBlob);
                foreach (var item in cloudBlobList)
                {
                    var result = await item!.DeleteIfExistsAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> GetDepartmentTemplateUri(Guid departmentId)
        {
            var uri = string.Empty;
            var config = new TemplateConfig();


            string fileReference = config.GetReference(departmentId);

            var avatarContainer = _container.GetDirectoryReference(fileReference);

            var results = new List<IListBlobItem>();

            var response = await avatarContainer.ListBlobsSegmentedAsync(null);
            if (response != null)
            {
                results.AddRange(response.Results);
                uri = results.Select(e => e.Uri.ToString()).FirstOrDefault();
            }

            return uri;
        }

        public async Task UploadEmployeeAvatar(IFormFile file, Guid employeeId)
        {
            try
            {
                await DeleteAvatar(employeeId);
                using (var image = new MagickImage(file.OpenReadStream()))
                {
                    var format = image.Format;

                    var parameters = new ImageConfig().AvatarConfig(employeeId.ToString(), format.ToString());


                    foreach (var parameter in parameters)
                    {
                        image.Quality = 90;
                        image.Strip();

                        if (image.Height > image.Width)
                        {
                            image.Crop(image.Width, image.Width, Gravity.Center);
                        }
                        else
                        {
                            image.Crop(image.Height, image.Height, Gravity.Center);
                        }

                        image.Resize(parameter.Width, parameter.Height);

                        var blockBlob = _container.GetBlockBlobReference(parameter.FileReference + parameter.Suffix);


                        using (var memStream = new MemoryStream())
                        {
                            var readSettings = new MagickReadSettings() { Format = format };

                            image.Write(memStream, format);
                            memStream.Position = 0;

                            await blockBlob.UploadFromStreamAsync(memStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task DeleteAvatar(Guid employeeId)
        {

            try
            {
                var avatarContainer = _container.GetDirectoryReference(string.Format("employee/{0}/avatar", employeeId));
                var avatarList = await avatarContainer.ListBlobsSegmentedAsync(null);
                var cloudBlobList = avatarList.Results.Select(blb => blb as ICloudBlob);

                foreach (var item in cloudBlobList)
                {
                    var result = await item!.DeleteIfExistsAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<string>> GetEmployeeAvatarUri(Guid employeeId)
        {
            List<string> avatarUri = new List<string>();
            var imageConfig = new ImageConfig();


            string fileReference = imageConfig.GetAvatarReference(employeeId.ToString());

            var avatarContainer = _container.GetDirectoryReference(fileReference);


            var results = new List<IListBlobItem>();

            var response = await avatarContainer.ListBlobsSegmentedAsync(null);
            if (response != null)
            {
                results.AddRange(response.Results);

                avatarUri = results.Select(e => e.Uri.ToString()).ToList();
            }

            return avatarUri;
        }

        public async Task UploadTaskFiles(IFormFileCollection files, Guid taskId)
        {
            try
            {
                foreach (var file in files)
                {
                    //await DeleteTemplate(departmentId);
                    using (var fileStream = file.OpenReadStream())
                    {
                        var blockBlob = _container.GetBlockBlobReference($"task/{taskId}/{file.FileName}");
                        using (var memStream = new MemoryStream())
                        {
                            await blockBlob.UploadFromStreamAsync(fileStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> GetTaskFilesUri(Guid taskId)
        {
            var uri = string.Empty;
            var config = new TaskFileConfig();

            string fileReference = config.GetReference(taskId);

            var container = _container.GetDirectoryReference(fileReference);

            var results = new List<IListBlobItem>();

            var response = await container.ListBlobsSegmentedAsync(null);
            if (response != null)
            {
                results.AddRange(response.Results);
                uri = string.Join(',', results.Select(e => e.Uri.ToString()));
            }


            return uri;
        }
    }
}
