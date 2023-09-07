using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.DriversAPI
{
    public class DriversAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public DriversRequestBody driversRequestBody;

        #endregion
        public DriversAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            driversRequestBody = new DriversRequestBody();
        }
        /// <summary>
        /// Get driver tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Driver tree response</returns>
        public List<DriverTreeResponseBody> getDriverTreeDetailsAsync(string token)
        {
           
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.vehicletreeBody);
            var requestBody = new VehicleTreeBody();
            var url = SetUrl(aPIRequestURLs.getDriversByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent< List<DriverTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get driver tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Driver tree response</returns>
        public List<DriverTreeResponseBody> GetDriverTree(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDriversByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<DriverTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get right panel details for drivers
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="driverId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public DriverRightPanelResponseBody getDriverRightPanelDetailsAsync(string token)
        {
            var requestBody = new VehicleStatusBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.vehiclestatusBody);
            var url = SetUrl(aPIRequestURLs.getvehiclestatusbyusername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DriverRightPanelResponseBody>(response);
        }
        /// <summary>
        /// Get driver Right panel.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public DriverRightPanelResponseBody GetDriverRightPanel(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDriversByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DriverRightPanelResponseBody>(response);
        }
        /// <summary>
        /// Create new driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverGroupBody CreateNewDriverGroup(string token)
        {
            var requestBody = new DriverGroupsResponsebody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.Drivergroupsresponsebody);
            var url = SetUrl(aPIRequestURLs.driverGroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverGroupBody>(response);
        }
        /// <summary>
        /// Create new driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverGroupBody CreateDriverGroup(string token)
        {
            var request = CreatePostRequest(token);
            var url = SetUrl(aPIRequestURLs.driverGroups);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverGroupBody>(response);
        }
        /// <summary>
        /// Get Driver groups
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<DriverGroupsResponsebody> getDriverGroupsAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDriverGroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<DriverGroupsResponsebody>>(response);
        }
        /// <summary>
        /// Get driver groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<DriverGroupsResponsebody> GetDriverGroups(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDriverGroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<DriverGroupsResponsebody>>(response);
        }
        /// <summary>
        /// Create new driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public CreateDriverResponsebody CreateNewDriver(string token)
        {
            var requestBody = new CreateDriverBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.createDriverBody);
            var url = SetUrl(aPIRequestURLs.createdriver);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverResponsebody>(response);
        }
        /// <summary>
        /// Create new driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverResponsebody CreateDriver(string token)
        {
            var url = SetUrl(aPIRequestURLs.createdriver);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverResponsebody>(response);
        }
        /// <summary>
        /// Get driver details by search text
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<DriverTreeResponseBody> GetDriverInfoBySearchKeyword(string token)
        {
            var requestBody = new VehicleSearchBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.vehiclesearchBody);
            var url = SetUrl(aPIRequestURLs.getDrivers);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<DriverTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get driver grouped info by search text
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<DriverGroupedResponseBody> GetDriverGroupedInfoBySearchKeyword(string token)
        {
            var requestBody = new VehicleSearchBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.vehicleSearchBody);
            var url = SetUrl(aPIRequestURLs.getDriversGrouped);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<DriverGroupedResponseBody>>(response);
        }
        /// <summary>
        /// Get Driver By group Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public DriverByGroupIdResponseBody getDriverByGroupID(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDriversByGroupID);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DriverByGroupIdResponseBody>(response);
        }
        /// <summary>
        /// Assign Unassign To Driver
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        /// <param name="unitId"></param>
        public void AssignVehicleToDriver(string token)
        {
            var requestBody = new AssignDriverRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.assignDriverRequestBody);
            var url = SetUrl(aPIRequestURLs.assignVehicleToDriver);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
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
        public CreateDriverResponsebody EditDriverDetails(string token)
        {
            var requestBody = new EditDriverBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.editdriverBody);
            var url = SetUrl(aPIRequestURLs.updatedriver);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverResponsebody>(response);
        }
        /// <summary>
        /// Edit driver
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateDriverResponsebody EditDriver(string token)
        {
            var url = SetUrl(aPIRequestURLs.updatedriver);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverResponsebody>(response);
        }
        /// <summary>
        /// Get Driver by Id
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public GetDriverByIdResponseBody getDriverByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.DriversdriverId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<GetDriverByIdResponseBody>(response);
        }
        /// <summary>
        /// Assign Drivers to group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        /// <param name="groupId"></param>
        public void AssignDriverToGroup(string token)
        {
            var requestBody = new AssignDriversToGrpRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.assignDriversToGrpRequestBody);
            var url = SetUrl(aPIRequestURLs.assignDriverstogroup);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Delete Drivers
        /// </summary>
        /// <param name="token"></param>
        /// <param name="driverId"></param>
        public void DeleteDrivers(string token)
        {
            var requestBody = new DeleteDriversRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.deleteDriversRequestBody);
            var url = SetUrl(aPIRequestURLs.deleteDrivers);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Edit driver group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public DriverGroupsResponsebody EditDriverGroupDetails(string token)
        {
            var requestBody = new EditVehicleGroupBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(driversRequestBody.deleteDriversRequestBody);
            var url = SetUrl(aPIRequestURLs.DriversGroupsgroupID);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DriverGroupsResponsebody>(response);
        }
        /// <summary>
        /// Edit driver group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public DriverGroupsResponsebody EditDriverGroup(string token)
        {
            var url = SetUrl(aPIRequestURLs.DriversGroupsgroupID);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<DriverGroupsResponsebody>(response);
        }
        /// <summary>
        /// Get Driver group by ID
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateDriverGroupBody getDriverGroupByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.getDrivergroupBygroupID);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateDriverGroupBody>(response);
        }
        /// <summary>
        /// Delete Driver Group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteDriverGroupByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.DriversgroupsGroupID);
            var request = CreateDeleteRequest(token);

        }
}
