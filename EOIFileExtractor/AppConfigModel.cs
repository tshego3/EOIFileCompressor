using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOIFileExtractor
{
    public class AppConfigModel
    {
        public string FileName { get; set; }

        public string DirectoryName { get; set; }

        public byte[] FileBytes { get; set; }

        public string[] PrepFileExtract { get; set; }

        public string PrepReceivedFile { get; set; }
    }
}
