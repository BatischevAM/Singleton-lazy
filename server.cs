using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    internal class server
    {
        private static readonly Lazy<server> singleton = new Lazy<server>(() => new server());
        private readonly HashSet<string> serverList;
        private readonly object lockObject = new object();
        private server()
        {
            serverList = new HashSet<string>();
        }

        public static server Singleton = singleton.Value;

        public bool AddServer(string serverAddress)
        {
            if (string.IsNullOrEmpty(serverAddress) ||
                (!serverAddress.StartsWith("http://") && !serverAddress.StartsWith("https://")))
            {
                return false;
            }

            lock (lockObject)
            {
                if (serverList.Contains(serverAddress))
                {
                    return false;
                }

                serverList.Add(serverAddress);
                return true;
            }
        }
            public List<string> GetHttpServers()
        {
            var httpServers = new List<string>();
            foreach (var server in serverList)
            {
                if (server.StartsWith("http://"))
                {
                    httpServers.Add(server);
                }
            }
            return httpServers;
        }

        public List<string> GetHttpsServers()
        {
            var httpsServers = new List<string>();
            foreach (var server in serverList)
            {
                if (server.StartsWith("https://"))
                {
                    httpsServers.Add(server);
                }
            }
            return httpsServers;
        }
    }
}
