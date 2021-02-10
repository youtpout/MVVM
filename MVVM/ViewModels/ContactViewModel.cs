using MVVM.Models;
using MVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    /// <summary>
    /// Notre ViewModel
    /// </summary>
    public class ContactViewModel : BaseViewModel
    {
        /// <summary>
        /// L'observable collection est une liste qui notifie de ses changements en cas d'ajout et de suppression d'item
        /// </summary>
        public ObservableCollection<ContactModel> Contacts { get; set; }

        private ContactModel contactSelected;

        public ContactModel ContactSelected
        {
            get { return contactSelected; }
            // set property se trouve dans BaseViewModel et permet de notifier d'un changement de valeur, elle se base sur l'interface INotifyPropertyChanged
            set { SetProperty(ref contactSelected, value); }
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
            var item2 = new ContactModel()
            {
                BirthYear = 1986,
                FirstName = "Tata",
                LastName = "Yoyo"
            };
            var item3 = new ContactModel()
            {
                BirthYear = 1990,
                FirstName = "Lolo",
                LastName = "Williams"
            };
            // on ajoute au moin un item pour l'afficher au démarrage
            Contacts.Add(item);
            Contacts.Add(item2);
            Contacts.Add(item3);
            AddCommand = new RelayCommand<ContactModel>((e) => AddContact());
            EditCommand = new RelayCommand<ContactModel>((c) => EditContact(c));
            DeleteCommand = new RelayCommand<ContactModel>((c) => DeleteContact(c));
        }

        private void AddContact()
        {
            ContactModel contact = new ContactModel()
            {
                BirthYear = DateTime.Now.Year,
                FirstName = "Prénom",
                LastName = "Nom"
            };
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
