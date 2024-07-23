using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Request.Clock;
using Hris.Business.Service.Clock;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service;
using Hris.Business.Service.v1.ClockModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hris.Api.Models.Response.ClockModule;
using Hris.Business.Service.v1.Report;
using Hris.Api.Utilities;
using Hris.Api.Controllers.v1.PayrollModule;

namespace Hris.Api.Controllers.v1.ClockModule
{
    public class ReportsController : BaseApiController<ReportsController>
    {
        private readonly ITrackServices _trackServices;
        private readonly IEmployeesService _employeeServices;
        private readonly IUserSettingsServices _userSettingsServices;
        private readonly IReportServices _reportServices;
        private readonly ICustomClaimPrincipal _custom;

        public ReportsController(ITrackServices trackServices, IEmployeesService employeesService,
            IUserSettingsServices userSettingsServices,
            IReportServices reportServices,
            ICustomClaimPrincipal custom,
            ILogger<ReportsController> logger) : base(logger)
        {
            _employeeServices = employeesService;
            _trackServices = trackServices;
            _userSettingsServices = userSettingsServices;
            _reportServices = reportServices;
            _custom = custom;
        }

        [HrisAuthorize]
        [HttpGet]
        public async Task<IActionResult> GetReportMeta([FromQuery] ReportDataFilter request)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var settings = _userSettingsServices.GetByCondition(f => f.EmployeeId.Equals(employee.Id)).Result.FirstOrDefault();

            if (settings == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Settings {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var resultData = await _trackServices.GetReportMeta(request, await _custom.GetUserObjectId(User));
            return HrisOk(resultData);
        }

        [HrisAuthorize]
        [HttpPost]
        public async Task<IActionResult> GetReport([FromBody] ReportDtoRequest request)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var settings = _userSettingsServices.GetByCondition(f => f.EmployeeId.Equals(employee.Id)).Result.FirstOrDefault();

            if (settings == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"User Settings {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var resultData = await _trackServices.GetReports(request, await _custom.GetUserObjectId(User));
            return HrisOk(resultData);
        }

        [HrisAuthorize]
        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateReport([FromBody] ReportsRequest request)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var settings = (await _userSettingsServices.GetByCondition(s => s.EmployeeId == employee.Id)).FirstOrDefault();

            if (settings == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"User Settings {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var data = await _trackServices.GetReports(request.Start, request.End, request.EmployeeIds, request.ClientIds, request.ProjectIds, request.TaskIds);
            if (data is null) return HrisError(Resource.Responses.Common.ERROR, "Error in generating report.");

            return HrisOk(data.ToGenerateReportResponse_(settings));
        }

        [HrisAuthorize]
        [HttpGet("generate/employee/payslip")]
        public async Task<IActionResult> GenerateEmployeePayslip([FromQuery] Guid employeeId, [FromQuery] Guid payrollRunId)
        {
            var result = await _reportServices.GenerateEmployeePayslip(employeeId, payrollRunId);
            return HrisOk(result);
        }
    }
}
