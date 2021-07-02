using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Navis.SDK.Bluetracker.Reporting.Core;
using Navis.SDK.Bluetracker.Reporting.Dto;

namespace Navis.SDK.Bluetracker.Reporting.Clients
{
    /// <summary>
    /// Client to get all known report fields.
    /// </summary>
    public class ReportFieldClient : ApiWrapper
    {
        /// <summary>
        /// Create a new ReportFieldClient instance.
        /// </summary>
        /// <param name="httpClient">Your HttpClient.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting ApiKey is used to specify the API token.
        /// </remarks>
        public ReportFieldClient(HttpClient httpClient, string authorization) : base(httpClient, authorization)
        {
        }

        /// <summary>
        /// Create a new ReportFieldClient instance.
        /// </summary>
        /// <param name="httpClient">Your HttpClient.</param>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting_ApiKey is used to specify the API token, the key Bluetracker-Reporting_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter, the default service address will be used.
        /// </remarks>
        public ReportFieldClient(HttpClient httpClient, string serverAddress, string authorization) : base(httpClient, serverAddress, authorization)
        {
        }

        /// <summary>
        /// GET Field list of Report fields
        /// </summary>
        /// <returns>Report fields</returns>
        public async Task<List<ReportField>> GetReportFields()
        {
            const string route = "v1/reportFields";
            return await GetObject<List<ReportField>>(route);
        }
    }
}