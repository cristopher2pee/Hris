
using Hris.Business.Helper;
using Hris.Data.Models;
using Hris.Data.UnitOfWork;
using System.Security.Cryptography;

namespace Hris.Business.Service.v1
{
    public interface IAuthInviteService
    {
        Task<AuthenticationInvite> GetById(Guid id);
        Task<AuthenticationInvite> GetByEmail(string email);
        Task<AuthenticationInvite> Invite(string email, Guid objId);
        Task<AuthenticationInvite> Renew(Guid id, Guid objId);
        Task<bool> Verify(string email);
        Task<AuthenticationInvite> Delete (AuthenticationInvite d, Guid objId);
    }

    internal class AuthInviteService : IAuthInviteService
    {
        private readonly IAuthenticationInviteRepository _authInvite;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenHelper _jwtHelper;

        public AuthInviteService(IUnitOfWork unitOfWork, IJwtTokenHelper jwtHelper) {
            _authInvite = unitOfWork._AuthenticationInvite;
            this._unitOfWork = unitOfWork;
            _jwtHelper = jwtHelper;
        }

        public async Task<AuthenticationInvite> GetById(Guid id)
            => await this._authInvite.GetByIdAsync(id);

        public async Task<AuthenticationInvite> GetByEmail(string email)
            => await this._authInvite.FindByConditionAsync(d => d.Email.ToLower().Equals(email.ToLower()));

        public async Task<AuthenticationInvite> Invite(string email, Guid objId)
        {
            try
            {
                var existing = await GetByEmail(email);
                if (existing != null)
                {
                    if (existing.Expiration > DateTime.UtcNow)
                        throw new Exception(Resource.Responses.Common.AUTH_INVITE_EXIST);
                    else
                        return await Renew(existing.Id, objId);
                }

                var invite = await _authInvite.AddAsync(new AuthenticationInvite
                {
                    Email = email,
                    Token = _jwtHelper.GetToken(email),
                    Expiration = DateTime.UtcNow.AddDays(1)
                });
                await _unitOfWork.SaveChangeAsync(objId);
                return invite;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AuthenticationInvite> Renew(Guid id, Guid objId)
        {
            try
            {
                var existing = await GetById(id);

                if (existing == null)
                    throw new NullReferenceException();

                existing.Expiration = DateTime.UtcNow.AddDays(1);
                existing = await _authInvite.UpdateAsync(existing);
                await _unitOfWork.SaveChangeAsync(objId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Verify(string email)
        {
            try
            {
                var existing = await GetByEmail(email);

                if (existing == null)
                    throw new Exception(Resource.Responses.Common.AUTH_INVITE_NOT_FOUND);

                if (existing.Expiration < DateTime.UtcNow)
                    throw new Exception(Resource.Responses.Common.AUTH_INVITE_EXPIRED);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AuthenticationInvite> Delete(AuthenticationInvite d, Guid objId)
        {
            d = await _authInvite.DeleteAsync(d);
            await _unitOfWork.SaveChangeAsync(objId);
            return d;
        }
    }

}
