using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOIFileCompressor
{
    public class AppConfigModel
    {
        public string FileName { get; set; }

        public string DirectoryName { get; set; }
        
        public byte[] FileBytes { get; set; }

        public string Base64FileName { get; set; }

        public string Base64FileBytes { get; set; }

        public string PrepFileCompress { get; set; }
    }
}
