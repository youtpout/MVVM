using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVM.Models
{

    /// <summary>
    /// On implémente INotifyPropertyChanged pour notifier des changements de valeur sur les propriétés
    /// Notre Model
    /// </summary>
    public class ContactModel : INotifyPropertyChanged
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private int birthYear;

        public int BirthYear
        {
            get { return birthYear; }
            set { SetProperty(ref birthYear, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
             [CallerMemberName] string propertyName = "",
             Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
