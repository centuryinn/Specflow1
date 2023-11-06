using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Configuration
{
    class ConfigSetting
    {
        public string BrowserType { get; set; }
        public string ApplicationUrl { get; set; }
        public string ConfigReportPath { get; set; }
        public string FileUploadPath { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Environment { get; set; }
    }
}
