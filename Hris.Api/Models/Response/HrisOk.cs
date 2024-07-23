using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Models.Response
{
    public class HrisOk : JsonResult
    {
        public HrisOk() : base(new ApiResponse())
        {

        }

        public HrisOk(object objt): base(new ApiResponse(objt)){
            
        }
    }
}
