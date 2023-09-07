using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.OperationalHours;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.OperationalHoursAPI
{
    public class OperationalHoursAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public OperationalHoursRequestBody operationalHoursRequestBody;

        #endregion
        public OperationalHoursAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            operationalHoursRequestBody = new OperationalHoursRequestBody();
        }

        /// <summary>
        /// Create Operational Hours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public CreateOHResponseBody CreateNewOperationalHours(string token)
        {
            var requestBody = new OperationalHoursResponseBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(operationalHoursRequestBody.operationalHoursresponseBody);
            var url = SetUrl(aPIRequestURLs.createOperatingHours);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateOHResponseBody>(response);
        }
        /// <summary>
        /// Get Operational hours
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<OperationalHoursResponseBody> getOperationalHoursAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.OperationalHours);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<OperationalHoursResponseBody>>(response);
        }
        /// <summary>
        /// Edit Operational Hours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public CreateOHResponseBody EditOperationalHours(string token)
        {
            
            var requestBody = new OperationalHoursResponseBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(operationalHoursRequestBody.operationalhoursresponseBody);
            var url = SetUrl(aPIRequestURLs.updateOperatingHour);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateOHResponseBody>(response);
        }
        /// <summary>
        /// Delete Operational Hours
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteOperationalHoursByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.OperatingHoursid);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
    }
}
