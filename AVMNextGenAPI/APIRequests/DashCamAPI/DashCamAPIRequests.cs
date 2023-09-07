using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.DashCam.DashCamResponseBody;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.DashCam.DashCamTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.DashCamAPI
{
    public class DashCamAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public DashCamRequestBody dashCamRequestBody;
        #endregion
        public DashCamAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            dashCamRequestBody = new DashCamRequestBody();
        }
        /// <summary>
        /// Get dashcam status response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Driver tree response</returns>
        public void DashCamStatus(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dashCamRequestBody.dashCamStatusRequestBody);
            var requestBody = new DashCamStatusRequestBody();
            var url = SetUrl(aPIRequestURLs.dashStatus);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
        }
        /// Get dashcam storage status for vehid response
        /// </summary>
        public DashCamStorageResponseBody DashCamStorageStatus(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dashCamRequestBody.dashcamStatusRequestBody);
            var requestBody = new DashCamstatusrequestBody();
            var url = SetUrl(aPIRequestURLs.DashcamStoragestatus);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DashCamStorageResponseBody>(response);
        }
        /// Get dashcam createvideo playback
        /// </summary>
        public void DashCamCreateVideo(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dashCamRequestBody.dashCamCreatePlaybackrequestBody);
            var requestBody = new DashCamCreatePlaybackrequestBody();
            var url = SetUrl(aPIRequestURLs.createvideoplayback);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
           
        }
        /// Get dashcam recordings
        /// </summary>
        public getDashCamResponseBody GetDashCamRecordings(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dashCamRequestBody.getDashCamrequestBody);
            var requestBody = new GetDashCamrequestBody();
            var url = SetUrl(aPIRequestURLs.getdashcamRercordings);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<getDashCamResponseBody>(response);
        }
        /// Get dashcam vehicle details
        /// </summary>
        public List<getDashCamVehdetailsResponseBody> GetDashCamVehicledetails(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dashCamRequestBody.dashCamvehdetailsRequestBody);
            var requestBody = new DashCamvehdetailsRequestBody();
            var url = SetUrl(aPIRequestURLs.Dashcamvehicledetails);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<getDashCamVehdetailsResponseBody>>(response);
        }
        /// Get dashcam set alert recordings
        /// </summary>
        public getDashCamSetAlertResponseBody GetDashCamSetDataAlert(string token)
        {

           
            var url = SetUrl(aPIRequestURLs.dashcamSetdataUsageAlert);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<getDashCamSetAlertResponseBody>(response);
        }
        /// Get dashcam alarm lists
        /// </summary>
        public List <getDashCamAlarmListResponseBody> GetDashCamAlarmList(string token)
        {

            var url = SetUrl(aPIRequestURLs.dashcamAlarmlist);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<getDashCamAlarmListResponseBody>>(response);
        }

    }
}
