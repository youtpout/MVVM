using MVVM.Models;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    /// <summary>
    /// Notre ViewModel
    /// </summary>
    public class ContactViewModel
    {
        /// <summary>
        /// L'observable collection est une liste qui notifie de ses changements en cas d'ajout et de suppression d'item
        /// </summary>
        public ObservableCollection<ContactModel> Contacts { get; set; }


        public ContactModel ContactSelected
        {
            get;
            set;
        }


        /// <summary>
        /// Les commandes permettent de binder un événement à cette commande (ex: clique sur un button)
        /// </summary>
        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();
            var item = new ContactModel()
            {
                BirthYear = 1973,
                FirstName = "Toto",
                LastName = "Ducobu"
            };
            // on ajoute au moin un item pour l'afficher au démarrage
            Contacts.Add(item);
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
