using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Navis.SDK.Bluetracker.Reporting.Core
{
    public abstract class ApiWrapper
    {
        private readonly string _serverAddress;
        private readonly string _authorization;
        private readonly HttpClient _httpClient;

        private const string DefaultServerAddress = "https://api.bluetracker-reporting.one";

        protected ApiWrapper(HttpClient httpClient, string authorization) : this(httpClient,null, authorization)
        {
        }

        protected ApiWrapper(HttpClient httpClient, string serverAddress, string authorization)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }
            
            _httpClient = httpClient;

            if (string.IsNullOrEmpty(authorization))
            {
                throw new ArgumentNullException(nameof(authorization));
            }

            _serverAddress = serverAddress;

            if (string.IsNullOrEmpty(_serverAddress))
            {
                _serverAddress = DefaultServerAddress;
            }

            _authorization = authorization;

            _httpClient.BaseAddress = new Uri(_serverAddress);
            _httpClient.DefaultRequestHeaders.Authorization = GetAuthHeader();
        }

        protected async Task<T> GetObject<T>(string route)
        {
            var requestString = CombineRoute(route);

            string content = null;

            try
            {
                var responseMessage = await _httpClient.GetAsync(requestString);

                var responseStream = await responseMessage.Content.ReadAsStreamAsync();

                if (responseStream == null)
                    return default(T);

                using (var reader = new StreamReader(responseStream))
                {
                    content = reader.ReadToEnd();
                }

                if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException((int)responseMessage.StatusCode,
                        $"Failed to retrieve data with code {responseMessage.StatusCode}. Message: {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to contact {requestString}", ex);
            }

            try
            {
                var ret = JsonConvert.DeserializeObject<T>(content,
                    new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                    });

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not deserialize answer. Possibly it's not of type {typeof(T)}", ex);
            }
        }

        private string CombineRoute(string route)
        {
            var requestString = _serverAddress.TrimEnd('/') + "/" + route.TrimStart('/');

            return requestString;
        }


        private AuthenticationHeaderValue GetAuthHeader() => new AuthenticationHeaderValue("ApiKey", _authorization);
    }
}