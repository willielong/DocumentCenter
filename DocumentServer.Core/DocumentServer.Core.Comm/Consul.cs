using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Comm
{
    public class Consul
    {
        public ConsulChild Api { get; set; }
        public ConsulChild Service { get; set; }
    }
    public class ConsulChild
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
