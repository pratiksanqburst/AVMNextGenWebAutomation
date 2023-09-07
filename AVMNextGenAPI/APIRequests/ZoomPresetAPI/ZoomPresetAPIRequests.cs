using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ZoomPreset;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.ZoomPresetAPI
{
    public class ZoomPresetAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public ZoomPresetRequestBody zoomPresetRequestBody;

        #endregion
        public ZoomPresetAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            zoomPresetRequestBody = new ZoomPresetRequestBody();
        }
        /// <summary>
        /// Get zoom preset details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ZoomPresetResponseBody getZoomPresetAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.ZoomPresetS);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Get zoom preset for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ZoomPresetResponseBody getZoomPreset(string token)
        {
            var url = SetUrl(aPIRequestURLs.ZoomPresetS);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
        
        }
        /// <summary>
        /// Create New Zoom preset
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public void CreateNewZoomPreset(string token)
        {
            var requestBody = new ZoomPresetResponseBody();
            requestBody.settings = "[{\"id\":1668485699206,\"mapView\":{\"center\":{\"lat\":-33.77485782570622,\"lng\":151.04641601443294},\"zoom\":18},\"saved\":true,\"name\":\"" + presetName + "\"}]";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/zoompresets", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            ApiClient.Dispose();
        }

    }
}
