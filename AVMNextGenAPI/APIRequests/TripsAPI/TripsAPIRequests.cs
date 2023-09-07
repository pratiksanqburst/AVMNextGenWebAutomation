using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips;
using AVMNextGenWebAutomation.AVMNextGenAPI.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIRequests.TripsAPI
{
    public class TripsAPIRequests : APIHelper
    {
        #region Properties
        public APIRequestURLs aPIRequestURLs;
        public TripsRequestBody tripsRequestBody;

        #endregion
        public TripsAPIRequests()
        {
            aPIRequestURLs = new APIRequestURLs();
            tripsRequestBody = new TripsRequestBody();
        }
        /// <summary>
        /// Get trips list using unit ID
        /// </summary>
        /// <param name="vehicleUnitId"></param>
        /// <param name="isAssigned"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public TripsResponseBody getTripsAsync(string token)
        {
            var requestBody = new VehicleTripBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(tripsRequestBody.vehicleTripBody);
            var url = SetUrl(aPIRequestURLs.getTrips);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<TripsResponseBody>(response);
        }

        /// <summary>
        /// Get trip list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="vehicleUnitId"></param>
        /// <param name="isAssigned"></param>
        /// <returns></returns>
        public TripsResponseBody GetTripList(string token)
        {
            var url = SetUrl(aPIRequestURLs.getTrips);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<TripsResponseBody>(response);
        }
        /// <summary>
        /// Get Single trip details
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="isAssigned"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public SingleTripResponseBody getSingleTripAsync(string token)
        {
            var requestBody = new SingleTriprequestBody();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(tripsRequestBody.singleTriprequestBody);
            var url = SetUrl(aPIRequestURLs.tripsapi);
            var request = CreateGetRequest(token);
            var response = GetResponse(url, request);
            return GetContent<SingleTripResponseBody>(response);
        }
        /// <summary>
        /// Edit Single trip details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tripId"></param>
        public void EditSingleTripDetails(string token)// check (doubt)
        {
            var url = SetUrl(aPIRequestURLs.tripsapi);
            var request = CreatePutRequest(token);
            var response = GetResponse(url, request);
            
        }
        /// <summary>
        /// Edit multiple trip details
        /// </summary>

        public void EditMultipleTripDetails(string token)
        {
            var url = SetUrl(aPIRequestURLs.updateMultipleTrips);
            var request = CreateDeleteRequest(token);
            var response = GetResponse(url, request);
        }
    }
}
