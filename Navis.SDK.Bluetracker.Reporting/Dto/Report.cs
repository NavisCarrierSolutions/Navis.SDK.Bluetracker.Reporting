using System;
using Navis.SDK.Bluetracker.Reporting.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Navis.SDK.Bluetracker.Reporting.Dto
{
    /// <summary>
    /// The report
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public State State { get; set; }

        /// <summary>
        /// Event type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }

        /// <summary>
        /// Event time local
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Event time utc
        /// </summary>
        public DateTime EventTimeUtc { get; set; }

        /// <summary>
        /// Timestamp utc
        /// </summary>
        public DateTimeOffset TimestampUtc  { get; set; }

        /// <summary>
        /// Origin location
        /// </summary>
        public string OriginLoc { get; set; }

        /// <summary>
        /// Destination location
        /// </summary>
        public string DestLoc { get; set; }

        /// <summary>
        /// Is report valid?
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// Is report deleted?
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Version of data set
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Version of ship.CurrentVersionStamp
        /// </summary>
        public long VersionStamp { get; set; }

        /// <summary>
        /// Values
        /// </summary>
        public string Values { get; set; }
    }
}
