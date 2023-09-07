using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.HereMap;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.HereMap.HereMapTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.HereMapAPI
{
    public class HereMapAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public HereMapRequestBody hereMapRequestBody;

        #endregion
        public HereMapAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            hereMapRequestBody = new HereMapRequestBody();
        }
        /// <summary>
        /// Performs a text search on the location names or codes
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        public List<HereMapResponseBody> mapHereSearchLocation(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hereMapRequestBody.hereMaplocationbody);
            var requestBody = new HereMaplocationbody();
            var url = SetUrl(aPIRequestURLs.HeremapSearchLocations);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<HereMapResponseBody>>(response);

        }
        /// <summary>
        /// Does a reverse geocoding at the specified lat/lon from the HERE map API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        public List<HereMapResponseBody> mapSearchLocation(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hereMapRequestBody.HereMapGetlocationbody);
            var requestBody = new HereMapGetlocationbody();
            var url = SetUrl(aPIRequestURLs.HereMapgetlocationinfo);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<HereMapResponseBody>>(response);

        }
        /// <summary>
        /// Draws the route.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        public List<HereMapResponseBody> mapHereDrawRoute(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hereMapRequestBody.hereMapGetDrawRoutebody);
            var requestBody = new HereMapGetDrawRoutebody();
            var url = SetUrl(aPIRequestURLs.HereMapDrawroute);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<HereMapResponseBody>>(response);

        }

    }
}
