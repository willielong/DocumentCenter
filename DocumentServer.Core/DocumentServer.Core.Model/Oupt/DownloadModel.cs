using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class DownloadModel
    {
        public string ContentType { get; set; }
        public FileStream Buff { get; set; }
        public string fileName { get; set; }
    }
}
