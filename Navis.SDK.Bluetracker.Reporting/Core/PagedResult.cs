using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Navis.SDK.Bluetracker.Reporting.Core
{
    public class PagedResult<T>
    {
        /// <summary>Gets or sets the page number.</summary>
        /// <value>The page number.</value>
        public int Page { get; set; }

        /// <summary>Gets the total number of pages.</summary>
        /// <value>The number of pages.</value>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the page count.</summary>
        /// <value>The page count.</value>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the total count of items.</summary>
        /// <value>The total number of items.</value>
        public int TotalCount { get; set; }

        /// <summary>Gets or sets the items.</summary>
        /// <value>The items.</value>
        public ICollection<T> Items { get; set; }
    }

    public abstract class ApiWrapper
    {
        private readonly string _serverAddress;
        private readonly string _authorization;
        private readonly HttpClient _httpClient = new HttpClient();

        private const string DefaultServerAddress = "https://api.bluetracker.one";

        protected ApiWrapper(string authorization) : this(null, authorization)
        {
        }

        protected ApiWrapper(string serverAddress, string authorization)
        {
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

        protected T GetObject<T>(string route)
        {
            var requestString = CombineRoute(route);

            string content = null;

            try
            {
                var response = _httpClient.GetAsync(requestString);
                
                response.Wait();

                var responseMessage = response.Result;
                var responseStreamTask = responseMessage.Content.ReadAsStreamAsync();
                responseStreamTask.Wait();

                var responseStream = responseStreamTask.Result;

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