using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http.Headers;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.ClientAPI
{
    public class ClientAPIRequest:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public ClientRequestBody clientRequestBody;
        #endregion
        public ClientAPIRequest()
        {
            aPIRequestURLs = new APIRequestURLs();
            clientRequestBody = new ClientRequestBody();
        }
        ///<summary>
        /// Create New client
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ClientName"></param>
        /// <returns></returns>
        public ClientTreeResponseBody CreateNewClient(string token)
        {
           
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.createClientRequestBody);
            var requestBody = new CreateClientRequestBody();
            var url = SetUrl(aPIRequestURLs.newClient);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent< ClientTreeResponseBody >(response);
        }
        /// <summary>
        /// Get Clients by User Name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ClientByUsernameResponseBody> getClientByUsername(string token)
        {
            var requestBody = new VehicleTreeBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.vehicletreeBody);
            var url = SetUrl(aPIRequestURLs.getClientsByUserName);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ClientByUsernameResponseBody>>(response);
        }
        public ClientGroupedResponseBody getClientVehicleDriverGrouped(string token)
        {
            var requestBody = new ClientIdRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.clientIdRequestBody);
            var url = SetUrl(aPIRequestURLs.getClientVehiclesAndDriversGrouped);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ClientGroupedResponseBody>(response);
        }
        /// <summary>
        /// Edit Client Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public ClientTreeResponseBody EditClient(string token)
        {
            var requestBody = new CreateClientRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.createclientRequestBody);
            var url = SetUrl(aPIRequestURLs.updateClient);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ClientTreeResponseBody>(response);
        }
        /// <summary>
        /// Suppress alerts by client Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void SuppressAlertsByClientId(string token)
        {
            var requestBody = new SuppressAlertsRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.suppressAlertsRequestBody);
            var url = SetUrl(aPIRequestURLs.updateSignalRAlertNotification);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }

        /// <summary>
        /// Suppress alarms by client Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void SuppressAlarmsByClientId(string token)
        {
            var requestBody = new SuppressAlarmsRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.SuppressAlarmsRequestBody);
            var url = SetUrl(aPIRequestURLs.updateSignalRAlarmNotification);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// UpdateAccountLockoutByClientId
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void UpdateAccountLockoutByClientId(string token)
        {
            var requestBody = new AccountLockedRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.accountLockedRequestBody);
            var url = SetUrl(aPIRequestURLs.updateAccountLockout);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Get Client Details By ID
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClientTreeResponseBody GetClientDetailsByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.clientsID);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ClientTreeResponseBody>(response);
        }
        /// <summary>
        /// Update Password after login
        /// </summary>
        /// <param name="token"></param>
        /// <param name="password"></param>
        public void UpdatePasswordForLoggedinUser(string token)
        {
            var requestBody = new UpdatePasswordRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.updatePasswordRequestBody);
            var url = SetUrl(aPIRequestURLs.updatePassword);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Initial script for new user
        /// </summary>
        /// <param name="token"></param>
        /// <param name="password"></param>
        public void InitialScriptRequest(string token)
        {
            var requestBody = new ClientInitialScriptRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(clientRequestBody.clientInitialScriptRequestBody);
            var url = SetUrl(aPIRequestURLs.initialScript);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteClientByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.clientsID);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);

        }

    }
}
