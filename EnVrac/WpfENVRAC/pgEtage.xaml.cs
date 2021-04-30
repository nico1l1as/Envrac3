using EnVrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfENVRAC
{
    /// <summary>
    /// Logique d'interaction pour pgEtage.xaml
    /// </summary>
    public partial class pgEtage : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeEtage;
        public ReadOnlyObservableCollection<Etagere> Etageres => _bdd.Etagere;
        public pgEtage()
        {
            InitializeComponent();
            _listeEtage = CollectionViewSource.GetDefaultView(_bdd.Etage);
            grpEtage.DataContext = _listeEtage;
        }
        private void AjouterEtage(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvEtage.SelectedItem = _bdd.AjouterEtage("Nouveau etage"); }, nameof(AjouterEtage));
        }
        private void SupprimerEtage(object sender, RoutedEventArgs e)
        {
            Etage selection = (Etage)lvEtage.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le livre {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerEtage(selection); }, nameof(SupprimerEtage));
                }
            }
        }
       // private void SupprimerEtage(object sender, RoutedEventArgs e)
       // {
       //     Etage selection = (Etage)lvEtage.SelectedItem;
       //     if (selection != null)
       //     {
       //         if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien allergie {selection.Etagere.EtageID} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
       //         {
       //             Statics.TryCatch(() => { _bdd.SupprimerEtage(selection); }, nameof(SupprimerEtage));
       //         }
       //     }
       // }
        private void AjouterEtageAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbEtagere.SelectedItem = null;
            inboxAjouterEtage.Visibility = Visibility.Visible;
        }
        private void AjouterEtageAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterEtage.Visibility = Visibility.Collapsed; }

       // private void AjouterEtageeConfirmerAction(object sender, RoutedEventArgs e)
       // {
       //     try
       //     {
       //         Etage lNouveauEtage = _bdd.AjouterEtage((Etagere)IAE_cmbEtagere.SelectedItem);
       //         inboxAjouterEtage.Visibility = Visibility.Collapsed;
       //     }
       //     catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien etage", MessageBoxButton.OK, MessageBoxImage.Warning); }
       // }

        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeEtage.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeEtage.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
