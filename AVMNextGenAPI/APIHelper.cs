using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class APIHelper
    {
        public static IConfiguration config = new ConfigurationBuilder().AddJsonFile(TestContext.CurrentContext.TestDirectory + "\\appsettings.json").Build();
        public static string environment = config["AppSettings:Environment"];
        public static ResourceManager rm1 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}",
             Assembly.GetExecutingAssembly());
        public static string baseAddress = rm1.GetString("APIBaseAddress");
        public static string baseAddressReport = rm1.GetString("APIBaseAddressReport");
        public static string baseAddressLogin = rm1.GetString("APIBaseAddressLogin");
        public static string reCaptchaToken = rm1.GetString("ReCaptchaToken");
        public RestClient restClient;
        public RestRequest restRequest;
        public static HttpClient ApiClient { get; set; }


        public void APIInitialization()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public RestClient SetUrl(string endPoint)
        {
            var url = Path.Combine(baseAddress, endPoint);
            var restClient = new RestClient(url);
            return restClient;
        }
        public RestClient SetUrlLogin(string endPoint)
        {
            var url = Path.Combine(baseAddressLogin, endPoint);
            var restClient = new RestClient(url);
            return restClient;
        }
        public RestRequest CreatePostRequest(string token = "")
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.Post;
            restRequest.AddHeader("Content-Type", "application/json");
            if (token != "")
                restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreateGetRequest(string token = "")
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.Get;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            return restRequest;
        }
        public RestRequest CreatePutRequest( string token = "")
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.Put;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            return restRequest;
        }
        public RestRequest CreateDeleteRequest(string token = "")
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.Delete;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            return restRequest;
        }

        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO dto = JsonConvert.DeserializeObject<DTO>(content);
            return dto;
        }
      

    }
}
