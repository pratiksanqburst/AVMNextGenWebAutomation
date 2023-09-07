using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alarm;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Alerts;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.MapSettings;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.OperationalHours;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ZoomPreset;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    #region Service Request Body


    public class AddLocaTionsToGroupRequestBody
    {
        public int[] locationIds { get; set; }
        public int groupId { get; set; }
    }

    public class FindNowRequstBody
    {
        public string userName { get; set; }
        public int unitId { get; set; }
    }

    public class VehicleHistoryRequestBody
    {
        public int unitId { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public Extent extent { get; set; }
        public int width { get; set; }
        public int zoom { get; set; }
        public int height { get; set; }
        public int maxPoints { get; set; }
        public bool addAlerts { get; set; }
    }

    public class Extent
    {
        public Topleft topLeft { get; set; }
        public Bottomright bottomRight { get; set; }
    }

    public class Topleft
    {
        public int lat { get; set; }
        public int lng { get; set; }
    }

    public class Bottomright
    {
        public int lat { get; set; }
        public int lng { get; set; }
    }

    public class AddvehiclesToGroupRequestBody
    {

        public int[] unitIds { get; set; }
        public int groupId { get; set; }
    }

    public class GetOdoRequestBody
    {
        public string userName { get; set; }
        public int unitId { get; set; }
        public int driverIdCurrent { get; set; }
    }

    public class DeleteLocationRequestBody
    {
        public int[] locationIds { get; set; }
    }

    public class CreateLocationRequestBody
    {
        public int groupId { get; set; }
        public string? groupName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public string locationTypeCode { get; set; }
        public string locationTypeName { get; set; }
        public Featuredata? featureData { get; set; }
        public int featureShape { get; set; }
        public int locationRadiusMeters { get; set; }
        public int? total { get; set; }
    }

    public class LocationsSearchRequestBody
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
        public int groupId { get; set; }
    }

    public class Featuredata
    {
        public double[]? bbox { get; set; }
        public Crs? crs { get; set; }
        public string? id { get; set; }
        public Geometry? geometry { get; set; }
        public Properties? properties { get; set; }
        public string? type { get; set; }

    }


    public class Geometry
    {
        public double[]? coordinates { get; set; }
        public string? type { get; set; }
    }

    public class Properties
    {
        public int locationRadius { get; set; }
        public string? additionalProp1 { get; set; }
        public string? additionalProp2 { get; set; }
        public string? additionalProp3 { get; set; }
    }

    public class GetServiceByIdRequest
    {
        public string userName { get; set; }
        public int serviceId { get; set; }
    }


    public class GetServicesByUserNameRequest
    {
        public string userName { get; set; }
        public int unitId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }

    public class CreateServiceRequestBody
    {
        public int unitId { get; set; }
        public int serviceType { get; set; }
        public string serviceDate { get; set; }
        public int cost { get; set; }
        public int odometer { get; set; }
        public string notes { get; set; }
        public int engineHours { get; set; }
        public string userName { get; set; }
    }



    #endregion


    #region Service Schedule Request Body

    public class ServiceScheduleRequestBody
    {
        public int scheduleId { get; set; }
        public int trackerId { get; set; }
        public int serviceType { get; set; }
        public bool enabled { get; set; }
        public string startDate { get; set; }
        public int interval { get; set; }
        public int reminder { get; set; }
        public int startOdometer { get; set; }
        public int intervalKm { get; set; }
        public int reminderKm { get; set; }
        public string created { get; set; }
        public string lastModified { get; set; }
        public int startEngineHours { get; set; }
        public int intervalEngineHours { get; set; }
        public int reminderEngineHours { get; set; }
        public int reminderSentEngineHours { get; set; }
        public int reminderSentKm { get; set; }
        public int contactId { get; set; }
        public string contactName { get; set; }
        public string notes { get; set; }
        public string reminderSentDate { get; set; }
        public bool reminderTriggered { get; set; }
        public int deleted { get; set; }
    }

    public class MultipleServiceScheduleRequestBody
    {
        public ServiceScheduleRequestBody[] Property1 { get; set; }
    }




    #endregion
    public class CreateDriverGroupBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public string color { get; set; }

    }

    public class UpdateMultipleRequest
    {
        public UpdateTripRequest[] Property1 { get; set; }
    }

    public class UpdateTripRequest
    {
        public int tripId { get; set; }
        public int driverId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool isBusiness { get; set; }
        public string? reason { get; set; }
    }

    public class SingleTriprequestBody
    {
        public int tripId { get; set; }
        public int driverId { get; set; }
        public string startDate { get; set; }
    }

    public class UserSettingsSaveRequest
    {
        public string settingName { get; set; }
        public string settingValue { get; set; }
    }

    public class ClientInitialScriptRequestBody
    {
        public string locationTypeIcon { get; set; }
        public string locationTypeIocnUrl { get; set; }
    }


    public class UpdatePasswordRequestBody
    {
        public string password { get; set; }
    }

    public class SuppressAlertsRequestBody
    {
        public int clientId { get; set; }
        public bool suppressAlerts { get; set; }
    }

    public class SuppressAlarmsRequestBody
    {
        public int clientId { get; set; }
        public bool suppressAlarms { get; set; }
    }

    public class AccountLockedRequestBody
    {
        public int clientId { get; set; }
        public int isAccountLocked { get; set; }
    }


    public class DeleteDriversRequestBody
    {
        public int[] driverIds { get; set; }
    }


    public class AssignDriversToGrpRequestBody
    {
        public int[] driverIds { get; set; }
        public int groupId { get; set; }
    }

    public class ClientIdRequestBody
    {
        public int clientId { get; set; }
    }


    public class CreateDriverBody
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phone1 { get; set; }
        public string? email1 { get; set; }
        public string? address1 { get; set; }
        public string? address2 { get; set; }
        public string? nationality { get; set; }
        public string? dateJoined { get; set; }
        public string? gender { get; set; }
        public string? groupName { get; set; }
        public string? bloodType { get; set; }
        public string? licenceNumber { get; set; }
        public string? driverUniqueId { get; set; }
        public int? groupId { get; set; }
        public string? emergencyContactName { get; set; }
        public string? emergencyContactRelationship { get; set; }
        public string? emergencyContactPhone1 { get; set; }
        public string? licenseExpiryDate { get; set; }
        public string? licenseState { get; set; }
        public int? unitId { get; set; }
        public int? rfTagId { get; set; }
    }
    public class EditDriverBody
    {
        public int driverId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone1 { get; set; }
        public string email1 { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string nationality { get; set; }
        public string dateJoined { get; set; }
        public string gender { get; set; }
        public string groupName { get; set; }
        public string bloodType { get; set; }
        public string licenceNumber { get; set; }
        public string driverUniqueId { get; set; }
        public int groupId { get; set; }
        public string emergencyContactName { get; set; }
        public string emergencyContactRelationship { get; set; }
        public string emergencyContactPhone1 { get; set; }
        public string licenseExpiryDate { get; set; }
        public string licenseState { get; set; }
        public int unitId { get; set; }
        public int rfTagId { get; set; }
    }

    public class ClearAlarmBody
    {
        public string UserName { get; set; }
        public AlarmToClear alarmToClear { get; set; }
        public bool isTestingAlarm { get; set; }
        public bool isNonReportingMobile { get; set; }
        public string enteredName { get; set; }
        public string enteredReason { get; set; }
    }
    public class ContactGroupRequestBody
    {
        public string shortName { get; set; }
        public string fullName { get; set; }
        public string comments { get; set; }
        public bool deleted { get; set; }
    }

    public class MapSettingsRequestBody
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class EditContactGroupRequestBody
    {
        public int contactGroupId { get; set; }
        public string shortName { get; set; }
        public string fullName { get; set; }
        public string comments { get; set; }
        public bool deleted { get; set; }
    }

    public class EditRoleNameRequestBody
    {
        public string userName { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
    }

    public class EditRoleRightsRequestBody
    {
        public string userName { get; set; }
        public bool defaultRole { get; set; }
        public int[] reportList { get; set; }
        public int[] accessRights { get; set; }
    }



    public class RolesCreationRequestBody
    {
        public string userName { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public bool defaultRole { get; set; }
        public int[] reportList { get; set; }
        public int[] accessRights { get; set; }
    }


    public class DeleteAlerts
    {
        public int[] Property1 { get; set; }
    }


    public class AlarmToClear
    {
        public int? unitId { get; set; }
        public string unitName { get; set; }
        public int? fleetId { get; set; }
        public int statusId { get; set; }
        public int alertId { get; set; }
        public int alarmType { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string address { get; set; }
        public string alarmText { get; set; }
        public string detail { get; set; }
        public int driverId { get; set; }
        public string? driverName { get; set; }
        public string? contactPhone { get; set; }
        public DateTime utcTime { get; set; }
        public int alertType { get; set; }
    }
    public class VehicleSearchBody
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
        public bool forManagement { get; set; }

    }

    public class LocationTypesBody
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int? toleranceMetres { get; set; }
        public bool? replaceAddressWithLocationName { get; set; }
        public bool? duringVehicleOperatingHours { get; set; }
        public int priority { get; set; }
        public int? deleted { get; set; }
        public string? icon { get; set; }
        public string colorHex { get; set; }
        public bool? optionLogOnly { get; set; }
        public bool? optionNotifyEntryExit { get; set; }
        public bool? optionNotifyOnEntry { get; set; }
        public bool? optionNotifyOnExit { get; set; }
        public string? iconUrl { get; set; }
    }
    public class LoginBody
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class AlarmBody
    {
        public string UserName { get; set; }
    }
    public class VehicleStatusBody
    {
        public string userName { get; set; }
        public int unitId { get; set; }
        public int driverIdCurrent { get; set; }
    }

    public class CreateVehicleGroupBody
    {
        public string groupName { get; set; }
        public string description { get; set; }
        public string groupColor { get; set; }
        public int? groupId { get; set; }

    }
    public class EditVehicleGroupBody
    {
        public string groupName { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public int? groupId { get; set; }

    }


    public class VehicleTreeBody
    {
        public string UserName { get; set; }
        public bool forManagement { get; set; }
    }

    public class VehicleTripBody
    {
        public int unitId { get; set; }
        public DateTime tripStartTime { get; set; }
        public DateTime tripEndTime { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public bool isAssignedTrip { get; set; }
    }

    public class AssignDriverRequestBody
    {
        public int unitId { get; set; }
        public int driverId { get; set; }
    }

    public class GetAPIResponse : APIHelper
    {

        public GetAPIResponse()
        {
            APIInitialization();
        }

        #region Common Methods
        public async Task<string> getBearerTokenAsync(string userName, string password)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestBody = new LoginBody();
            requestBody.userName = userName;
            requestBody.password = password;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Add("recaptcha-Token", reCaptchaToken);
            var response = await ApiClient.PostAsync(baseAddressLogin + "api/Login", data);
            Assert.IsTrue(response.IsSuccessStatusCode);
            return await response.Content.ReadAsStringAsync();

        }

        #endregion











        #region Token generation









        /// <summary>
        /// Get the bearer token after login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Bearer token</returns>
        public async Task<string> getBearerTokenAsync1(string userName, string password)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestBody = new LoginBody();
            requestBody.userName = userName;
            requestBody.password = password;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Add("recaptcha-Token", reCaptchaToken);
            var response = await ApiClient.PostAsync(baseAddressLogin + "api/Login", data);
            Assert.IsTrue(response.IsSuccessStatusCode);
            return await response.Content.ReadAsStringAsync();

        }
        #endregion

        #region Vehicles API

        public List<VehicleTreeResponseBody> getVehicleTreeDetailsAsyncRest(string userName, string token)
        {
            var requestBody = new VehicleTreeBody();
            requestBody.UserName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var url = SetUrl("api/vehicles/GetVehiclesByUsername");
            var request = CreatePostRequest(json, token);
            var response = GetResponse(url, request);
            return GetContent<List<VehicleTreeResponseBody>>(response);
        }





        /// <summary>
        /// Get Vehicle tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Vehicle response</returns>
        public List<VehicleTreeResponseBody> getVehicleTreeDetailsAsync(string userName, string token)
        {
            var requestBody = new VehicleTreeBody();
            requestBody.UserName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/vehicles/GetVehiclesByUsername", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleTreeResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Gets Vehicle tree resonse
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>returns Vehicle tree response</returns>
        public List<VehicleTreeResponseBody> GetVehicleTree(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicle = getVehicleTreeDetailsAsyncRest(userName, token);
            return vehicle;
        }
        /// <summary>
        /// Get vehicles tree using search keyword
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="token"></param>
        /// <returns>vehicle tree</returns>
        public List<VehicleTreeResponseBody> GetVehicleInfoBySearchKeyword(string userName, string password, string searchKey)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.forManagement = true;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Vehicles/GetVehicles", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleTreeResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get vehicles grouped info
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<VehicleGroupedResponseBody> GetVehicleGroupedInfoBySearchKeyword(string userName, string password, string searchKey)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.forManagement = true;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Vehicles/GetVehiclesGrouped", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleGroupedResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Verify vehicle status by unitId
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public VehicleStatusByUserName GetVehicleStatusByUserName(string userName, string password, int unitId, int driverId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var requestBody = new VehicleStatusBody();
            requestBody.userName = userName;
            requestBody.unitId = unitId;
            requestBody.driverIdCurrent = driverId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Vehicles/GetVehicleStatusByUserName", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VehicleStatusByUserName>(jsonString.Result);
            ApiClient.Dispose();
        }

        /// <summary>
        /// Get manageVehicles Right panel
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody GetVehicleInfoByUnitIDAsync(int unitId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/vehicles/{unitId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ManageVehiclesResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Verify Manage Vehicles right panel
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody GetRightPanelVehcileDetails(string userName, string password, int unitId)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleTreeResponse = GetVehicleInfoByUnitIDAsync(unitId, token);
            return vehicleTreeResponse;
        }

        /// <summary>
        /// Get vehuicle groups
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<VehicleGroupResponseBody> getVehicleGroupAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Vehicles/Groups");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleGroupResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get vehicle groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<VehicleGroupResponseBody> GetVehicleGroups(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleResponse = getVehicleGroupAsync(userName, token);
            return vehicleResponse;
        }
        /// <summary>
        /// Create new vehicle group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody CreateNewVehicleGroup(string userName, string token, string groupName)
        {
            var requestBody = new CreateVehicleGroupBody();
            requestBody.groupName = groupName;
            requestBody.description = "Test automation desc";
            requestBody.groupColor = "29B6F6";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Vehicles/Groups", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateVehicleGroupBody>(jsonString.Result);
        }
        /// <summary>
        /// Create new vehicle group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody CreateVehicleGroup(string userName, string password, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleResponse = CreateNewVehicleGroup(userName, token, groupName);
            return vehicleResponse;
        }
        /// <summary>
        /// Get group info by id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public GetVehicleByIdResponse getVehicleGroupByID(string groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Vehicles/Groups/{groupId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetVehicleByIdResponse>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit vehicle group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody editVehicleGroupDetailsByID(string token, int groupId, string groupName)
        {
            var requestBody = new CreateVehicleGroupBody();
            requestBody.groupName = groupName;
            requestBody.description = "Test automation desc edited";
            requestBody.groupColor = "E91E63";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/vehicles/Groups/{groupId}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateVehicleGroupBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit vehicle groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CreateVehicleGroupBody EditVehicleGroupByID(string userName, string password, int groupID, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var vehicleResponse = editVehicleGroupDetailsByID(token, groupID, groupName);
            return vehicleResponse;
        }
        /// <summary>
        /// Delete vehicle group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteVehicleGroupDetailsByID(string token, string groupId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/vehicles/Groups/{groupId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// EditVehicleDetails
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody editVehicleDetailsByID(string token, int unitId)
        {
            var requestBody = new ManageVehiclesResponseBody();
            requestBody.unitId = unitId;
            requestBody.chassisVin = "VIN123Edit";
            requestBody.driverId = 0;
            requestBody.engHoursReading = 0;
            requestBody.engHoursReadingDateUtc = "2022-02-22T03:42:00.243Z";
            requestBody.engHoursReadingSeconds = 0;
            requestBody.engineNumber = "EN123Edit";
            requestBody.groupId = 388;
            requestBody.isCalibratingEngHours = false;
            requestBody.isCalibratingOdo = false;
            requestBody.licensesRequired = "ReqTestLicenseEdit";
            requestBody.manufacturer = "TestManufacEdit";
            requestBody.model = "2019";
            requestBody.odometerReading = 0;
            requestBody.odometerReadingDateUtc = "2022-12-01T15:14:00.090Z";
            requestBody.operatingHours = 81;
            requestBody.registration = "RG7357Edit";
            requestBody.serialNumber = "string";
            requestBody.trackerId = 61562;
            requestBody.type = "TestTypeEdit";
            requestBody.vehicleCategory = "TestCatEdit";
            requestBody.vehicleId = "2727";
            requestBody.vehicleName = "AutoVehicleEdit";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/vehicles", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ManageVehiclesResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit Vehicle details back to normal values
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public ManageVehiclesResponseBody editVehicleDetailsBackToNormal(string token, int unitId)
        {
            var requestBody = new ManageVehiclesResponseBody();
            requestBody.unitId = unitId;
            requestBody.chassisVin = "VIN123";
            requestBody.driverId = 0;
            requestBody.engHoursReading = 0;
            requestBody.engHoursReadingDateUtc = "2022-02-22T03:42:00.243Z";
            requestBody.engHoursReadingSeconds = 0;
            requestBody.engineNumber = "EN123";
            requestBody.groupId = 388;
            requestBody.isCalibratingEngHours = false;
            requestBody.isCalibratingOdo = false;
            requestBody.licensesRequired = "ReqTestLicense";
            requestBody.manufacturer = "TestManufac";
            requestBody.model = "2022";
            requestBody.odometerReading = 0;
            requestBody.odometerReadingDateUtc = "2022-12-01T15:14:00.090Z";
            requestBody.operatingHours = 81;
            requestBody.registration = "RG7357";
            requestBody.serialNumber = "string";
            requestBody.trackerId = 61562;
            requestBody.type = "TestType";
            requestBody.vehicleCategory = "TestCat";
            requestBody.vehicleId = "2727";
            requestBody.vehicleName = "AutoVehicle";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/vehicles", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ManageVehiclesResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Get operating hour details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<OperationalHoursResponseBody1> getVehicleOperatingHours(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Vehicles/GetOperatingHours");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OperationalHoursResponseBody1>>(jsonString.Result);
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
            requestBody.userName = userName;
            requestBody.unitId = unitId;
            requestBody.driverIdCurrent = -1;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Vehicles/GetOdometerAndEngineHours", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetOdoValueResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Add/Remove Vehicles To/ From group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupId"></param>
        /// <param name="unitId"></param>
        public void AddVehiclesToGroup(string token, int groupId, int unitId)
        {
            var requestBody = new AddvehiclesToGroupRequestBody();
            requestBody.groupId = groupId;
            requestBody.unitIds = new[] { unitId };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/vehicles/addvehiclestogroup", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Get Vehicle Contact details
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<VehicleContactResponseBody> getVehicleContacts(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Vehicles/ContactGroups");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VehicleContactResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// GetVehicleContactsBy unit ID
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public VehicleContactUnitIdResponseBody getVehicleContactsByUnitId(string token, int unitId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Vehicles/ContactGroups/{unitId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VehicleContactUnitIdResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit vehicle contacts by unit id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public VehicleContactUnitIdResponseBody EditVehicleContactsByUnitId(string token, int unitId, int groupId, string groupName)
        {
            var requestBody = new VehicleContactUnitIdResponseBody();
            requestBody.contactGroupId = groupId;
            requestBody.contactGroupShortName = groupName;
            requestBody.warning = "Warning automation";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Vehicles/ContactGroups/{unitId}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VehicleContactUnitIdResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Find now vehicles
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public FindNowResponseBody VehicleFindNowByUnitId(string token, int unitId, string userName)
        {
            var requestBody = new FindNowRequstBody();
            requestBody.userName = userName;
            requestBody.unitId = unitId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Vehicles/FindNowVehicle", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FindNowResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// VehicleHistoryDetails
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public HistoryResponseBody VehicleHistoryDetails(string token, int unitId)
        {
            var requestBody = new VehicleHistoryRequestBody();

            requestBody.extent = new Extent();
            requestBody.extent.topLeft = new Topleft();
            requestBody.extent.bottomRight = new Bottomright();

            requestBody.addAlerts = false;
            requestBody.extent.bottomRight.lat = 0;
            requestBody.extent.bottomRight.lng = 0;
            requestBody.extent.topLeft.lat = 0;
            requestBody.extent.bottomRight.lng = 0;
            requestBody.height = 0;
            requestBody.maxPoints = 500;
            requestBody.start = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            requestBody.stop = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
            requestBody.unitId = unitId;
            requestBody.width = 0;
            requestBody.zoom = 0;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/vehicles/VehicleHistoryDetails", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HistoryResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Vehicle Alerts Request
        /// </summary>
        /// <param name="token"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public VehicleAlertsResponseBody VehicleAlertsDetails(string token, int unitId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Vehicles/Alerts/{unitId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VehicleAlertsResponseBody>(jsonString.Result);
        }


        #endregion

        #region Drivers API
        /// <summary>
        /// Get driver tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Driver tree response</returns>
        public List<DriverTreeResponseBody> getDriverTreeDetailsAsync(string userName, string token, bool forManagement = false)
        {
            var requestBody = new VehicleTreeBody();
            requestBody.UserName = userName;
            requestBody.forManagement = forManagement;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/drivers/GetDriversByUsername", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DriverTreeResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get driver tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Driver tree response</returns>
        public List<DriverTreeResponseBody> GetDriverTree(string userName, string password, bool forManagement = false)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverResponse = getDriverTreeDetailsAsync(userName, token, forManagement);
            return driverResponse;
        }
        /// <summary>
        /// Get right panel details for drivers
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="driverId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public DriverRightPanelResponseBody getDriverRightPanelDetailsAsync(string userName, int Id, string token, bool isDriver = true)
        {
            var requestBody = new VehicleStatusBody();
            requestBody.userName = userName;
            if (isDriver)
                requestBody.driverIdCurrent = Id;
            else
                requestBody.unitId = Id;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Vehicles/GetVehicleStatusByUserName", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DriverRightPanelResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get driver Right panel.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public DriverRightPanelResponseBody GetDriverRightPanel(string userName, string password, int Id, bool isDriver = true)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverRightPanelResponse = getDriverRightPanelDetailsAsync(userName, Id, token, isDriver);
            return driverRightPanelResponse;
        }
        /// <summary>
        /// Create new driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverGroupBody CreateNewDriverGroup(string userName, string token, string groupName)
        {
            var requestBody = new DriverGroupsResponsebody();
            requestBody.groupId = 0;
            requestBody.driverCount = 0;
            requestBody.groupName = groupName;
            requestBody.description = "Test automation desc";
            requestBody.color = "29b6f6";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/drivers/Groups", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateDriverGroupBody>(jsonString.Result);
        }
        /// <summary>
        /// Create new driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverGroupBody CreateDriverGroup(string userName, string password, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverResponse = CreateNewDriverGroup(userName, token, groupName);
            return driverResponse;
        }
        /// <summary>
        /// Get Driver groups
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<DriverGroupsResponsebody> getDriverGroupsAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Drivers/GetDriverGroups");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DriverGroupsResponsebody>>(jsonString.Result);
        }
        /// <summary>
        /// Get driver groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<DriverGroupsResponsebody> GetDriverGroups(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverResponse = getDriverGroupsAsync(userName, token);
            return driverResponse;
        }
        /// <summary>
        /// Create new driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public CreateDriverResponsebody CreateNewDriver(string userName, string token, string groupName, int groupId)
        {
            var requestBody = new CreateDriverBody();
            requestBody.groupId = groupId;
            requestBody.address1 = "Test automation address";
            requestBody.bloodType = "";
            requestBody.dateJoined = DateTime.UtcNow.AddDays(-2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.driverUniqueId = "12345";
            requestBody.email1 = "testautomation" + DateTime.Now.ToString("dd") + "@gtail.com";
            requestBody.emergencyContactName = "";
            requestBody.emergencyContactPhone1 = "";
            requestBody.emergencyContactRelationship = "";
            requestBody.firstName = "Test";
            requestBody.gender = "";
            requestBody.groupName = groupName;
            requestBody.lastName = "AutoDriver";
            requestBody.licenceNumber = "11111";
            requestBody.licenseExpiryDate = DateTime.UtcNow.AddDays(2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.licenseState = "active";
            requestBody.nationality = "";
            requestBody.phone1 = "987654321";
            requestBody.rfTagId = -1;
            requestBody.unitId = 2727;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json-patch+json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/drivers/CreateDriver", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateDriverResponsebody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Create new driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverResponsebody CreateDriver(string userName, string password, string groupName, int groupId, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = CreateNewDriver(userName, token, groupName, groupId);
            return locationResponse;
        }
        /// <summary>
        /// Get driver details by search text
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<DriverTreeResponseBody> GetDriverInfoBySearchKeyword(string token, string searchKey)
        {
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Drivers/GetDrivers", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DriverTreeResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get driver grouped info by search text
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<DriverGroupedResponseBody> GetDriverGroupedInfoBySearchKeyword(string token, string searchKey)
        {
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Drivers/GetDriversGrouped", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DriverGroupedResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get Driver By group Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public DriverByGroupIdResponseBody getDriverByGroupID(int groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/drivers/GetDriversByGroupId/{groupId}/1/20");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DriverByGroupIdResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Assign Unassign To Driver
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        /// <param name="unitId"></param>
        public void AssignVehicleToDriver(string token, int driverId, int unitId)
        {
            var requestBody = new AssignDriverRequestBody();
            requestBody.driverId = driverId;
            requestBody.unitId = unitId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/drivers/AssignVehicleToDriver", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Edit driver details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <param name="groupId"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public CreateDriverResponsebody EditDriverDetails(string userName, string token, string groupName, int groupId, int driverId)
        {
            var requestBody = new EditDriverBody();
            requestBody.driverId = driverId;
            requestBody.groupId = groupId;
            requestBody.address1 = "Test automation address edited";
            requestBody.bloodType = "";
            requestBody.dateJoined = DateTime.UtcNow.AddDays(-3).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.driverUniqueId = "12345";
            requestBody.email1 = "testautoedited" + DateTime.Now.ToString("dd") + "@gtail.com";
            requestBody.emergencyContactName = "";
            requestBody.emergencyContactPhone1 = "";
            requestBody.emergencyContactRelationship = "";
            requestBody.firstName = "TestEdit";
            requestBody.gender = "";
            requestBody.groupName = groupName;
            requestBody.lastName = "AutoDriverEdit";
            requestBody.licenceNumber = "22222";
            requestBody.licenseExpiryDate = DateTime.UtcNow.AddDays(4).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.licenseState = "inactive";
            requestBody.nationality = "";
            requestBody.phone1 = "123456789";
            requestBody.rfTagId = -1;
            requestBody.unitId = 2727;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + "api/drivers/UpdateDriver", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateDriverResponsebody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverResponsebody EditDriver(string userName, string password, string groupName, int groupId, int driverId, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = EditDriverDetails(userName, token, groupName, groupId, driverId);
            return locationResponse;
        }
        /// <summary>
        /// Get Driver by Id
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public GetDriverByIdResponseBody getDriverByID(int driverId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Drivers/{driverId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetDriverByIdResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Assign Drivers to group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        /// <param name="groupId"></param>
        public void AssignDriverToGroup(string token, int[] driverId, int groupId)
        {
            var requestBody = new AssignDriversToGrpRequestBody();
            requestBody.driverIds = driverId;
            requestBody.groupId = groupId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/drivers/AssignDriversToGroup", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Delete Drivers
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        public void DeleteDrivers(string token, int[] driverId)
        {
            var requestBody = new DeleteDriversRequestBody();
            requestBody.driverIds = driverId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/drivers/DeleteDrivers", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit driver group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public DriverGroupsResponsebody EditDriverGroupDetails(string userName, string token, string groupName, int groupId)
        {
            var requestBody = new EditVehicleGroupBody();
            requestBody.groupName = groupName + "Edited";
            requestBody.description = "Test automation desc edited";
            requestBody.color = "5e35b1";
            requestBody.groupId = groupId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/drivers/Groups/{groupId}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DriverGroupsResponsebody>(jsonString.Result);
        }
        /// <summary>
        /// Edit driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public DriverGroupsResponsebody EditDriverGroup(string userName, string password, string groupName, int groupId, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var driverResponse = EditDriverGroupDetails(userName, token, groupName, groupId);
            return driverResponse;
        }
        /// <summary>
        /// Get Driver group by ID
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateDriverGroupBody getDriverGroupByID(int groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Drivers/GetDriverGroupByGroupId/{groupId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateDriverGroupBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Delete Driver Group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteDriverGroupByID(string token, int groupID)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/drivers/Groups/{groupID}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }

        #endregion

        #region Alarms API
        /// <summary>
        /// Get alarm tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Alarm tree response</returns>
        public AlarmTreeResponseBody getAlarmTreeDetailsAsync(string userName, string token)
        {
            var requestBody = new AlarmBody();
            requestBody.UserName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/alarms/GetAlarmsByUsername", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AlarmTreeResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Get alarm tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Alarm tree response</returns>
        public AlarmTreeResponseBody GetAlarmTree(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var alarmResponse = getAlarmTreeDetailsAsync(userName, token);
            return alarmResponse;
        }
        public AlarmTreeResponseBody GetAlarmTree(string userName, string password, string token)
        {
            var alarmResponse = getAlarmTreeDetailsAsync(userName, token);
            return alarmResponse;
        }
        #endregion

        #region Alerts API
        /// <summary>
        /// Get alert tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Alert tree response</returns>
        public List<AlertTreeResponseBody> getAlertTreeDetailsAsync(string userName, string token)
        {
            var requestBody = new LoginBody();
            requestBody.userName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/alerts/GetAlertsByUsername", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AlertTreeResponseBody>>(jsonString.Result);
        }

        /// <summary>
        /// Get alert tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Alert tree response</returns>
        public List<AlertTreeResponseBody> GetAlertTree(string userName, string password)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var alertResponse = getAlertTreeDetailsAsync(userName, token);
            return alertResponse;
        }

        /// <summary>
        /// Get alert tree by giving token.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<AlertTreeResponseBody> GetAlertTree(string userName, string password, string token)
        {
            var alertResponse = getAlertTreeDetailsAsync(userName, token);
            return alertResponse;
        }
        /// <summary>
        /// Get alert details by alert id
        /// </summary>
        /// <param name="alertID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public AlertTreeResponseBody getAlertDetailsByAlertId(string alertID, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Alerts/{alertID}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AlertTreeResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Delete alerts by Id
        /// </summary>
        /// <param name="alertID"></param>
        /// <param name="token"></param>
        public void DeleteAlertsByCount(int alertID, string token)
        {
            //var requestBody = new DeleteAlerts();
            //requestBody.Property1 = new[] { alertID };
            var requestBody = new[] { alertID };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress + $"api/alerts/delete");
            request.Content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = ApiClient.SendAsync(request);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        #endregion

        #region Location APIs

        /// <summary>
        /// Get Location tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Location tree response</returns>
        public List<LocationTreeResponseBody> getLocationTreeDetailsAsync(string userName, string token)
        {
            var requestBody = new LoginBody();
            requestBody.userName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/locations/GetLocationsByUsername", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationTreeResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get Location tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Location tree</returns>
        public List<LocationTreeResponseBody> GetLocationTree(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = getLocationTreeDetailsAsync(userName, token);
            return locationResponse;
        }
        /// <summary>
        /// Get location group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationGroupsResponseBody> getLocationGroupDetailsAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Locations/Groups");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationGroupsResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get location groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<LocationGroupsResponseBody> GetLocationGroups(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = getLocationGroupDetailsAsync(userName, token);
            return locationResponse;
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody CreateNewLocationGroup(string userName, string token, string groupName)
        {
            var requestBody = new LocationGroupsResponseBody();
            requestBody.groupId = -1;
            requestBody.locationCount = 0;
            requestBody.groupName = groupName;
            requestBody.description = "Automation description";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/locations/groups", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationGroupsResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody CreateLocationGroup(string userName, string password, string groupName)
        {
            string token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = CreateNewLocationGroup(userName, token, groupName);
            return locationResponse;
        }

        /// <summary>
        /// Get location details by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody getLocationGroupDetailsByID(string token, string groupID)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Locations/Groups/{groupID}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationGroupsResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get location groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody GetLocationGroupByID(string userName, string password, string groupID, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = getLocationGroupDetailsByID(token, groupID);
            return locationResponse;
        }
        /// <summary>
        /// Edit location group Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody editLocationGroupDetailsByID(string token, int groupID, string groupName)
        {
            var requestBody = new LocationGroupsResponseBody();
            requestBody.groupId = groupID;
            requestBody.locationCount = 0;
            requestBody.groupName = groupName;
            requestBody.description = "Automation description edited";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Locations/Groups/{groupID}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationGroupsResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit location groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody EditLocationGroupByID(string userName, string password, int groupID, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = editLocationGroupDetailsByID(token, groupID, groupName);
            return locationResponse;
        }
        /// <summary>
        /// Delete Location group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteLocationGroupDetailsByID(string token, string groupID)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/Locations/Groups/{groupID}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get Location Types for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> getLocationTypeDetailsAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Locations/LocationTypes");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationTypesResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get location type details by page
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> getLocationTypeByPage(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Locations/LocationTypes/1/10");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationTypesResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get location types for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> GetLocationTypes(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = getLocationTypeDetailsAsync(userName, token);
            return locationResponse;
        }
        /// <summary>
        /// GetLocation types by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public LocationTypesBody getLocationTypeDetailsById(int typeId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Locations/LocationTypes/{typeId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationTypesBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get location types by type id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationTypesBody GetLocationTypebyID(string userName, string password, int typeId, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationTypeResponse = getLocationTypeDetailsById(typeId, token);
            return locationTypeResponse;
        }
        /// <summary>
        /// Create new location type
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody CreateNewLocationType(string token, string typeName)
        {
            var requestBody = new LocationTypesBody();
            requestBody.id = 0;
            requestBody.name = typeName;
            requestBody.description = "Automation description";
            requestBody.code = "Automation code";
            requestBody.toleranceMetres = 200;
            requestBody.replaceAddressWithLocationName = true;
            requestBody.duringVehicleOperatingHours = true;
            requestBody.priority = 0;
            requestBody.deleted = 0;
            requestBody.icon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K";
            requestBody.colorHex = "29B6F6";
            requestBody.optionLogOnly = false;
            requestBody.optionNotifyEntryExit = true;
            requestBody.optionNotifyOnEntry = false;
            requestBody.optionNotifyOnExit = false;
            requestBody.iconUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/locations/LocationType", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateLocationTypeResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Create new location type
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody CreateLocationType(string userName, string password, string typeName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = CreateNewLocationType(token, typeName);
            return locationResponse;
        }
        /// <summary>
        /// Get location type icons
        /// </summary>
        /// <param name="token"></param>
        public void GetLocationTypeIcon(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Locations/LocationTypes/Icons");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Edit Location type by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="typeID"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody editLocationTypeDetailsByID(string token, int typeID, string typeName)
        {
            var requestBody = new LocationTypesBody();
            requestBody.id = typeID;
            requestBody.name = typeName;
            requestBody.description = "Automation description edited";
            requestBody.code = "Automation code edited";
            requestBody.toleranceMetres = 100;
            requestBody.replaceAddressWithLocationName = false;
            requestBody.duringVehicleOperatingHours = false;
            requestBody.priority = 0;
            requestBody.deleted = 0;
            requestBody.icon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K";
            requestBody.colorHex = "29B6F6";
            requestBody.optionLogOnly = true;
            requestBody.optionNotifyEntryExit = false;
            requestBody.optionNotifyOnEntry = false;
            requestBody.optionNotifyOnExit = false;
            requestBody.iconUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/locations/LocationType", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateLocationTypeResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit location types by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody EditLocationTypeByID(string userName, string password, int typeId, string typeName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var locationResponse = editLocationTypeDetailsByID(token, typeId, typeName);
            return locationResponse;
        }


        public CreateLocationTypeResponseBody CreateNewLocation(string token, string locName, int groupId, int locTypeId)
        {
            var requestBody = new CreateLocationRequestBody();
            requestBody.featureData = new Featuredata();
            requestBody.featureData.geometry = new Geometry();
            requestBody.groupId = groupId;
            requestBody.groupName = "";
            requestBody.locationId = 0;
            requestBody.locationDescription = "Test Automation desc";
            requestBody.locationName = locName;
            requestBody.locationRadiusMeters = 100000;
            requestBody.locationTypeCode = "";
            requestBody.locationTypeName = "";
            requestBody.locationTypeId = locTypeId;
            requestBody.featureShape = 2;
            requestBody.featureData.geometry.type = "Point";
            requestBody.featureData.geometry.coordinates = new double[2] { 127.133789, -23.624395 };
            requestBody.featureData.type = "Feature";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Locations/CreateLocation", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateLocationTypeResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Get location details by search key
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<LocationSearchKeyResponseBody> GetLocationBySearchKeyword(string token, string searchKey)
        {
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Locations/GetLocations", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationSearchKeyResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get locationd grouped
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<LocationsGroupedResponseBody> GetLocationGroupedBySearchKeyword(string token, string searchKey)
        {
            var requestBody = new VehicleSearchBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.searchText = searchKey;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Locations/GetLocationsGrouped", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationsGroupedResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<LocationSearchKeyResponseBody> GetLocationGroupedWithFeatures(string token, string searchKey, int groupId)
        {
            var requestBody = new LocationsSearchRequestBody();
            requestBody.pageNumber = 1;
            requestBody.pageSize = 10;
            requestBody.searchText = searchKey;
            requestBody.groupId = groupId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Locations/GetLocationsInGroupWithFeatures", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationSearchKeyResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get Location details by group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTreeResponseBody> getLocationDetailsByGroupId(int groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + $"api/Locations/GetLocationsByGroupId?groupId={groupId}");
            var response = ApiClient.Send(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            var jsonString = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocationTreeResponseBody>>(jsonString.Result);
        }
        /// <summary>
        /// Get Location details by group and page
        /// </summary>
        /// <param name="token"></param>
        public LocationsWithGroupIdResponseBody GetLocationDetailsByGroupAndPage(int groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Locations/{groupId}/1/10");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationsWithGroupIdResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Add/ remove locations to/from group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void AddLocationsToGroup(string token, int groupId, int locId)
        {
            var requestBody = new AddLocaTionsToGroupRequestBody();
            requestBody.groupId = groupId;
            requestBody.locationIds = new[] { locId };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/locations/addlocationtogroup", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Update Location details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locName"></param>
        /// <param name="groupId"></param>
        /// <param name="locTypeId"></param>
        /// <param name="locId"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody EditLocationDetails(string token, string locName, int groupId, int locTypeId, int locId)
        {
            var requestBody = new CreateLocationRequestBody();
            requestBody.featureData = new Featuredata();
            requestBody.featureData.geometry = new Geometry();
            requestBody.featureData.properties = new Properties();
            requestBody.groupId = groupId;
            requestBody.groupName = "";
            requestBody.locationId = locId;
            requestBody.locationDescription = "Test Automation desc edited";
            requestBody.locationName = locName + "Edit";
            requestBody.locationRadiusMeters = 120000;
            requestBody.locationTypeCode = "";
            requestBody.locationTypeName = "";
            requestBody.locationTypeId = locTypeId;
            requestBody.featureShape = 2;
            requestBody.featureData.properties.locationRadius = 120000;
            requestBody.featureData.geometry.type = "Point";
            requestBody.featureData.geometry.coordinates = new double[2] { 127.133789, -23.624395 };
            requestBody.featureData.bbox = new double[4] { 127.133789, -23.624395, 127.133789, -23.624395 };
            requestBody.featureData.type = "Feature";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + "api/Locations/UpdateLocation", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateLocationTypeResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Get location details by location id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        /// <returns></returns>
        public LocationSearchKeyResponseBody GetLocationByLocationId(string token, int locId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Locations/{locId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationSearchKeyResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Delete locations by Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        public void DeleteMultipleLocationsById(string token, int locId1, int locId2)
        {
            var requestBody = new DeleteLocationRequestBody();
            requestBody.locationIds = new[] { locId1, locId2 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Locations/DeleteLocations", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Delete Location by Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        public void DeleteLocationsByID(string token, int locId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/Locations/{locId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// DeleteLocationTypesByID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locTypeId"></param>
        public void DeleteLocationsTypeByID(string token, int locTypeId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/Locations/LocationTypes/{locTypeId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Trips API
        /// <summary>
        /// Get trips list using unit ID
        /// </summary>
        /// <param name="vehicleUnitId"></param>
        /// <param name="isAssigned"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public TripsResponseBody getTripsAsync(int vehicleUnitId, bool isAssigned, string token)
        {
            var requestBody = new VehicleTripBody();
            requestBody.unitId = vehicleUnitId;
            requestBody.tripStartTime = DateTime.Now.AddDays(-88);
            requestBody.tripEndTime = DateTime.Now;
            requestBody.page = 1;
            requestBody.pageSize = 10;
            requestBody.isAssignedTrip = isAssigned;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/trips/GetTrips", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TripsResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Get trip list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleUnitId"></param>
        /// <param name="isAssigned"></param>
        /// <returns></returns>
        public TripsResponseBody GetTripList(string userName, string password, int vehicleUnitId, bool isAssigned, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var tripResponse = getTripsAsync(vehicleUnitId, isAssigned, token);
            return tripResponse;
        }
        /// <summary>
        /// Get Single trip details
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="isAssigned"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public SingleTripResponseBody getSingleTripAsync(int tripId, string token, DateTime startDate, int driverId)
        {
            ApiClient = new HttpClient();
            var requestBody = new SingleTriprequestBody();
            requestBody.driverId = driverId;
            requestBody.startDate = startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");
            requestBody.tripId = tripId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/trips", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SingleTripResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit Single trip details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tripId"></param>
        public void EditSingleTripDetails(string token, UpdateTripRequest requestBody)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Trips", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Edit multiple trip details
        /// </summary>

        public void EditMultipleTripDetails(string token, UpdateTripRequest[] requestBody)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/trips/UpdateMultipleTrips", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Alarms API
        /// <summary>
        /// Clear Alarm API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <param name="clearAlarmBody"></param>
        /// <returns></returns>
        public ClearAlarmResponseBody ClearAlarmbyUserName(string token, ClearAlarmBody clearAlarmBody)
        {
            ApiClient = new HttpClient();
            var requestBody = new ClearAlarmBody();
            requestBody = clearAlarmBody;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/alarms/ClearAlarm", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClearAlarmResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Provides the clear alarm response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="clearAlarmBody"></param>
        /// <returns></returns>
        public ClearAlarmResponseBody ClearAlarmAPI(string userName, string password, ClearAlarmBody clearAlarmBody, string token)
        {
            var clearAlarmResponse = ClearAlarmbyUserName(token, clearAlarmBody);
            return clearAlarmResponse;
        }

        #endregion

        #region Contacts API
        /// <summary>
        /// New contact API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody CreateNewContactGroup(string userName, string token, string groupName)
        {
            var requestBody = new ContactGroupRequestBody();
            requestBody.shortName = groupName;
            requestBody.fullName = groupName;
            requestBody.comments = "Test automation comments";
            requestBody.deleted = false;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/ContactGroups", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ContactGroupResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Create new contact group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody CreateContactGroup(string userName, string password, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactResponse = CreateNewContactGroup(userName, token, groupName);
            return contactResponse;
        }
        /// <summary>
        /// Get contact group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ContactGroupDetailsResponseBody> getContactGroupAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/ContactGroups");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ContactGroupDetailsResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get contact groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<ContactGroupDetailsResponseBody> GetContactGroups(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactResponse = getContactGroupAsync(userName, token);
            return contactResponse;
        }

        /// <summary>
        /// Get contact group usage details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string getContactGroupUsageAsync(string groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"/api/ContactGroups/ContactGroupUsages/{groupId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return jsonString.Result;
            ApiClient.Dispose();
        }
        /// <summary>
        /// Delete contact group usage details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string deleteContactGroupUsageAsync(string groupId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"/api/ContactGroups/ContactGroupUsages/{groupId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return jsonString.Result;
            ApiClient.Dispose();
        }

        /// <summary>
        /// Edit contact group Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody editContactGroupDetailsByID(string token, int groupID, string groupName)
        {
            var requestBody = new EditContactGroupRequestBody();
            requestBody.contactGroupId = groupID;
            requestBody.fullName = groupName;
            requestBody.shortName = groupName;
            requestBody.comments = "Automation description edited";
            requestBody.deleted = false;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/ContactGroups", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ContactGroupResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit contact groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ContactGroupResponseBody EditContactGroupByID(string userName, string password, int groupID, string groupName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var contactResponse = editContactGroupDetailsByID(token, groupID, groupName);
            return contactResponse;
        }
        /// <summary>
        /// Delete contact group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteContactGroupDetailsByID(string token, string groupID)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/ContactGroups/{groupID}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }


        #endregion

        #region Roles API

        /// <summary>
        /// New Roles API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RolesResponseBody CreateNewRole(string userName, string token, string roleName)
        {
            var requestBody = new RolesCreationRequestBody();
            requestBody.userName = userName;
            requestBody.roleName = roleName;
            requestBody.roleDescription = "Test automation description";
            requestBody.defaultRole = true;
            requestBody.reportList = new int[] { 830, 415 };
            requestBody.accessRights = new int[] { 12, 82, 29, 27, 52, 30, 28, 60, 61, 35, 71, 46, 47, 3, 64, 58, 57, 56, 38, 44, 70, 45, 5, 53, 89, 90 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Roles", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RolesResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Create new role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RolesResponseBody CreateNewRoleForUser(string userName, string password, string roleName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var roleResponse = CreateNewRole(userName, token, roleName);
            return roleResponse;
        }
        /// <summary>
        /// Get roles list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<RolesListResponseBody> getRolesListAsync(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/roles");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RolesListResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get roles listed for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<RolesListResponseBody> GetRoles(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var rolesResponse = getRolesListAsync(userName, token);
            return rolesResponse;
        }
        /// <summary>
        /// Edit role name Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public void editRoleNameDetailsByID(string token, string userName, string roleID, string roleName)
        {
            var requestBody = new EditRoleNameRequestBody();
            requestBody.roleName = roleName;
            requestBody.userName = userName;
            requestBody.roleDescription = "Automation description edited";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/roles/UpdateRoleName/{roleID}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit roleName by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void EditRoleNameByID(string userName, string password, string roleID, string roleName, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            editRoleNameDetailsByID(token, userName, roleID, roleName);
        }
        /// <summary>
        /// Edit role rights Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public void editRoleRightsDetailsByID(string token, string userName, string roleID)
        {
            var requestBody = new EditRoleRightsRequestBody();
            requestBody.userName = userName;
            requestBody.defaultRole = true;
            requestBody.accessRights = new int[] { 12, 82, 29, 27, 52, 30 };
            requestBody.reportList = new int[] { 830, 415, 303 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/roles/UpdateRoleRights/{roleID}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit role Rights by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void EditRoleRightsByID(string userName, string password, string roleID, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            editRoleRightsDetailsByID(token, userName, roleID);
        }

        /// <summary>
        /// Delete roles 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> DeleteRolesAsync(string roleId, string userName, string token)
        {
            var requestBody = new VehicleTreeBody();
            requestBody.UserName = userName;
            requestBody.forManagement = true;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress + $"/api/roles/{roleId}");
            request.Content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var response = await ApiClient.SendAsync(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            var jsonString = response.Content.ReadAsStringAsync();
            return jsonString.Result;
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get user access rights
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public void getUserAccessRights(string userName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/Roles/GetUserAccessRights");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }

        #endregion

        #region Zoom Preset API

        /// <summary>
        /// Get zoom preset details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ZoomPresetResponseBody getZoomPresetAsync(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/ZoomPresets");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ZoomPresetResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get zoom preset for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ZoomPresetResponseBody getZoomPreset(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var response = getZoomPresetAsync(token);
            return response;
        }
        /// <summary>
        /// Create New Zoom preset
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public void CreateNewZoomPreset(string userName, string token, string presetName)
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


        #endregion

        #region Map Settings API
        /// <summary>
        /// Create map Settings
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public void CreateNewMapSetting(string parameterName, string value, string token)
        {
            var requestBody = new MapSettingsRequestBody();
            requestBody.name = parameterName;
            requestBody.value = value;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/mapsettings", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
        }

        /// <summary>
        /// Get Map settings details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public MapSettingsResponseBody getMapSettingsAsync(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/MapSettings");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MapSettingsResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get map settings for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MapSettingsResponseBody getMapSettings(string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var response = getMapSettingsAsync(token);
            return response;
        }

        #endregion

        #region Operational Hours API

        /// <summary>
        /// Create Operational Hours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public CreateOHResponseBody CreateNewOperationalHours(string name, string token)
        {
            var requestBody = new OperationalHoursResponseBody();
            requestBody.name = name;
            requestBody.description = "Test Automation description";
            requestBody.monday = true;
            requestBody.mondayStart = 540;
            requestBody.mondayStop = 1080;
            requestBody.tuesday = false;
            requestBody.tuesdayStart = 0;
            requestBody.tuesdayStop = 0;
            requestBody.wednesday = true;
            requestBody.wednesdayStart = 540;
            requestBody.wednesdayStop = 1080;
            requestBody.thursday = false;
            requestBody.thursdayStart = 0;
            requestBody.thursdayStop = 0;
            requestBody.friday = true;
            requestBody.fridayStart = 540;
            requestBody.fridayStop = 1080;
            requestBody.saturday = false;
            requestBody.saturdayStart = 0;
            requestBody.saturdayStop = 0;
            requestBody.sunday = false;
            requestBody.sundayStart = 0;
            requestBody.sundayStop = 0;
            requestBody.timeZone = "AUS Eastern Standard Time";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/operationalHours/CreateOperatingHours", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateOHResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Get Operational hours
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<OperationalHoursResponseBody> getOperationalHoursAsync(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + "api/operationalHours");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OperationalHoursResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Edit Operational Hours
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="presetName"></param>
        public CreateOHResponseBody EditOperationalHours(string name, string id, string token)
        {
            var requestBody = new OperationalHoursResponseBody();
            requestBody.name = name;
            requestBody.opHoursId = Convert.ToInt32(id);
            requestBody.description = "Automation description Edited";
            requestBody.monday = false;
            requestBody.mondayStart = 0;
            requestBody.mondayStop = 0;
            requestBody.tuesday = true;
            requestBody.tuesdayStart = 540;
            requestBody.tuesdayStop = 1080;
            requestBody.wednesday = false;
            requestBody.wednesdayStart = 0;
            requestBody.wednesdayStop = 0;
            requestBody.thursday = true;
            requestBody.thursdayStart = 540;
            requestBody.thursdayStop = 1080;
            requestBody.friday = false;
            requestBody.fridayStart = 0;
            requestBody.fridayStop = 0;
            requestBody.saturday = true;
            requestBody.saturdayStart = 540;
            requestBody.saturdayStop = 1080;
            requestBody.sunday = false;
            requestBody.sundayStart = 0;
            requestBody.sundayStop = 0;
            requestBody.timeZone = "Cen. Australia Standard Time";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + "api/operationalHours/UpdateOperatingHour", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateOHResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Delete Operational Hours
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteOperationalHoursByID(string id, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/OperationalHours/{id}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        #endregion

        #region Clients API
        /// <summary>
        /// Create New client
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ClientName"></param>
        /// <returns></returns>
        public ClientTreeResponseBody CreateNewClient(string token, string clientName)
        {
            var requestBody = new CreateClientRequestBody();
            requestBody.client = new Client();
            requestBody.client.address1 = "";
            requestBody.client.address2 = "";
            requestBody.client.clientFullName = "";
            requestBody.client.email2 = "";
            requestBody.client.phone2 = "";
            requestBody.client.position = "";
            requestBody.client.preferredName = "";
            requestBody.client.clientId = 0;
            requestBody.client.clientName = clientName;
            requestBody.client.clientPassword = "qwertY@@456";
            requestBody.client.clientRole = 242;
            requestBody.client.firstName = "Test";
            requestBody.client.middleName = "";
            requestBody.client.lastName = "Automation";
            requestBody.client.phone1 = "61132456";
            requestBody.client.email1 = "testclientAut" + DateTime.Now.ToString("dd") + "@gtail.com"; ;
            requestBody.client.notes = "Test Auto notes";
            requestBody.driverGroupIds = new[] { 244, 244 };
            //requestBody.driverIds = new int[] { };
            // requestBody.unitIds = new int[] { };
            requestBody.vehicleGroupIds = new[] { 388 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + "api/Clients/NewClient", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClientTreeResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Get Clients by User Name
        /// </summary>
        /// <param name="client"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ClientByUsernameResponseBody> getClientByUsername(string userName, string token)
        {
            var requestBody = new VehicleTreeBody();
            requestBody.UserName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Clients/GetClientsByUserName", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClientByUsernameResponseBody>>(jsonString.Result);
        }
        public ClientGroupedResponseBody getClientVehicleDriverGrouped(int clientId, string token)
        {
            var requestBody = new ClientIdRequestBody();
            requestBody.clientId = clientId;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Clients/GetClientVehiclesAndDriversGrouped", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClientGroupedResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit Client Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public ClientTreeResponseBody EditClient(string token, int clientId, string clientName)
        {
            var requestBody = new CreateClientRequestBody();
            requestBody.client = new Client();
            requestBody.client.address1 = "";
            requestBody.client.address2 = "";
            requestBody.client.clientFullName = "";
            requestBody.client.email2 = "";
            requestBody.client.phone2 = "";
            requestBody.client.position = "";
            requestBody.client.preferredName = "";
            requestBody.client.clientId = clientId;
            requestBody.client.clientName = clientName + "Edit";
            requestBody.client.phone1 = "61222222";
            requestBody.client.email1 = "testclientAutEdit" + DateTime.Now.ToString("dd") + "@gtail.com";
            requestBody.client.notes = "Test Auto notes edited";
            requestBody.client.clientPassword = "Autopassord@123";
            requestBody.client.clientRole = 328;
            requestBody.client.firstName = "TestEdit";
            requestBody.client.middleName = "";
            requestBody.client.lastName = "AutomationEdit";
            requestBody.driverGroupIds = new[] { 244, 244 };
            //requestBody.driverIds = new int[] { };
            // requestBody.unitIds = new int[] { };
            requestBody.vehicleGroupIds = new[] { 388 };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + "api/Clients/UpdateClient", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClientTreeResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Suppress alerts by client Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void SuppressAlertsByClientId(string token, int clientId)
        {
            var requestBody = new SuppressAlertsRequestBody();
            requestBody.clientId = clientId;
            requestBody.suppressAlerts = true;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Clients/UpdateSignalRAlertNotification", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Suppress alarms by client Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void SuppressAlarmsByClientId(string token, int clientId)
        {
            var requestBody = new SuppressAlarmsRequestBody();
            requestBody.clientId = clientId;
            requestBody.suppressAlarms = true;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Clients/UpdateSignalRAlarmNotification", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// UpdateAccountLockoutByClientId
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void UpdateAccountLockoutByClientId(string token, int clientId, int Value)
        {
            var requestBody = new AccountLockedRequestBody();
            requestBody.clientId = clientId;
            requestBody.isAccountLocked = Value;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/Clients/UpdateAccountLockout", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Get Client Details By ID
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClientTreeResponseBody GetClientDetailsByID(int clientId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Clients/{clientId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClientTreeResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Update Password after login
        /// </summary>
        /// <param name="token"></param>
        /// <param name="password"></param>
        public void UpdatePasswordForLoggedinUser(string token, string password)
        {
            var requestBody = new UpdatePasswordRequestBody();
            requestBody.password = password;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Clients/UpdatePassword", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Initial script for new user
        /// </summary>
        /// <param name="token"></param>
        /// <param name="password"></param>
        public void InitialScriptRequest(string token)
        {
            var requestBody = new ClientInitialScriptRequestBody();
            requestBody.locationTypeIcon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+ DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K";
            requestBody.locationTypeIocnUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Clients/InitialScript", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteClientByID(string token, int clientId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/Clients/{clientId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        #endregion

        #region User Settings API
        /// <summary>
        /// Get User Settings details
        /// </summary>
        /// <param name="settingsName">W4_LAST_MAP_EXTENT</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public UserSettingsResponseBody GetUserSettingsBySettingsName(string settingsName, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Users?settingName={settingsName}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserSettingsResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Save user settings
        /// </summary>
        /// <param name="token"></param>
        public void SaveUserSettings(string token)
        {
            var requestBody = new UserSettingsSaveRequest();
            requestBody.settingName = "W4_VEHICLE_TREE_CHECKEDSTATES";
            requestBody.settingValue = "{\"checkedEntityIds\":2727}";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Users", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Services
        /// <summary>
        /// Get Service By ID
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ServicesResponseBody GetServiceById(int serviceId, string userName, string token)
        {
            var requestBody = new GetServiceByIdRequest();
            requestBody.serviceId = serviceId;
            requestBody.userName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Services/GetServiceById", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServicesResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Get Last Service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceByUserNameResponseBody> GetLastServiceDetailsByID(int vehicleId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Services/GetLastService/{vehicleId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServiceByUserNameResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get Service details by username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServicesResponseBody> GetServiceDetailsByUserName(string userName, int vehicleId, string token)
        {
            var requestBody = new GetServicesByUserNameRequest();
            requestBody.unitId = vehicleId;
            requestBody.userName = userName;
            requestBody.pageSize = 10;
            requestBody.pageNumber = 1;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/Services/GetServices", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServicesResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Create new service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateServiceResponseBody CreateNewService(int vehicleId, string userName, string token)
        {
            var requestBody = new CreateServiceRequestBody();
            requestBody.cost = 1000;
            requestBody.engineHours = 12345;
            requestBody.notes = "Test Automation notes";
            requestBody.odometer = 4444;
            requestBody.serviceType = 0;
            requestBody.serviceDate = DateTime.UtcNow.AddDays(-2).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.unitId = vehicleId;
            requestBody.userName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/services", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateServiceResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Edit service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateServiceResponseBody EditServiceDetails(int vehicleId, int serviceId, string userName, string token)
        {
            var requestBody = new CreateServiceRequestBody();
            requestBody.cost = 2000;
            requestBody.engineHours = 54321;
            requestBody.notes = "Test Automation notes edited";
            requestBody.odometer = 5555;
            requestBody.serviceType = 1;
            requestBody.serviceDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody.unitId = vehicleId;
            requestBody.userName = userName;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/services/{serviceId}", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateServiceResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Delete Service By ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="serviceId"></param>
        public void DeleteServicesByID(string token, int serviceId)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.DeleteAsync(baseAddress + $"api/Services/{serviceId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get Service Type details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceTypeResponseBody> GetServiceTypeByUserName(string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Services/ServiceTypes");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServiceTypeResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        /// <summary>
        /// Get Service Readings
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ServiceReadingResponseBody GetServicereadingbyId(int serviceId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/Services/ServiceReading/{serviceId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceReadingResponseBody>(jsonString.Result);
            ApiClient.Dispose();
        }

        #endregion

        #region Service Schedules


        /// <summary>
        /// Create service schedule for all tabs
        /// We wont be using this as this can be run only once for a vehicle (we dont have the option to create ne vehicle)
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ServiceScheduleResponseBody CreateNewMultipleServiceSchedule(string token)
        {
            var requestBody1 = new ServiceScheduleRequestBody();
            var requestBody2 = new ServiceScheduleRequestBody();
            var requestBody3 = new ServiceScheduleRequestBody();
            var requestBody = new ServiceScheduleRequestBody[3] { requestBody1, requestBody2, requestBody3 };
            requestBody1.contactId = 474;
            requestBody1.contactName = "Automation Group";
            requestBody1.enabled = true;
            requestBody1.interval = 20;
            requestBody1.intervalEngineHours = -1;
            requestBody1.intervalKm = 1;
            requestBody1.notes = "Test Automation major";
            requestBody1.reminder = 2;
            requestBody1.reminderEngineHours = -1;
            requestBody1.reminderKm = 1;
            requestBody1.reminderSentEngineHours = -1;
            requestBody1.scheduleId = -1;
            requestBody1.serviceType = 1;
            requestBody1.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody1.startEngineHours = 54321;
            requestBody1.startOdometer = 5555;
            requestBody1.trackerId = 10655;

            requestBody2.contactId = 474;
            requestBody2.contactName = "Automation Group";
            requestBody2.enabled = true;
            requestBody2.interval = 30;
            requestBody2.intervalEngineHours = -1;
            requestBody2.intervalKm = 2;
            requestBody2.notes = "Test Automation normal";
            requestBody2.reminder = 2;
            requestBody2.reminderEngineHours = -1;
            requestBody2.reminderKm = 1;
            requestBody2.reminderSentEngineHours = -1;
            requestBody2.scheduleId = -1;
            requestBody2.serviceType = 2;
            requestBody2.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody2.startEngineHours = 54321;
            requestBody2.startOdometer = 5555;
            requestBody2.trackerId = 10655;

            requestBody3.contactId = 474;
            requestBody3.contactName = "Automation Group";
            requestBody3.enabled = true;
            requestBody3.interval = 40;
            requestBody3.intervalEngineHours = -1;
            requestBody3.intervalKm = 3;
            requestBody3.notes = "Test Automation minor";
            requestBody3.reminder = 2;
            requestBody3.reminderEngineHours = -1;
            requestBody3.reminderKm = 1;
            requestBody3.reminderSentEngineHours = -1;
            requestBody3.scheduleId = -1;
            requestBody3.serviceType = 3;
            requestBody3.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody3.startEngineHours = 54321;
            requestBody3.startOdometer = 5555;
            requestBody3.trackerId = 10655;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddress + $"api/ServiceSchedule/SaveServiceScheduleList", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceScheduleResponseBody>(jsonString.Result);
        }

        /// <summary>
        /// Edit multiple service schedules
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceScheduleResponseBody> EditMultipleServiceScheduleDetails(string token)
        {
            var requestBody1 = new ServiceScheduleRequestBody();
            var requestBody2 = new ServiceScheduleRequestBody();
            var requestBody3 = new ServiceScheduleRequestBody();
            var requestBody = new ServiceScheduleRequestBody[3] { requestBody1, requestBody2, requestBody3 };
            requestBody1.contactId = 474;
            requestBody1.contactName = "Automation Group";
            requestBody1.enabled = true;
            requestBody1.interval = 20;
            requestBody1.intervalEngineHours = -1;
            requestBody1.intervalKm = 1;
            requestBody1.notes = "Test Automation major";
            requestBody1.reminder = 2;
            requestBody1.reminderEngineHours = -1;
            requestBody1.reminderKm = 1;
            requestBody1.reminderSentEngineHours = -1;
            requestBody1.scheduleId = 506;
            requestBody1.serviceType = 1;
            requestBody1.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody1.startEngineHours = 54321;
            requestBody1.startOdometer = 5555;
            requestBody1.trackerId = 10655;

            requestBody2.contactId = 474;
            requestBody2.contactName = "Automation Group";
            requestBody2.enabled = true;
            requestBody2.interval = 30;
            requestBody2.intervalEngineHours = -1;
            requestBody2.intervalKm = 2;
            requestBody2.notes = "Test Automation normal";
            requestBody2.reminder = 2;
            requestBody2.reminderEngineHours = -1;
            requestBody2.reminderKm = 1;
            requestBody2.reminderSentEngineHours = -1;
            requestBody2.scheduleId = 507;
            requestBody2.serviceType = 2;
            requestBody2.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody2.startEngineHours = 54321;
            requestBody2.startOdometer = 5555;
            requestBody2.trackerId = 10655;

            requestBody3.contactId = 474;
            requestBody3.contactName = "Automation Group";
            requestBody3.enabled = true;
            requestBody3.interval = 40;
            requestBody3.intervalEngineHours = -1;
            requestBody3.intervalKm = 3;
            requestBody3.notes = "Test Automation minor";
            requestBody3.reminder = 2;
            requestBody3.reminderEngineHours = -1;
            requestBody3.reminderKm = 1;
            requestBody3.reminderSentEngineHours = -1;
            requestBody3.scheduleId = 508;
            requestBody3.serviceType = 3;
            requestBody3.startDate = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            requestBody3.startEngineHours = 54321;
            requestBody3.startOdometer = 5555;
            requestBody3.trackerId = 10655;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PutAsync(baseAddress + $"api/ServiceSchedule/UpdateServiceScheduleList", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServiceScheduleResponseBody>>(jsonString.Result);
        }

        /// <summary>
        /// Get Service schedule list
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceScheduleListResponseBody> GetServiceSchedulelist(int vehicleId, string token)
        {
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.GetAsync(baseAddress + $"api/ServiceSchedule/GetServiceScheduleByUnitId?unitId={vehicleId}");
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ServiceScheduleListResponseBody>>(jsonString.Result);
            ApiClient.Dispose();
        }
        #endregion

        #region Reports
        /// <summary>
        /// Get DB response
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public DriverBehaviourResponseBody GenerateDriverBehaviourReport(DriverBehaviourRequestBody requestBody, string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddressReport + $"api/v1.0/reports/Report", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DriverBehaviourResponseBody>(jsonString.Result);
        }
        /// <summary>
        /// Get SAL Response
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public StoppedAtLocResponseBody GenerateSALReport(SALRequestBody requestBody, string userName, string password, string token = "")
        {
            if (token == "")
                token = getBearerTokenAsync(userName, password).Result.ToString().Replace("\"", "");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = ApiClient.PostAsync(baseAddressReport + $"api/v1.0/reports/Report", data);
            Assert.IsTrue(response.Result.IsSuccessStatusCode);
            var jsonString = response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StoppedAtLocResponseBody>(jsonString.Result);
        }

        #endregion


    }
}
