using EntityFrameworkCore.EncryptColumn.Util;
using Hris.Api.Settings;

namespace Hris.Api.Security
{
    public class HrisEncryptionProvider : GenerateEncryptionProvider
    {
        public HrisEncryptionProvider() :base(ApplicationSettings.SecurityConfig.EncryptionKey)
        {
           
        }
    }
}
