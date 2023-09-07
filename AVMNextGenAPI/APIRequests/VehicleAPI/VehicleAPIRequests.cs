using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.OperationalHours;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.VehicleAPI
{
    public class VehicleAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public VehicleRequestBody vehicleRequestBody;

        #endregion
        public VehicleAPIRequests()
        {
             aPIRequestURLs=new APIRequestURLs();
             vehicleRequestBody=new VehicleRequestBody();
        }
       
        /// <summary>
        /// Get vehicle Tree using API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<VehicleTreeResponseBody> getVehicleTreeDetailsAsyncRest(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.vehicleTreeRequestBody);
            var url = SetUrl(aPIRequestURLs.getVehicleByUsername);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get vehicles tree using search keyword
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="token"></param>
        /// <returns>vehicle tree</returns>
        public List<VehicleTreeResponseBody> GetVehicleInfoBySearchKeyword(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleSearchRequestBody);
            var requestBody = new VehicleSearchBody();
            var url = SetUrl(aPIRequestURLs.getVehicles);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleTreeResponseBody>>(response);
           
        }
        /// <summary>
        /// Verify vehicle status by unitId
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public List<VehicleGroupedResponseBody> GetVehicleGroupedInfoBySearchKeyword(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleSearchRequestBody);
            var requestBody = new VehicleSearchBody();
            var url = SetUrl(aPIRequestURLs.getVehicles);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleGroupedResponseBody>>(response);
        }
        /// <summary>
        /// Get manageVehicles Right panel
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public VehicleStatusByUserName GetVehicleStatusByUserName(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleStatusRequestBody);
            var requestBody = new VehicleStatusBody();
            var url = SetUrl(aPIRequestURLs.getVehicleStatusByUserName);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VehicleStatusByUserName>(response);
        }
        /// <summary>
        /// Get manageVehicles Right panel
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody GetVehicleInfoByUnitIDAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.getVehicleunitid);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ManageVehiclesResponseBody>(response);

        }
            /// <summary>
            /// Get vehuicle groups
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="token"></param>
            /// <returns></returns>
            public List<VehicleGroupResponseBody> getVehicleGroupAsync(string token)
        {
       
                var url = SetUrl(aPIRequestURLs.vehiclegroups);
                var request = CreateGetRequest(token);
                var response = GetResponse(url, request);
                return GetContent<List<VehicleGroupResponseBody>>(response);

         }
        /// <summary>
        /// Get vehicle groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<VehicleGroupResponseBody> GetVehicleGroups(string token)
        {
            var url = SetUrl(aPIRequestURLs.vehiclegroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleGroupResponseBody>>(response);
        }
        /// <summary>
        /// Create new vehicle group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody CreateNewVehicleGroup(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleStatusRequestBody);
            var requestBody = new CreateVehicleGroupBody();
            var url = SetUrl(aPIRequestURLs.vehiclegroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateVehicleGroupBody>(response);
           
        }
        /// <summary>
        /// Create new vehicle group///repeating
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody CreateVehicleGroup(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleStatusRequestBody); 
            var requestBody = new CreateVehicleGroupBody();
            var url = SetUrl(aPIRequestURLs.vehiclegroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateVehicleGroupBody>(response);
        }
        /// <summary>
        /// Get group info by id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public GetVehicleByIdResponse getVehicleGroupByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.vehiclegroupsgroupId);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<GetVehicleByIdResponse>(response);
          
        }
        /// <summary>
        /// Edit vehicle group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody editVehicleGroupDetailsByID(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleEditVehicleGroupRequestBody);
            var requestBody = new CreateVehicleGroupBody();
            var url = SetUrl(aPIRequestURLs.vehiclegroupsgroupId);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateVehicleGroupBody>(response);

        }
        /// <summary>
        /// Edit vehicle groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody EditVehicleGroupByID(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleEditVehicleGroupRequestBody);
            var requestBody = new CreateVehicleGroupBody();
            var url = SetUrl(aPIRequestURLs.vehiclegroupsgroupId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateVehicleGroupBody>(response);

        }
        /// <summary>
        /// Delete vehicle group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteVehicleGroupDetailsByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.vehiclegroupsgroupId);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
            
        }

        /// <summary>
        /// EditVehicleDetails
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody editVehicleDetailsByID(string token)
        {
            var requestBody = new ManageVehiclesResponseBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.ManageVehiclesRequestBody);
            var url = SetUrl(aPIRequestURLs.vehiclegroupsgroupId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ManageVehiclesResponseBody>(response);
          
        }
        /// <summary>
        /// Edit Vehicle details back to normal values
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody editVehicleDetailsBackToNormal(string token)
        {
            var requestBody = new ManageVehiclesResponseBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.ManageVehiclesEditRequestBody);
            var url = SetUrl(aPIRequestURLs.vehicles);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ManageVehiclesResponseBody>(response);
            
        }
        /// <summary>
        /// Get operating hour details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<OperationalHoursResponseBody1> getVehicleOperatingHours(string token)
        {
            
            var url = SetUrl(aPIRequestURLs.getOperatingHours);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<OperationalHoursResponseBody1 >>(response);
        }
        /// <summary>
        /// Get Odo and engine hour details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="unitId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public GetOdoValueResponseBody getOdoAndEngineHours(string userName, int unitId, string token)
        {
            var requestBody = new GetOdoRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.GetOdoRequestRequestBody);
            var url = SetUrl(aPIRequestURLs.vehicles);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<GetOdoValueResponseBody>(response);
        }

        /// <summary>
        /// Add/Remove Vehicles To/ From group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupId"></param>
        /// <param name="unitId"></param>
        public void AddVehiclesToGroup(string token)
        {
            var requestBody = new AddvehiclesToGroupRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.AddvehiclesToGroupRequestRequestBody);
            var url = SetUrl(aPIRequestURLs.Addvehiclestogroup);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            Assert.IsTrue(response.IsSuccessStatusCode);
           
        }
        /// <summary>
        /// Get Vehicle Contact details
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<VehicleContactResponseBody> getVehicleContacts(string token)
        {
            var url = SetUrl(aPIRequestURLs.contactGroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleContactResponseBody>>(response); 
        }
        /// <summary>
        /// GetVehicleContactsBy unit ID
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public VehicleContactUnitIdResponseBody getVehicleContactsByUnitId(string token)
        {
            var url = SetUrl(aPIRequestURLs.contactGroupunitid);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VehicleContactUnitIdResponseBody>(response);
        }
        /// <summary>
        /// Edit vehicle contacts by unit id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public VehicleContactUnitIdResponseBody EditVehicleContactsByUnitId(string token)
        {
            var requestBody = new VehicleContactUnitIdResponseBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleContactUnitIdResponseResponseBody);
            var url = SetUrl(aPIRequestURLs.contactGroupunitid);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VehicleContactUnitIdResponseBody>(response);
        }
        /// <summary>
        /// Find now vehicles
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public FindNowResponseBody VehicleFindNowByUnitId(string token)
        {
            var requestBody = new FindNowRequstBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.FindNowReRequstBody);
            var url = SetUrl(aPIRequestURLs.findNowVehicles);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<FindNowResponseBody>(response);
        }
        /// <summary>
        /// VehicleHistoryDetails
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public HistoryResponseBody VehicleHistoryDetails(string token)
        {
            var requestBody = new VehicleHistoryRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(vehicleRequestBody.VehicleHistoryReRequestBody);
            var url = SetUrl(aPIRequestURLs.vehicleHistoryDetails);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<HistoryResponseBody>(response);
        }
        /// <summary>
        /// Vehicle Alerts Request
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public VehicleAlertsResponseBody VehicleAlertsDetails(string token)
        {
            var url = SetUrl(aPIRequestURLs.VehicleAlertUnitid);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<VehicleAlertsResponseBody>(response);
        }
    
}
