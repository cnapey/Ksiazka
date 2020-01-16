using Ksiazka.DataAccessLayer;
using Ksiazka.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ksiazka.ServiceLayer
{
    public class AppConfigDataService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private void CheckConnectionOpen()
        {
            var connectionState = _db.Database.Connection.State;
            if (connectionState != ConnectionState.Open) _db.Database.Connection.Open();
        }

        public async Task<bool> Update(AppConfigData data)
        {
            bool ret = false;
            try
            {
                this.CheckConnectionOpen();
                var confData = _db.AppConfigData.FirstOrDefault();

                if (confData != null)
                {
                    confData.AccessKey = data.AccessKey;
                    confData.EncryptionKey = data.EncryptionKey;
                    confData.TaskSleepTime = data.TaskSleepTime;
                    _db.Entry(confData).State = EntityState.Modified;
                }
                else
                {
                    confData = new AppConfigData
                    {
                        AccessKey = data.AccessKey,
                        EncryptionKey = data.EncryptionKey,
                        TaskSleepTime = data.TaskSleepTime
                    };
                    _db.AppConfigData.Add(confData);
                }

                await _db.SaveChangesAsync();
                ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public AppConfigData Get()
        {
            AppConfigData data = _db.AppConfigData.FirstOrDefault();

            if (data == null)
            {
                data = new AppConfigData
                {
                    AccessKey = "accessKey",
                    EncryptionKey = "encryptionKey",
                    TaskSleepTime = 0
                };
            }
            return data;
        }
    }
}