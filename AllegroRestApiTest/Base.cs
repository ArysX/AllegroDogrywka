using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace AllegroRestApiTest
{
    public class Base
    {
        public IRestResponse ApiRequest(Method method, string path)
        {
            var authToken = GetToken();
            var ClientAPI = new RestClient("https://api.allegro.pl");
            var sendRequest = new RestRequest($"/sale/categories{path}", method);
            var authHeader = $"Bearer {authToken}";
            sendRequest.AddHeader("Authorization", $"{authHeader}");
            sendRequest.AddHeader("accept", "application/vnd.allegro.public.v1+json");
            return ClientAPI.Execute(sendRequest);
        }

        private string GetToken()
        {
            var client = new RestClient("https://allegro.pl/auth/oauth/token");
            var apiKey = "49a367344a64470f896970e77163aa0f";
            var apiSecret = "uZlpPBkeYXiMcqO7Q1Z5e2ZK0pz2kBBRANvAOZxfPJ0S8OJ2vyuklwYJuMCelx2r";
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}");
            var base64Credentials = Convert.ToBase64String(plainTextBytes);
            var authRequest = new RestRequest(Method.POST);
            authRequest.AddHeader("Authorization", $"Basic {base64Credentials}");
            authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            authRequest.AddParameter("grant_type", "client_credentials");
            var authResponse = client.Execute(authRequest);

            if (authResponse.StatusCode == HttpStatusCode.OK)
            {
                var authResponseBody = JObject.Parse(authResponse.Content);
                return authResponseBody["access_token"].ToString();
            }
            else
            {
                Console.WriteLine(authResponse.ErrorMessage);
                return "";
            }
        }
    }
}