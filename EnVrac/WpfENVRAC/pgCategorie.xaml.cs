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
    /// Logique d'interaction pour pgCategorie.xaml
    /// </summary>
    public partial class pgCategorie : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeCategorie;
        public ReadOnlyObservableCollection<SousCategorie> SousCategories => _bdd.SousCategorie;
        public pgCategorie()
        {
            InitializeComponent();
            _listeCategorie = CollectionViewSource.GetDefaultView(_bdd.Categorie);
            grpCategorie.DataContext = _listeCategorie;
        }
        private void AjouterCategorie(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvCategorie.SelectedItem = _bdd.AjouterCategorie("Nouvelle categorie"); }, nameof(AjouterCategorie));
        }
        private void SupprimerCategorie(object sender, RoutedEventArgs e)
        {
            Categorie selection = (Categorie)lvCategorie.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien allergie {selection.SousCategorie} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerCategorie(selection); }, nameof(SupprimerCategorie));
                }
            }
        }
        private void AjouterCategorieAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbSousCategorie.SelectedItem = null;
            inboxAjouterCategorie.Visibility = Visibility.Visible;
        }
        private void AjouterCategorieAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterCategorie.Visibility = Visibility.Collapsed; }

       // private void AjouterCategorieConfirmerAction(object sender, RoutedEventArgs e)
       // {
       //     try
       //     {
       //         Categorie lNouveauCategorie = _bdd.AjouterCategorie((SousCategorie)IAE_cmbSousCategorie.SelectedItem);
       //         inboxAjouterCategorie.Visibility = Visibility.Collapsed;
       //     }
       //     catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien categorie", MessageBoxButton.OK, MessageBoxImage.Warning); }
       // }

        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeCategorie.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeCategorie.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
