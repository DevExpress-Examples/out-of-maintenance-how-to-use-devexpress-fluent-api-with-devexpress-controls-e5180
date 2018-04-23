using DataAnnotationAttributes.Model;
using DevExpress.Xpf.Mvvm;
using DevExpress.Xpf.Mvvm.DataAnnotations;
using DevExpress.Xpf.Mvvm.POCO;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAnnotationAttributes.ViewModels {
    [POCOViewModel]
    public class MainViewModel {
        ContactContextEntities ContactContext;

        public virtual IList<Contact> Contacts { get; protected set; }
        public virtual Contact SelectedContact { get; set; }

        protected MainViewModel() {
            if(!ViewModelBase.IsInDesignMode)
                InitializeInRuntime();
            else
                InitializeInDesingMode();
        }
        void InitializeInRuntime() {
            ContactContext = new ContactContextEntities();
            ContactContext.Contacts.Load();
            Contacts = ContactContext.Contacts.Local;
        }
        void InitializeInDesingMode() {
            Contacts = new List<Contact>() {
                new Contact() {
                    FirstName = "FirstName", LastName = "LastName",
                    Email = "email", Phone = "(555)555-0000",
                    Address = "Address", City = "City", State = "AA", Zip = "11111",
                },
            };
        }
    }
}