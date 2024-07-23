using Azure.Core;
using Azure.Identity;
using Hris.Business.Config;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Me.SendMail;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Hris.Business.Service.GraphApi
{
    public class AzureAdService
    {
        private readonly IOptions<AzureAdConfig> _azureAdConfig;
        private readonly IConfiguration _configuration;
        private GraphServiceClient? _graphServiceClient;
        public bool IsServiceRunning { get; private set; } = false;

        public AzureAdService(IOptions<AzureAdConfig> azureAdConfig, IConfiguration configuration)
        {
            this._azureAdConfig = azureAdConfig;
            this._configuration = configuration;
        }


        public bool StartService()
        {
            try
            {
                string secretKey = _configuration["AZURE_CLIENT_SECRET"]??"";

                var options = new ClientSecretCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
                };

                var clientSecretCredential = new ClientSecretCredential(_azureAdConfig?.Value.TenantId, _azureAdConfig?.Value.ClientId, secretKey, options);

                var scopes = new[] { "https://graph.microsoft.com/.default" };

                _graphServiceClient = new GraphServiceClient(clientSecretCredential, scopes);

                this.IsServiceRunning = true;
            }
            catch (Exception)
            {
                throw;
            }

            return this.IsServiceRunning;
        }


        public async Task<bool> IsEmailValidAsync(string email)
        {
            if(this.IsServiceRunning && _graphServiceClient != null)
            {
                var users = await _graphServiceClient.Users.GetAsync();

                var userEmails = users?.Value?.Where(e => e.Mail?.ToUpper() == email.Trim().ToUpper()).FirstOrDefault();

                if(userEmails != null)
                {
                    return true;
                }
                else
                {
                    var principalName = users?.Value?.Where(e=>e.UserPrincipalName?.ToUpper()==email.Trim().ToUpper()).FirstOrDefault();

                    if(principalName != null)
                    {
                        return true;
                    }
                }
            }
            else
            {

                throw new Exception("Email already exist in Azure Active Directory");

            }
            return false;
        }
    
    
        public async Task<bool> CreateUserAd(Employee employee)
        {

            var isEmailValid = await IsEmailValidAsync(employee.Email);
            
            if(isEmailValid)
            {

                var requestBody = new User
                {
                    AccountEnabled = true,
                    DisplayName = $"{employee.Firstname} {employee.Lastname}",
                    GivenName = employee.Firstname,
                    
                    UserPrincipalName = employee.Email,
                    PasswordProfile = new PasswordProfile
                    {
                        ForceChangePasswordNextSignIn = true,
                        Password = "G3m5ng0!2008",
                    },
                };

                var result = await _graphServiceClient!.Users.PostAsync(requestBody);
            }
            return false;
        }
    

        public async Task<Invitation> InviteUser(string email)
        {
            if (this.IsServiceRunning)
            {
                try 
                {

                    InvitedUserMessageInfo info = new InvitedUserMessageInfo();
                    info.AdditionalData.Add("Data1", "Testing Additional Data");
                    info.AdditionalData.Add("Data2", "Testing Another Additional Data");

                    var invitation = new Invitation
                    {
                        InvitedUserEmailAddress = email,
                        InviteRedirectUrl = "https://employease.azurewebsites.net/landing",
                        InvitedUserMessageInfo = info,
                        SendInvitationMessage = true
                    };

                    var post = await _graphServiceClient!.Invitations.PostAsync(invitation);

                    return invitation;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                
            }
            else
            {
                throw new Exception("Graph Service Client service is not running");
            }

            return null;

        }

    }
}
