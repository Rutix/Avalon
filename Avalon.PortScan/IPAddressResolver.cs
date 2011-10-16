using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AvalonPortScan
{
    class IPAddressResolver
    {
        /// <summary>
        /// Determines whether address is an IPAddress.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>
        ///   <c>true</c> if address is an IP address ; otherwise, <c>false</c>.
        /// </returns>
        static bool IsAnIPAddress(string address)
        {
            IPAddress ipAddress;
            return IPAddress.TryParse(address, out ipAddress);
        }

        /// <summary>
        /// Gets the IP address from DNS.
        /// </summary>
        /// <param name="scanAddress">The scan address.</param>
        /// <returns></returns>
        static List<IPAddress> GetIPAddressFromDNS(string scanAddress)
        {
            var ips = Dns.GetHostAddresses(scanAddress).ToList();
            if (ips.Count() > 0)
            {
                return ips;
            }
            throw new ArgumentException(string.Format("Unable to lookup hot name '{0}'.", scanAddress));
        }

        /// <summary>
        /// Resolves the IP address.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static List<IPAddress> ResolveIPAddress(string target)
        {
            if (IsAnIPAddress(target))
            {
                var ipaddress = new List<IPAddress>();
                ipaddress.Add(IPAddress.Parse(target));
                return ipaddress;
            }

            try
            {
                return GetIPAddressFromDNS(target);
            }
            catch (ArgumentException)
            {
                
            }
            return null;
        }
    }
}
