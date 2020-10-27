using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class DownloadModel
    {
        public string ContentType { get; set; }
        public byte[] Buff { get; set; }
        public string fileName { get; set; }
    }
}
