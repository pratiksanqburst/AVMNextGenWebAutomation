using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http.Headers;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.AlertAPI
{
    public class AlertAPIRequest:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public AlertRequestBody alertRequestBody;
        #endregion
       
        public AlertAPIRequest()
        {
            aPIRequestURLs = new APIRequestURLs();
            alertRequestBody = new AlertRequestBody();
        }
        /// <summary>
        /// Get alert tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Alert tree response</returns>
        public List<AlertTreeResponseBody> getAlertTreeDetailsAsync(string token)
        {
            var requestBody = new LoginBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(alertRequestBody.loginRequestbody);
            var url = SetUrl(aPIRequestURLs.getAlertsByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<AlertTreeResponseBody>>(response);
        }

        /// <summary>
        /// Get alert tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Alert tree response</returns>
        public List<AlertTreeResponseBody> GetAlertTree(string token)
        {
            var url = SetUrl(aPIRequestURLs.getAlertsByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<AlertTreeResponseBody>>(response);
        }

        /// <summary>
        /// Get alert details by alert id
        /// </summary>
        /// <param name="alertID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public AlertTreeResponseBody getAlertDetailsByAlertId(string token)
        {
            var url = SetUrl(aPIRequestURLs.alertid);
            var request = CreateGetRequest(token);
            var response = GetResponse(url,request);
            return GetContent<AlertTreeResponseBody>(response);
        }
        /// <summary>
        /// Delete alerts by Id
        /// </summary>
        /// <param name="alertID"></param>
        /// <param name="token"></param>
        public void DeleteAlertsByCount(string token)
        {
            var requestBody = new DeleteAlerts();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(alertRequestBody.deleteAlerts);
            var url = SetUrl(aPIRequestURLs.alertDelete);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
            
        }
    }

}
