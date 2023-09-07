using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.MapSettings;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.MapSettings.MapSettingsTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.MapSettingsAPI
{
    public class MapSettingsAPIRequests :APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public MapSettingsRequestBody mapSettingsRequestBody;

        #endregion
        public MapSettingsAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            mapSettingsRequestBody = new MapSettingsRequestBody();
        }
        /// <summary>
        /// Create map Settings
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public void CreateNewMapSetting(string token)
        {
            var requestBody = new MapSettingsrequestbody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(mapSettingsRequestBody.mapsettingsBody);
            var url = SetUrl(aPIRequestURLs.MapSettings);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
        }

        /// <summary>
        /// Get Map settings details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public MapSettingsResponseBody getMapSettingsAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.MapSettings);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<MapSettingsResponseBody>(response);
        }
        /// <summary>
        /// Get map settings for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MapSettingsResponseBody getMapSettings(string token)
        {
            var url = SetUrl(aPIRequestURLs.MapSettings);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<MapSettingsResponseBody>(response);
        }

    }
}
