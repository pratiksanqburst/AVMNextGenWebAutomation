using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ServiceSchedule;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ServiceSchedule.ServiceScheduleResponseBody;
using static AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.ServiceSchedule.ServiceScheduleTreeBody;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.ServiceScheduleAPI
{
    public class ServiceScheduleAPIRequests:APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public ServiceSchedulerequestBody serviceScheduleRequestBody;

        #endregion
        public ServiceScheduleAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            serviceScheduleRequestBody = new ServiceSchedulerequestBody();
        }
        /// <summary>
        ///(SaveServiceSchedule) Called to Add a service interval info by id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceSaveScheduleResponsebody> SaveServiceSchedule(string token)
        {
            var requestBody = new ServiceScheduleSavebody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceScheduleRequestBody.serviceschedulesavebody);
            var url = SetUrl(aPIRequestURLs.saveServiceschedule);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceSaveScheduleResponsebody>>(response);
        }
        /// <summary>
        ///Save Service Schedule list
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceSaveScheduleResponsebody> SaveServiceScheduleList(string token)
        {
            var requestBody = new ServiceScheduleSavebody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceScheduleRequestBody.serviceSchedulesavebody);
            var url = SetUrl(aPIRequestURLs.saveServicescheduleList);
            var request = CreatePostRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceSaveScheduleResponsebody>>(response);
        }
        /// <summary>
        ///(UpdateServiceSchedule)Called to Update a service interval info by id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceSaveScheduleResponsebody> UpdateServiceSchedule(string token)
        {
            var requestBody = new ServiceScheduleSavebody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceScheduleRequestBody.serviceScheduleSavebody);
            var url = SetUrl(aPIRequestURLs.updateServiceSchedule);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceSaveScheduleResponsebody>>(response);
        }
        /// <summary>
        ///Update Service Schedule list
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceSaveScheduleResponsebody> UpdateServiceScheduleList(string token)
        {
            var requestBody = new ServiceScheduleSavebody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceScheduleRequestBody.serviceSchedulesaveBody);
            var url = SetUrl(aPIRequestURLs.updateServiceScheduleList);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceSaveScheduleResponsebody>>(response);
        }
        /// <summary>
        ///(GetServiceReminder)Get service reminder by Id and service type
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<ServiceGetScheduleResponsebody> GetServiceScheduleList(string token)
        {
           
            var url = SetUrl(aPIRequestURLs.getServiceScheduleByUnitId);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            return GetContent<List<ServiceGetScheduleResponsebody>>(response);
        }
    }
}
