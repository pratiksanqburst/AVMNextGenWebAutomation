using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.FleetManager;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.FleetManager.FleetManagerResponseBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.FleetManagerAPI
{
    public class FleetManagerAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public FleetManagerRequestBody fleetManagerRequestBody;

        #endregion
        public FleetManagerAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            fleetManagerRequestBody = new FleetManagerRequestBody();
        }
        /// <summary>
        /// Save User Preference
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Driver tree response</returns>
        public List<FleetManageruserResponseBody> SavePreferenceUser(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(fleetManagerRequestBody.fleetManagertreeBody);
            var requestBody = new FleetManagerTreeBody();
            var url = SetUrl(aPIRequestURLs.Preferencesave);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<FleetManageruserResponseBody>>(response);
        }
        /// <summary>
        /// Get User Preference
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Driver tree response</returns>
        public List<FleetManageruserResponseBody> GetPreferenceUser(string token)
        {
            var url = SetUrl(aPIRequestURLs.prefrenceget);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<FleetManageruserResponseBody>>(response);
        }
    }
}
