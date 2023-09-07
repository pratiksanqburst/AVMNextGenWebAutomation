using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http.Headers;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.ContactsAPI
{
    public class ContactsAPIRequest: APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public ContactRequestBody contactRequestBody;
        #endregion
        public ContactsAPIRequest()
        {
            aPIRequestURLs = new APIRequestURLs();
            contactRequestBody = new ContactRequestBody();
        }
        /// <summary>
        /// New contact API
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody CreateNewContactGroup(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(contactRequestBody.contactGroupRequestBody);
            var requestBody = new ContactGroupRequestBody();
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ContactGroupResponseBody>(response);
        }
        /// <summary>
        /// Create new contact group
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody CreateContactGroup(string token)//check on this(doubt)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(contactRequestBody.contactGroupRequestBody);
            var requestBody = new ContactGroupRequestBody();
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ContactGroupResponseBody>(response);
        }
        /// <summary>
        /// Get contact group details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ContactGroupDetailsResponseBody> getContactGroupAsync(string token)
        {
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ContactGroupDetailsResponseBody>>(response);
        }
        /// <summary>
        /// Get contact groups for logged in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<ContactGroupDetailsResponseBody> GetContactGroups(string token) //check this
        {
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ContactGroupDetailsResponseBody>>(response);
        }

        /// <summary>
        /// Get contact group usage details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string getContactGroupUsageAsync(string token)//doubt
        {
            var url = SetUrl(aPIRequestURLs.ContactGroupUsages);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<string>(response);

        
        }
        /// <summary>
        /// Delete contact group usage details
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public void deleteContactGroupUsageAsync(string token) //doubt
        {
            var url = SetUrl(aPIRequestURLs.ContactGroupUsages);
            var request = CreateDeleteRequest(token);
            
           
        }

        /// <summary>
        /// Edit contact group Details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ContactGroupResponseBody editContactGroupDetailsByID(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(contactRequestBody.contactGroupRequestBody);
            var requestBody = new EditContactGroupRequestBody();
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ContactGroupResponseBody>(response);
        }
        /// <summary>
        /// Edit contact groups by ID
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ContactGroupResponseBody EditContactGroupByID(string token)//doubt
        {
            var url = SetUrl(aPIRequestURLs.contactgroups);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ContactGroupResponseBody>(response);
        }
        /// <summary>
        /// Delete contact group by ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="groupID"></param>
        public void DeleteContactGroupDetailsByID(string token)
        {
            var url = SetUrl(aPIRequestURLs.contactGroupID);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }

    }
}
