using System;
using Navis.SDK.Bluetracker.Reporting.Core;
using Navis.SDK.Bluetracker.Reporting.Dto;

namespace Navis.SDK.Bluetracker.Reporting.Clients
{
    /// <summary>
    /// Client to get reports for a specified ship by IMO number.
    /// </summary>
    public class ReportClient : ApiWrapper
    {
        /// <summary>
        /// Create a new ReportClient instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting ApiKey is used to specify the API token.
        /// </remarks>
        public ReportClient(string authorization) : base(authorization)
        {
        }

        /// <summary>
        /// Create a new ReportClient instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting_ApiKey is used to specify the API token, the key Bluetracker-Reporting_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter, the default service address will be used.
        /// </remarks>
        public ReportClient(string serverAddress, string authorization) : base(serverAddress, authorization)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="sinceShipVersion"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<Report> GetReports(int imo, DateTime? start, DateTime? end,
            long? sinceShipVersion, int? page, int? pageSize)
        {
            var route = $"v1/{imo}/reports?start={start:yyyy-MM-ddTHH:mm}&end={end:yyyy-MM-ddTHH:mm}&sinceShipVersion={sinceShipVersion}&page={page}&pageSize={pageSize}";
            return GetObject<PagedResult<Report>>(route);
        }
    }
}