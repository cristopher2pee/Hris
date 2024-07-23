using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;

namespace Hris.Api.Extensions.Common
{
    public static class FormExtension
    {
        public static T AsObject<T>(this IFormCollection pairs) where T : class, new()
            => JsonConvert.DeserializeObject<T>($"{{{string.Join(",", pairs.Select(x => $"\"{x.Key}\" : \"{x.Value}\""))}}}");
    }
}
