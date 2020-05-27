using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour ContactView.xaml
    /// </summary>
    public partial class ContactView : Page
    {
        public ContactView()
        {
            InitializeComponent();
            // c'est le datacontext qui défini sur l'environnement sur lequel on travaillera au niveau de la vue
            // il est possible de définir des datacontext directement au niveau des élément d'UI
            this.DataContext = new ContactViewModel();
        }
    }
}
