using Ksiazka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ksiazka.ViewModels
{
    public class BookShelfViewModel
    {
        public BookShelfViewModel() { }
        public BookShelfViewModel(BookShelf vm)
        {
            this.Id = vm.Id;
            this.Name = vm.Name;
            this.Books = new List<AddressBookViewModel>();
            foreach (var book in vm.Books)
            {
                Books.Add(new AddressBookViewModel(book));
            }

        }

        public int Id { get; set; }

        public string Name { get; set; }
        public List<AddressBookViewModel> Books { get; set; }
    }


    public class AddressBookViewModel
    {
        public AddressBookViewModel() { }
        public AddressBookViewModel(AddressBook vm)
        {
            this.Id = vm.Id;
            this.Title = vm.Title;
            this.CreateTime = vm.CreateTime;
            this.PersonalDatas = new List<PersonalDataViewModel>();
            foreach (var pd in vm.PersonalDatas)
            {
                this.PersonalDatas.Add(new PersonalDataViewModel(pd));
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public List<PersonalDataViewModel> PersonalDatas { get; set; }
    }



    public class PersonalDataViewModel
    {
        public PersonalDataViewModel() { }
        public PersonalDataViewModel(PersonalData vm)
        {
            this.Id = vm.Id;
            this.Name = vm.Name;
            this.Surname = vm.Surname;
            this.PhoneNo = vm.PhoneNo;
            this.Email = vm.Email;
            this.DateOfBirth = vm.DateOfBirth;
            this.CompanyName = vm.CompanyName;
            this.FullAddress = vm.FullAddress;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }
    }
}