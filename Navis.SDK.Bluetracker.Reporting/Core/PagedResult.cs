using System.Collections.Generic;

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
}