using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.UserSettings;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.UserSettingsAPI
{
    public class UserSettingsAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public UserSettingsRequestBody userSettingsRequestBody;

        #endregion
        public UserSettingsAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            userSettingsRequestBody = new UserSettingsRequestBody();
        }
        /// <summary>
        /// Get User Settings details
        /// </summary>
        /// <param name="settingsName">W4_LAST_MAP_EXTENT</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public UserSettingsResponseBody GetUserSettingsBySettingsName(string token)
        {
            var url = SetUrl(aPIRequestURLs.settingName);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<UserSettingsResponseBody>(response);
        }
        /// <summary>
        /// Save user settings
        /// </summary>
        /// <param name="token"></param>
        public void SaveUserSettings(string token)
        {
            var requestBody = new UserSettingsSaveRequest();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(userSettingsRequestBody.userSettingsSaveRequest);
            var url = SetUrl(aPIRequestURLs.userS);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
        }

    }

}
