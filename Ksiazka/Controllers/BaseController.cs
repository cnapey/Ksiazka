using Ksiazka.Models;
using Ksiazka.ServiceLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Ksiazka.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        protected BookShelfService _bookShelf;
        protected PersonalDataService _personalData;
        protected AddressBookService _addressBook;
        protected AppConfigDataService _appConfig;
        protected AppConfigData _appConfigData;
        protected string _unauthorizedMsg = "Brak dostępu do tego zasobu.";
        protected string _notFoundMsg = "Nie odnaleziono zasobu";
        protected string _modelNotValid = "Przesłano nieprawidłowe dane.";

        public BaseController()
        {
            this._addressBook = new AddressBookService();
            this._bookShelf = new BookShelfService();
            this._addressBook = new AddressBookService();
            this._appConfig = new AppConfigDataService();
            _appConfigData = _appConfig.Get();
        }


        // POST: api/UpdateDeveloperOptions
        [System.Web.Http.Route("api/Base/UpdateDeveloperOptions")]
        public async Task<IHttpActionResult> UpdateDeveloperOptions(dynamic data)
        {
            if (data == null)
            {
                return BadRequest("Nie wysłano danych ;(");
            }

            if (int.TryParse((string)data.TaskSleepTime, out int tst))
            {
                data.TaskSleepTime = tst;
                var confData = new AppConfigData();
                confData.TaskSleepTime = tst;
                confData.AccessKey = data.AccessKey;
                confData.EncryptionKey = data.EncryptionKey;
                if (await _appConfig.Update(confData))
                {
                    return Json(new { msg = "Zapisano zmiany!" });
                }
            }

            var dane = JsonConvert.SerializeObject(data);
            return Json(new { msg = "Coś nie zadziałało", data = dane });
        }
        [System.Web.Http.HttpGet]
        public AppConfigData GetDeveloperOptions()
        {
            return _appConfigData;
        }
    }
}