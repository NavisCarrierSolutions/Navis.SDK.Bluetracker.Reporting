namespace Navis.SDK.Bluetracker.Reporting.Dto
{
    /// <summary>
    /// Ship
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Ship Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imo
        /// </summary>
        public int Imo { get; set; }

        /// <summary>
        /// Vessel name
        /// </summary>
        public string VesselName { get; set; }

        /// <summary>
        /// This version stamp increments every time a related dataset gets updated (e.g. a report)
        /// </summary>
        public long CurrentVersionStamp { get; set; }
    }
}