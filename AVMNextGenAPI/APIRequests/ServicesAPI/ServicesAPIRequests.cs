using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.ServicesAPI
{
    public class ServicesAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public ServicesRequestBody servicesRequestBody;

        #endregion
        public ServicesAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            servicesRequestBody = new ServicesRequestBody();
        }
        /// <summary>
        /// Get Service By ID
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ServicesResponseBody GetServiceById(string token)
        {
            var requestBody = new GetServiceByIdRequest();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.getServiceById);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ServicesResponseBody>(response);
        }
        /// <summary>
        /// Get Last Service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceByUserNameResponseBody> GetLastServiceDetailsByID(int vehicleId, string token)
        {
            var requestBody = new GetServiceByIdRequest();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.getLastService);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceByUserNameResponseBody>>(response);
        }
        /// <summary>
        /// Get Service details by username
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="vehicleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServicesResponseBody> GetServiceDetailsByUserName(string token)
        {
            var requestBody = new GetServicesByUserNameRequest();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.getServices);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServicesResponseBody>>(response);
        }
        /// <summary>
        /// Create new service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateServiceResponseBody CreateNewService(string token)
        {
            var requestBody = new CreateServiceRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.Services);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateServiceResponseBody>(response);
        }
        /// <summary>
        /// Edit service details
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public CreateServiceResponseBody EditServiceDetails(string token)
        {
            var requestBody = new CreateServiceRequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.ServiceId);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<CreateServiceResponseBody>(response);
     
        }
        /// <summary>
        /// Delete Service By ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="serviceId"></param>
        public void DeleteServicesByID(string token)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(servicesRequestBody.getServiceByIdRequest);
            var url = SetUrl(aPIRequestURLs.ServiceId);
            var request = CreateDeleteRequest(token);
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
            var url = SetUrl(aPIRequestURLs.serviceTypes);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceTypeResponseBody>>(response);
        }
        /// <summary>
        /// Get Service Readings
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ServiceReadingResponseBody GetServicereadingbyId(string token)
        {
            var url = SetUrl(aPIRequestURLs.ServiceReading);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<ServiceReadingResponseBody>(response);
            
        }
    }
}
