using Ksiazka.Models;
using Ksiazka.ServiceLayer;
using Ksiazka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ksiazka.Controllers
{
    public class HomeController : Controller
    {
        protected BookShelfService _bookShelf;
        protected PersonalDataService _personalData;
        protected AddressBookService _addressBook;
        protected AppConfigDataService _appConfig;
        protected AppConfigData _appConfigData;
        public HomeController()
        {
            this._addressBook = new AddressBookService();
            this._bookShelf = new BookShelfService();
            this._addressBook = new AddressBookService();
            this._appConfig = new AppConfigDataService();
            this._appConfigData = _appConfig.Get();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async Task<ActionResult> BookDetails(int id)
        {
            ViewBag.Title = "Książka adresowa";
            var vm = await _addressBook.GetById(id);
            return View(vm);
        }


        public async Task<ActionResult> IndexPartialView()
        {
            var shelves = await _bookShelf.GetList();
            var vm = new List<BookShelfViewModel>();
            foreach (var bookShelf in shelves)
            {
                vm.Add(new BookShelfViewModel(bookShelf));
            }

            System.Threading.Thread.Sleep(_appConfigData.TaskSleepTime);

            return PartialView("~/Views/Home/_BookShelves.cshtml", vm);
        }
    }
}
