using System;
using Navis.SDK.Bluetracker.Reporting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Navis.SDK.Bluetracker.Reporting.Dto
{
    /// <summary>
    /// Schedule
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Schedule Identifier
        /// </summary>
        public Guid ScheduleIdentifier { get; set; }

        /// <summary>
        /// Ship
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Inbound voyage
        /// </summary>
        public string InboundVoyage { get; set; }

        /// <summary>
        /// Outbound voyage
        /// </summary>
        public string OutboundVoyage { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// ETA - Estimated time of arrival
        /// </summary>

        public DateTimeOffset? ETA { get; set; }

        /// <summary>
        /// ETB - Estimated time of berth
        /// </summary>
        public DateTimeOffset? ETB { get; set; }


        /// <summary>
        /// ETD - Estimated time to destination
        /// </summary>
        public DateTimeOffset? ETD { get; set; }

        /// <summary>
        /// Portactivities
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PortActivity PortActivities { get; set; }

        /// <summary>
        /// Wheater portcall is omitted
        /// </summary>
        public bool IsOmitted { get; set; }

        /// <summary>
        /// Charter agent
        /// </summary>
        public Contact CharterAgent { get; set; }

        /// <summary>
        /// Owner agent
        /// </summary>
        public Contact OwnerAgent { get; set; }

        /// <summary>
        /// Other agent
        /// </summary>
        public Contact OtherAgent { get; set; }

        /// <summary>
        /// Version of data set
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Version of ship.CurrentVersionStamp
        /// </summary>
        public long VersionStamp { get; set; }
    }
}