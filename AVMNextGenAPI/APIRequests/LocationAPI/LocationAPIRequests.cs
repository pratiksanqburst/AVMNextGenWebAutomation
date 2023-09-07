using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.LocationAPI
{
    public class LocationAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public LocationRequestBody locationRequestBody;

        #endregion
        public APIRequestURLs apIRequestURLs;
        public LocationRequestBody locationrequestBody;
        public LocationAPIRequests()
        {
            apIRequestURLs = new APIRequestURLs();
            locationrequestBody = new LocationRequestBody();
        }
        
        /// <summary>
        /// Get Location tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns>Location tree response</returns>
        public List<LocationTreeResponseBody> getLocationTreeDetailsAsync(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.LoginrequestBody);
            var requestBody = new LoginBody();
            var url = SetUrl(apIRequestURLs.getLocationsByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get Location tree response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Location tree</returns>
        public List<LocationTreeResponseBody> GetLocationTree(string token )
        {
            var url = SetUrl(apIRequestURLs.getLocationsByUsername);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get location group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationGroupsResponseBody> getLocationGroupDetailsAsync(string token)
        {
            var url = SetUrl(apIRequestURLs.LocationGroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationGroupsResponseBody>>(response);
        }
        /// <summary>
        /// Get location groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<LocationGroupsResponseBody> GetLocationGroups(string token)
        {
            var url = SetUrl(apIRequestURLs.LocationGroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationGroupsResponseBody>>(response);
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody CreateNewLocationGroup(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.LocationGroupsRequestBody);
            var requestBody = new LocationGroupsResponseBody();
            var url = SetUrl(aPIRequestURLs.Locationgroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }
        /// <summary>
        /// Create new location group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody CreateLocationGroup(string token)///check again..repeating api
        {
            var url = SetUrl(apIRequestURLs.Locationgroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }

        /// <summary>
        /// Get location details by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody getLocationGroupDetailsByID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationGroupId);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }
        /// <summary>
        /// Get location groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody GetLocationGroupByID(string token)//check again..
        {
            var url = SetUrl(apIRequestURLs.locationGroupId);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }
        /// <summary>
        /// Edit location group Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody editLocationGroupDetailsByID(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.LocationGroupsRequestBody);
            var requestBody = new LocationGroupsResponseBody();
            var url = SetUrl(apIRequestURLs.locationGroupId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }
        /// <summary>
        /// Edit location groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationGroupsResponseBody EditLocationGroupByID(string token)//check again..
        {
            var url = SetUrl(apIRequestURLs.locationGroupId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationGroupsResponseBody>(response);
        }
        /// <summary>
        /// Delete Location group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteLocationGroupDetailsByID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationGroupId);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Get Location Types for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> getLocationTypeDetailsAsync(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypes);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTypesResponseBody>>(response);
        }
        /// <summary>
        /// Get location type details by page
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> getLocationTypeByPage(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypes1);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTypesResponseBody>>(response);
        }
        /// <summary>
        /// Get location types for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<LocationTypesResponseBody> GetLocationTypes(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypes1);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTypesResponseBody>>(response);
        }
        /// <summary>
        /// GetLocation types by Id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public LocationTypesBody getLocationTypeDetailsById(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypeId);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationTypesBody>(response);
        }
        /// <summary>
        /// Get location types by type id
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LocationTypesBody GetLocationTypebyID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypeId);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationTypesBody>(response);
        }
        /// <summary>
        /// Create new location type
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody CreateNewLocationType(string token)
        {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.LocationTypesRequestBody);
            var requestBody = new LocationTypesBody();
            var url = SetUrl(apIRequestURLs.locationType);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
        }
        /// <summary>
        /// Create new location type
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody CreateLocationType(string token)
        {
            var url = SetUrl(apIRequestURLs.locationType);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
        }
        /// <summary>
        /// Get location type icons
        /// </summary>
        /// <param name="token"></param>
        public void GetLocationTypeIcon(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypesIcon);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            
        }
        /// <summary>
        /// Edit Location type by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="typeID"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody editLocationTypeDetailsByID(string token)
        {
            var requestBody = new LocationTypesBody();
            var url = SetUrl(apIRequestURLs.locationType);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
        }
        /// <summary>
        /// Edit location types by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CreateLocationTypeResponseBody EditLocationTypeByID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationType);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
        }


        public CreateLocationTypeResponseBody CreateNewLocation(string token)
        {
            var requestBody = new CreateLocationRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.createLocationRequestBody);
            var url = SetUrl(apIRequestURLs.createLocation);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
         
        }

        /// <summary>
        /// Get location details by search key
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<LocationSearchKeyResponseBody> GetLocationBySearchKeyword(string token)
        {
            var requestBody = new VehicleSearchBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.VehicleSearchRequestBody);
            var url = SetUrl(apIRequestURLs.getLocations);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationSearchKeyResponseBody>>(response);
        }
        /// <summary>
        /// Get locationd grouped
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<LocationsGroupedResponseBody> GetLocationGroupedBySearchKeyword(string token)
        {
            var requestBody = new VehicleSearchBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.VehicleSearchrequestBody);
            var url = SetUrl(apIRequestURLs.getLocationsGrouped);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationsGroupedResponseBody>>(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="searchKey"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<LocationSearchKeyResponseBody> GetLocationGroupedWithFeatures(string token)
        {
            var requestBody = new LocationsSearchRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.LocationsSearchrequestBody);
            var url = SetUrl(apIRequestURLs.getLocationInGroupWithFeatures);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationSearchKeyResponseBody>>(response);
        }
        /// <summary>
        /// Get Location details by group id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<LocationTreeResponseBody> getLocationDetailsByGroupId(string token)
        {
            var url = SetUrl(apIRequestURLs.getLocationGroupIdGroup);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<LocationTreeResponseBody>>(response);
        }
        /// <summary>
        /// Get Location details by group and page
        /// </summary>
        /// <param name="token"></param>
        public LocationsWithGroupIdResponseBody GetLocationDetailsByGroupAndPage(string token)
        {
            var url = SetUrl(apIRequestURLs.getLocationgroupId1);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationsWithGroupIdResponseBody>(response);
        }
        /// <summary>
        /// Add/ remove locations to/from group
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public void AddLocationsToGroup(string token)
        {
            var requestBody = new AddLocaTionsToGroupRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.AddLocaTionsToGrouprequestBody);
            var url = SetUrl(apIRequestURLs.Addlocationgroup);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
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
        public CreateLocationTypeResponseBody EditLocationDetails(string token)
        {
            var requestBody = new CreateLocationRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.CreatelocationrequestBody);
            var url = SetUrl(apIRequestURLs.updateLocation);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateLocationTypeResponseBody>(response);
        }
        /// <summary>
        /// Get location details by location id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        /// <returns></returns>
        public LocationSearchKeyResponseBody GetLocationByLocationId(string token)
        {
            var url = SetUrl(apIRequestURLs.locationId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<LocationSearchKeyResponseBody>(response);
        }
        /// <summary>
        /// Delete locations by Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        public void DeleteMultipleLocationsById(string token)
        {
            var requestBody = new DeleteLocationRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(locationRequestBody.DeletelocationRequestBody);
            var url = SetUrl(apIRequestURLs.deleteLocation);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
     
        }
        /// <summary>
        /// Delete Location by Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locId"></param>
        public void DeleteLocationsByID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationId);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// DeleteLocationTypesByID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="locTypeId"></param>
        public void DeleteLocationsTypeByID(string token)
        {
            var url = SetUrl(apIRequestURLs.locationTypeslocTypeId);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
    }
}
