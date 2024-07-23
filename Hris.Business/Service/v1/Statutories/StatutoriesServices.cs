using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Statutory;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.Statutories
{
    public interface IStatutoriesServices
    {

        //SSS Table
        Task<SSSTableDto.SSS_Response?> AddSSS(SSSTableDto.SSS_Request req, Guid objId);
        Task<SSSTableDto.SSS_Response?> UpdateSSS(SSSTableDto.SSS_Request req, Guid objId);
        Task<bool> DeleteSSS(Guid Id, Guid objId);
        Task<SSSTableDto.SSS_Response> GetSSS(Expression<Func<SSSTable, bool>> express);
        Task<List<SSSTableDto.SSS_Response>> GetListSSSTable(Expression<Func<SSSTable, bool>> express);
        Task<PagedResult_<SSSTableDto.SSS_Response>> GetListPage(BaseFilter_ filter);


        //HDMF Table
        Task<HDMFTableDto.HDMF_Response?> AddHDMF(HDMFTableDto.HDMF_Request req, Guid objId);
        Task<HDMFTableDto.HDMF_Response?> UpdateHDMF(HDMFTableDto.HDMF_Request req, Guid objId);
        Task<bool> DeleteHDMF(Guid id, Guid objId);
        Task<HDMFTableDto.HDMF_Response> GetHDMF(Expression<Func<HDMFTable, bool>> exp);
        Task<List<HDMFTableDto.HDMF_Response>> GetListHDMF(Expression<Func<HDMFTable, bool>> exp);

        //PHIC

        Task<PHICTableDto.PHIC_Response?> AddPHIC(PHICTableDto.PHIC_Request req, Guid obj);
        Task<PHICTableDto.PHIC_Response?> UpdatePHIC(PHICTableDto.PHIC_Request req, Guid obj);
        Task<bool> DeletePHIC(Guid id, Guid objId);
        Task<PHICTableDto.PHIC_Response> GetPHIC(Expression<Func<PHICTable, bool>> exp);
        Task<List<PHICTableDto.PHIC_Response>> GetListPHIC(Expression<Func<PHICTable, bool>> exp);

        Task<StatutoriesTableDto.Calculated_Statutories> ProcessContributionStatutories(decimal basePay);
    }
    internal class StatutoriesServices : IStatutoriesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatutoriesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HDMFTableDto.HDMF_Response?> AddHDMF(HDMFTableDto.HDMF_Request req, Guid objId)
        {
            try
            {
                var toAdd = await _unitOfWork._HDMFTable.AddAsync(new HDMFTable
                {
                    Code = req.Code,
                    RangeFrom = req.RangeFrom,
                    RangeTo = req.RangeTo,
                    HDMFEE = req.HDMFEE,
                    HDMFER = req.HDMFER,
                    HDMFEEMax = req.HDMFEEMax,
                    HDMFERMax = req.HDMFEEMax,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toAdd.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PHICTableDto.PHIC_Response?> AddPHIC(PHICTableDto.PHIC_Request req, Guid obj)
        {
            try
            {
                var toAdd = await _unitOfWork._PHICTable.AddAsync(new PHICTable
                {
                    Code = req.Code,
                    RangeFrom = req.RangeFrom,
                    RangeTo = req.RangeTo,
                    EEShare = req.EEShare,
                    ERShare = req.ERShare,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(obj) > 0 ? toAdd.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<SSSTableDto.SSS_Response?> AddSSS(SSSTableDto.SSS_Request req, Guid objId)
        {
            try
            {
                var toAdd = await _unitOfWork._SSSTable.AddAsync(new Data.Models.Statutory.SSSTable
                {
                    Code = req.Code,
                    RangeFrom = req.RangeFrom,
                    RangeTo = req.RangeTo,
                    EE = req.EE,
                    ER = req.ER,
                    EC = req.EC,
                    Active = true,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toAdd.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteHDMF(Guid id, Guid objId)
        {

            try
            {
                var toDelete = await _unitOfWork._HDMFTable.GetByIdAsync(id);
                if (toDelete is null) return false;

                await _unitOfWork._HDMFTable.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeletePHIC(Guid id, Guid objId)
        {
            try
            {
                var toDelete = await _unitOfWork._PHICTable.GetByIdAsync(id);
                if (toDelete is null) return false;
                await _unitOfWork._PHICTable.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteSSS(Guid Id, Guid objId)
        {
            try
            {
                var toDelete = await _unitOfWork._SSSTable.GetDbSet()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(f => f.Id.Equals(Id));

                if (toDelete is null) return false;
                await _unitOfWork._SSSTable.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<HDMFTableDto.HDMF_Response> GetHDMF(Expression<Func<HDMFTable, bool>> exp)
        {
            var result = await _unitOfWork._HDMFTable.GetDbSet()
                .AsNoTracking()
                .Where(exp)
                .FirstOrDefaultAsync();

            return result.ToResponse();
        }

        public async Task<List<HDMFTableDto.HDMF_Response>> GetListHDMF(Expression<Func<HDMFTable, bool>> exp)
        {
            var result = await _unitOfWork._HDMFTable.GetDbSet()
                .AsNoTracking()
                .Where(exp)
                .ToListAsync();

            return result.ToResponseList().ToList();
        }

        public async Task<PagedResult_<SSSTableDto.SSS_Response>> GetListPage(BaseFilter_ filter)
        {
            var result = await _unitOfWork._SSSTable.GetDbSet()
                 .AsNoTracking()
                 .Where(f => f.Code.Contains(filter.Search))
                 .ToListAsync();

            return result.ToResponseList()
                .ToPagedList_(filter.Page, filter.Limit);

        }

        public async Task<List<PHICTableDto.PHIC_Response>> GetListPHIC(Expression<Func<PHICTable, bool>> exp)
        {
            var result = await _unitOfWork._PHICTable.GetDbSet()
                 .AsNoTracking()
                 .Where(exp)
                 .ToListAsync();

            return result.ToResponseList().ToList();

        }

        public async Task<List<SSSTableDto.SSS_Response>> GetListSSSTable(Expression<Func<SSSTable, bool>> exp)
        {
            var results = await _unitOfWork._SSSTable.GetDbSet()
                .AsNoTracking()
                .Where(exp)
                .ToListAsync();

            return results.ToResponseList().ToList();
        }

        public async Task<PHICTableDto.PHIC_Response> GetPHIC(Expression<Func<PHICTable, bool>> exp)
        {
            var result = await _unitOfWork._PHICTable.GetDbSet()
                .AsNoTracking()
                .FirstOrDefaultAsync(exp);

            return result.ToResponse();

        }

        public async Task<SSSTableDto.SSS_Response> GetSSS(Expression<Func<SSSTable, bool>> express)
        {
            var result = await _unitOfWork._SSSTable.GetDbSet()
                .AsNoTracking()
                .Where(express)
                .FirstOrDefaultAsync();

            return result.ToResponse();
        }

        public async Task<HDMFTableDto.HDMF_Response?> UpdateHDMF(HDMFTableDto.HDMF_Request req, Guid objId)
        {
            try
            {
                var toUpdate = await _unitOfWork._HDMFTable.GetByIdAsync(req.Id);
                if (toUpdate is null) return null;

                toUpdate.Code = req.Code;
                toUpdate.RangeFrom = req.RangeFrom;
                toUpdate.RangeTo = req.RangeTo;
                toUpdate.HDMFEE = req.HDMFEE;
                toUpdate.HDMFER = req.HDMFER;
                toUpdate.HDMFEEMax = req.HDMFEEMax;
                toUpdate.HDMFERMax = req.HDMFEEMax;
                toUpdate.Active = true;

                await _unitOfWork._HDMFTable.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toUpdate.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PHICTableDto.PHIC_Response?> UpdatePHIC(PHICTableDto.PHIC_Request req, Guid obj)
        {
            try
            {
                var toUpdate = await _unitOfWork._PHICTable.GetByIdAsync(req.Id);
                if (toUpdate is null) return null;
                toUpdate.Code = req.Code;
                toUpdate.RangeFrom = req.RangeFrom;
                toUpdate.RangeTo = req.RangeTo;
                toUpdate.EEShare = req.EEShare;
                toUpdate.ERShare = req.ERShare;

                await _unitOfWork._PHICTable.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(obj) > 0 ? toUpdate.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<SSSTableDto.SSS_Response?> UpdateSSS(SSSTableDto.SSS_Request req, Guid objId)
        {
            try
            {
                var toUpdate = await _unitOfWork._SSSTable.GetDbSet()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(f => f.Id.Equals(req.Id));

                if (toUpdate is null) return null;

                toUpdate.Code = req.Code;
                toUpdate.RangeFrom = req.RangeFrom;
                toUpdate.RangeTo = req.RangeTo;
                toUpdate.EE = req.EE;
                toUpdate.ER = req.ER;
                toUpdate.EC = req.EC;

                await _unitOfWork._SSSTable.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toUpdate.ToResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<StatutoriesTableDto.Calculated_Statutories> ProcessContributionStatutories(decimal basePay)
        {
            var result = new StatutoriesTableDto.Calculated_Statutories();
            var phic = await GetPHIC(f => basePay >= f.RangeFrom && basePay <= f.RangeTo);
            var hdmf = await GetHDMF(f => basePay >= f.RangeFrom && basePay <= f.RangeTo);
            var sss = await GetSSS(f => basePay >= f.RangeFrom && basePay <= f.RangeTo);

            if (phic != null)
            {
                result.PHICER = (basePay * phic.EEShare) / 2;
                result.PHICEE = (basePay * phic.EEShare) / 2;
            }

            if (hdmf != null)
            {
                result.HDMFEE = (basePay * hdmf.HDMFEE) / 2;
                if (result.HDMFEE >= hdmf.HDMFEEMax)
                    result.HDMFEE = hdmf.HDMFEEMax;

                result.HDMFER = (basePay * hdmf.HDMFER) / 2;
                if (result.HDMFER >= hdmf.HDMFERMax)
                    result.HDMFER = hdmf.HDMFERMax;
            }

            if (sss != null)
            {
                result.SSSEE = sss.EE / 2;
                result.SSSER = sss.ER / 2;
                result.SSSEC = sss.EC / 2;
            }

            return result;
        }
    }
}
