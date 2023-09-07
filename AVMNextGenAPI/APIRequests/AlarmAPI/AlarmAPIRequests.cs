using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alarm;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.AlarmAPI
{
    public class AlarmAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public AlarmRequestBody alarmRequestBody;

        #endregion
        public AlarmAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            alarmRequestBody = new AlarmRequestBody();
        }
        /// <summary>
        /// Get alarm tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Alarm tree response</returns>
        public AlarmTreeResponseBody getAlarmTreeDetailsAsync(string token)
        {
            var requestBody = new AlarmBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(alarmRequestBody.AlarmRquestBody);
            var url = SetUrl(aPIRequestURLs.getAlarmsByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<AlarmTreeResponseBody>(response);
        }

        /// <summary>
        /// Get alarm tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Alarm tree response</returns>
        public AlarmTreeResponseBody GetAlarmTree(string token)
        {
            var request = CreateGetRequest(token);
            var url = SetUrl(aPIRequestURLs.getAlarmsByUsername);
            var response = GetResponse(url,request);
            return GetContent<AlarmTreeResponseBody>(response);
        }
        public ClearAlarmResponseBody ClearAlarmbyUserName(string token)
        {
           
            var requestBody = new ClearAlarmBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(alarmRequestBody.clearAlarmRequestBody);
            var url = SetUrl(aPIRequestURLs.clearAlarm);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ClearAlarmResponseBody>(response);
        }
        /// <summary>
        /// Provides the clear alarm response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clearAlarmBody"></param>
        /// <returns></returns>
       // public ClearAlarmResponseBody ClearAlarmAPI(string userName, string password, ClearAlarmBody clearAlarmBody, string token)
       // {
        //    var clearAlarmResponse = ClearAlarmbyUserName(token, clearAlarmBody);
       //     return clearAlarmResponse;
       // }
    }      