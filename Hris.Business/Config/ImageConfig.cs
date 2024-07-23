using Hris.Data.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Config
{
    public class ImageConfig
    {

        public ImageConfig() {

        }

        public string GetAvatarReference(string employeeId)
        {
            return $"employee/{employeeId}/avatar";
        }
        public IEnumerable<ImageParameters> AvatarConfig(string employeeId,string fileExtension="jpg")
        {
            string _fileReference = GetAvatarReference(employeeId) + "/avatar";

            fileExtension = fileExtension.Replace(".","").ToLower();

            return new List<ImageParameters>
            {
                new ImageParameters
                {
                    FileReference = _fileReference,
                    Height = 600,
                    Width = 600,
                    Suffix = $"_lg.{fileExtension}"
                },
                 new ImageParameters
                {
                    FileReference = _fileReference,
                    Height = 300,
                    Width = 300,
                    Suffix =  $"_md.{fileExtension}"
                },
                new ImageParameters
                {
                    FileReference = _fileReference,
                    Height = 150,
                    Width = 150,
                    Suffix = $"_sm.{fileExtension}"
                }
               

            };
        }
    }

    public class ImageParameters
    {
        public string FileReference { get; set; }
        public string Suffix { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }

}
