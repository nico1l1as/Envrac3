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
    /// Logique d'interaction pour pgSousCategorie.xaml
    /// </summary>
    public partial class pgSousCategorie : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeSousCategorie;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public ReadOnlyObservableCollection<Categorie> Categories => _bdd.Categorie;
        public pgSousCategorie()
        {
            InitializeComponent();
            _listeSousCategorie = CollectionViewSource.GetDefaultView(_bdd.SousCategorie);
            grpSousCategorie.DataContext = _listeSousCategorie;
        }
        private void AjouterSousCategorie(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvSousCategorie.SelectedItem = _bdd.AjouterSousCategorie("Nouveau Sous Categorie"); }, nameof(AjouterSousCategorie));
        }
        private void SupprimerSousCategorie(object sender, RoutedEventArgs e)
        {
            SousCategorie selection = (SousCategorie)lvSousCategorie.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la sous categorie {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerSousCategorie(selection); }, nameof(SupprimerSousCategorie));
                }
            }
        }
        //private void SupprimerSousCategorie(object sender, RoutedEventArgs e)
        //{
        //    SousCategorie selection = (SousCategorie)lvSousCategorie.SelectedItem;
        //    if (selection != null)
        //    {
        //        if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien SousCategorie {selection.Article} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            Statics.TryCatch(() => { _bdd.SupprimerSousCategorie(selection); }, nameof(SupprimerSousCategorie));
        //        }
        //    }
       // }
        private void AjouterSousCategorieAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbArticle.SelectedItem = null;
            inboxAjouterSousCategorie.Visibility = Visibility.Visible;
        }
        private void AjouterSousCategorieAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterSousCategorie.Visibility = Visibility.Collapsed; }
       // private void AjouterSousCategorieConfirmerAction(object sender, RoutedEventArgs e)
        //{
       //     try
       //     {
       //         SousCategorie lNouveauSousCategorie = _bdd.AjouterSousCategorie((Article)IAE_cmbArticle.SelectedItem);
       //         inboxAjouterSousCategorie.Visibility = Visibility.Collapsed;
       //     }
       //     catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien sous categorie", MessageBoxButton.OK, MessageBoxImage.Warning); }
       // }
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeSousCategorie.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeSousCategorie.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
