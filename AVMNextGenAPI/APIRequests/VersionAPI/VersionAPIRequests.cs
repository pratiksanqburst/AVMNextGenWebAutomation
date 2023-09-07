using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Version;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.VersionAPI
{
    public class VersionAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public VersionRequestBody versionRequestBody;

        #endregion
        public VersionAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            versionRequestBody = new VersionRequestBody();
        }
        /// <summary>
        /// Version
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public VersionResponseBody GetVersion(string token)
        {
           
            var url = SetUrl(aPIRequestURLs.versionAPI);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VersionResponseBody>(response);
        }
        /// <summary>
        /// Get app version number
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public VersionNumberResponseBody GetVersionNumber(string token)
        {
            var url = SetUrl(aPIRequestURLs.appVersion);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VersionNumberResponseBody>(response);
        }
    }
}
