using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client.ClientTreebody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.RolesAPI
{
    public class RolesAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public RolesRequestBody rolesRequestBody;
        #endregion
        public RolesAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            rolesRequestBody = new RolesRequestBody();
        }

        /// <summary>
        /// New Roles API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RolesResponseBody CreateNewRole(string token)
        {
            var requestBody = new RolesCreationRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(rolesRequestBody.rolesCreationRequestBody);
            var url = SetUrl(aPIRequestURLs.roles);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<RolesResponseBody>(response);
        }
        /// <summary>
        /// Create new role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RolesResponseBody CreateNewRoleForUser(string token)
        {
            var url = SetUrl(aPIRequestURLs.roles);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<RolesResponseBody>(response);
        }
        /// <summary>
        /// Get roles list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<RolesListResponseBody> getRolesListAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.roles);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent < List < RolesListResponseBody >>(response);
        }
        /// <summary>
        /// Get roles listed for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<RolesListResponseBody> GetRoles(string token)
        {
            var url = SetUrl(aPIRequestURLs.roles);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<RolesListResponseBody>>(response);
        }
        /// <summary>
        /// Edit role name Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public void editRoleNameDetailsByID(string token)
        {
            var requestBody = new EditRoleNameRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(rolesRequestBody.editRoleNameRequestBody);
            var url = SetUrl(aPIRequestURLs.updateRole);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            
            
        }
        /// <summary>
        /// Edit roleName by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void EditRoleNameByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.updateRole);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Edit role rights Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public void editRoleRightsDetailsByID(string token)
        {
            var requestBody = new EditRoleRightsRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(rolesRequestBody.editRoleNameRequestBody);
            var url = SetUrl(aPIRequestURLs.updateRole);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
           
        }
        /// <summary>
        /// Edit role Rights by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void EditRoleRightsByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.updateRole);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }

        /// <summary>
        /// Delete roles 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public void DeleteRolesAsync(string token)
        {
            var requestBody = new VehicleTreeBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(rolesRequestBody.vehicleTreeBody);
            var url = SetUrl(aPIRequestURLs.roleId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
        }
        /// <summary>
        /// Get user access rights
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public void getUserAccessRights(string token)
        {
            var url = SetUrl(aPIRequestURLs.getUserAccessrights);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
           
        }

    }
}
