using Hris.Data.DTO;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IEmployeeStatutoriesServices
    {
        //Task<EmployeeStatutoriesDtoResponse?> GetByEmployeeId(Guid employeeId);
        //Task<EmployeeStatutoriesDtoResponse?> GetById(Guid Id);
        //Task<EmployeeStatutoriesDtoResponse?> Add(EmployeeStatutoriesDtoRequest req, Guid objId);
        //Task<EmployeeStatutoriesDtoResponse?> Update(EmployeeStatutoriesDtoRequest req, Guid objId);
        //Task<EmployeeStatutoriesDtoResponse?> UpdateByEmployeeId(EmployeeStatutoriesDtoRequest req, Guid objId);
        //Task<bool> Delete(Guid Id, Guid objId);
        //Task<bool> DeleteByEmployeeId(Guid employeeId, Guid objId);

    }
    internal class EmployeeStatutoriesServices : IEmployeeStatutoriesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeStatutoriesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<EmployeeStatutoriesDtoResponse?> Add(EmployeeStatutoriesDtoRequest req, Guid objId)
        //{
        //    try
        //    {
        //        var result = await _unitOfWork._EmployeeStatutories.AddAsync(new Data.Models.Payroll.EmployeeStatutories
        //        {
        //            EmployeeId = req.EmployeeId,
        //            SSSER = req.SSSER,
        //            SSSEE = req.SSSEE,
        //            SSSEC = req.SSSEC,
        //            PHICER = req.PHICER,
        //            PHICEE = req.PHICEE,
        //            HDMFER = req.HDMFER,
        //            HDMFEE = req.HDMFEE,
        //            TaxTableId = req.TaxTableId,
        //            Active = true
        //        });

        //        return await _unitOfWork.SaveChangeAsync(objId) > 0
        //            ? result.ToEmployeeStatutoriesResponse() : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public async Task<bool> Delete(Guid Id, Guid objId)
        //{
        //    try
        //    {
        //        var result = await _unitOfWork._EmployeeStatutories.GetDbSet()
        //            .FirstOrDefaultAsync(f => f.Id.Equals(Id));

        //        await _unitOfWork._EmployeeStatutories.DeleteAsync(result);
        //        return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public async Task<bool> DeleteByEmployeeId(Guid employeeId, Guid objId)
        //{
        //    try
        //    {
        //        var result = await _unitOfWork._EmployeeStatutories.GetDbSet()
        //                .FirstOrDefaultAsync(f => f.EmployeeId.Equals(employeeId));

        //        await _unitOfWork._EmployeeStatutories.DeleteAsync(result);
        //        return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public async Task<EmployeeStatutoriesDtoResponse?> GetByEmployeeId(Guid employeeId)
        //{
        //    var result = await _unitOfWork._EmployeeStatutories.GetDbSet()
        //        .Include(f => f.TaxTable)
        //        .FirstOrDefaultAsync(f => f.EmployeeId.Equals(employeeId));
        //    return result != null ? result.ToEmployeeStatutoriesResponse() : null;
        //}

        //public async Task<EmployeeStatutoriesDtoResponse?> GetById(Guid Id)
        //{
        //    var result = await _unitOfWork._EmployeeStatutories.GetDbSet()
        //        .FirstOrDefaultAsync(f => f.Id.Equals(Id));
        //    return result != null ? result.ToEmployeeStatutoriesResponse() : null;
        //}

        //public async Task<EmployeeStatutoriesDtoResponse?> Update(EmployeeStatutoriesDtoRequest req, Guid objId)
        //{
        //    try
        //    {
        //        var result = await _unitOfWork._EmployeeStatutories.GetByIdAsync(req.Id);
        //        if (result is null) return null;

        //        result.EmployeeId = req.EmployeeId;
        //        result.SSSER = req.SSSER;
        //        result.SSSEE = req.SSSEE;
        //        result.SSSEC = req.SSSEC;
        //        result.PHICER = req.PHICER;
        //        result.PHICEE = req.PHICEE;
        //        result.HDMFER = req.HDMFER;
        //        result.HDMFEE = req.HDMFEE;
        //        result.TaxTableId = req.TaxTableId;

        //        await _unitOfWork._EmployeeStatutories.UpdateAsync(result);
        //        return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToEmployeeStatutoriesResponse() : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public async Task<EmployeeStatutoriesDtoResponse?> UpdateByEmployeeId(EmployeeStatutoriesDtoRequest req, Guid objId)
        //{
        //    try
        //    {
        //        var result = await _unitOfWork._EmployeeStatutories.GetDbSet()
        //            .AsNoTracking()
        //           .FirstOrDefaultAsync(f => f.EmployeeId.Equals(req.EmployeeId));

        //        if (result is null) return null;

        //        result.EmployeeId = req.EmployeeId;
        //        result.SSSER = req.SSSER;
        //        result.SSSEE = req.SSSEE;
        //        result.SSSEC = req.SSSEC;
        //        result.PHICER = req.PHICER;
        //        result.PHICEE = req.PHICEE;
        //        result.HDMFER = req.HDMFER;
        //        result.HDMFEE = req.HDMFEE;
        //        result.TaxTableId = req.TaxTableId;

        //        await _unitOfWork._EmployeeStatutories.UpdateAsync(result);
        //        return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToEmployeeStatutoriesResponse() : null;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
    }
}
