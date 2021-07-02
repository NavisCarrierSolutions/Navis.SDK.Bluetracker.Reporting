using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Navis.SDK.Bluetracker.Reporting.Core;
using Navis.SDK.Bluetracker.Reporting.Dto;

namespace Navis.SDK.Bluetracker.Reporting.Clients
{
    /// <summary>
    /// Client to get all ships.
    /// </summary>
    public class ShipClient : ApiWrapper
    {
        /// <summary>
        /// Create a new ShipClient instance.
        /// </summary>
        /// <param name="httpClient">Your HttpClient.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting ApiKey is used to specify the API token.
        /// </remarks>
        public ShipClient(HttpClient httpClient, string authorization) : base(httpClient, authorization)
        {
        }

        /// <summary>
        /// Create a new ShipClient instance.
        /// </summary>
        /// <param name="httpClient">Your HttpClient.</param>
        /// <param name="serverAddress">The server address.</param>
        /// <param name="authorization">The API token.</param>
        /// <remarks>
        /// The key Bluetracker-Reporting_ApiKey is used to specify the API token, the key Bluetracker-Reporting_ServerAddress is used to set the
        /// service address. If the service address is not specified as constructor parameter, the default service address will be used.
        /// </remarks>
        public ShipClient(HttpClient httpClient, string serverAddress, string authorization) : base(httpClient, serverAddress, authorization)
        {
        }

        /// <summary>
        /// GET List of ships
        /// </summary>
        /// <returns>List of ships</returns>
        public async Task<List<Ship>> GetShips()
        {
            const string route = "v1/ships";
            return await GetObject<List<Ship>>(route);
        }
    }
}