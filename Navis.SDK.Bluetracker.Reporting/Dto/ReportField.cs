using System;
using Navis.SDK.Bluetracker.Reporting.Enums;

namespace Navis.SDK.Bluetracker.Reporting.Dto
{
    /// <summary>
    /// Customer field mappings
    /// </summary>
    public class ReportField
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// unique uid for mapping
        /// </summary>
        public Guid UniqueMap { get; set; }

        /// <summary>
        /// Field owner
        /// </summary>
        public Owner Owner { get; set; }

        /// <summary>
        /// unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Indicates if current field is type of list
        /// </summary>
        public bool ListType { get; set; }
    }
}