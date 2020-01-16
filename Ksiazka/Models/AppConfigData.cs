using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ksiazka.Models
{
    public class AppConfigData
    {
        public AppConfigData()
        {
            this.AccessKey = "accessKey";
            this.EncryptionKey = "encryptionKey";
            this.TaskSleepTime = 0;
        }
        public int Id { get; set; }
        public int TaskSleepTime { get; set; }
        public string EncryptionKey { get; set; }
        public string AccessKey { get; set; }
    }
}