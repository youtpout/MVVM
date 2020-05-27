using MVVM.Models;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class ContactViewModel
    {
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public ContactModel ContactSelected { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();
            AddCommand = new RelayCommand<ContactModel>((e) => AddContact());
            EditCommand = new RelayCommand<ContactModel>((c) => EditContact(c));
            DeleteCommand = new RelayCommand<ContactModel>((c) => DeleteContact(c));
        }

        private void AddContact()
        {
            ContactModel contact = new ContactModel();
            ContactSelected = contact;
            Contacts.Add(contact);
        }

        private void EditContact(ContactModel contact)
        {
            ContactSelected = contact;
        }

        private void DeleteContact(ContactModel contact)
        {
            if (ContactSelected == contact)
            {
                ContactSelected = null;
            }
            Contacts.Remove(contact);
        }
    }
}
