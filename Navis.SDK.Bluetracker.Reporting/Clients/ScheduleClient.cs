using System;
using Navis.SDK.Bluetracker.Reporting.Core;
using Navis.SDK.Bluetracker.Reporting.Dto;

namespace Navis.SDK.Bluetracker.Reporting.Clients
{
    /// <summary>
    /// Client to get all schedules for a specified ship by IMO number.
    /// </summary>
    public class ScheduleClient : ApiWrapper
    {
        /// <summary>
        /// Create a new ScheduleClient instance.
        /// </summary>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting ApiKey is used to specify the API token.
        /// </remarks>
        public ScheduleClient(string authorization) : base(authorization)
        {
        }

        /// <summary>
        /// Create a new ScheduleClient instance.
        /// </summary>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting_ApiKey is used to specify the API token, the key Bluetracker-Reporting_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter, the default service address will be used.
        /// </remarks>
        public ScheduleClient(string serverAddress, string authorization) : base(serverAddress, authorization)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imo">IMO of the vessel</param>
        /// <param name="start">Start-date for filtering (default: 0001-01-01)</param>
        /// <param name="end">End-date for filtering (default: 9999-12-31)</param>
        /// <param name="sinceShipVersion">returns every schedule touched after this ship.CurrentVersionStamp</param>
        /// <param name="page">page counter</param>
        /// <param name="pageSize">page size (default 50; max 100)</param>
        /// <returns></returns>
        public PagedResult<Schedule> GetSchedules(int imo, DateTime? start, DateTime? end,
            long? sinceShipVersion, int? page, int? pageSize)
        {
            if (start == null)
                start = DateTime.MinValue;

            if (end == null)
                end = DateTime.MaxValue;

            var route = $"v1/{imo}/schedules?start={start:yyyy-MM-ddTHH:mm}&end={end:yyyy-MM-ddTHH:mm}&sinceShipVersion={sinceShipVersion}&page={page}&pageSize={pageSize}";
            return GetObject<PagedResult<Schedule>>(route);
        }
    }
}
