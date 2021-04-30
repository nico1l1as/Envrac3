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
    /// Logique d'interaction pour pgUnite.xaml
    /// </summary>
    public partial class pgUnite : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeUnite;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public pgUnite()
        {

            InitializeComponent();
            _listeUnite = CollectionViewSource.GetDefaultView(_bdd.Unite);
            grpUnite.DataContext = _listeUnite;
        }
        private void AjouterUnite(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvUnite.SelectedItem = _bdd.AjouterUnite("Nouvelle unite"); }, nameof(AjouterUnite));
        }
        private void SupprimerUnite(object sender, RoutedEventArgs e)
        {
            Unite selection = (Unite)lvUnite.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer l'unité {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerUnite(selection); }, nameof(SupprimerUnite));
                }
            }
        }
        //private void SupprimerUnite(object sender, RoutedEventArgs e)
        //{
        //    Unite selection = (Unite)lvUnite.SelectedItem;
        //    if (selection != null)
        //    {
        //        if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien unite {selection.Article} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            Statics.TryCatch(() => { _bdd.SupprimerUnite(selection); }, nameof(SupprimerUnite));
        //        }
        //    }
        //}
        private void AjouterUniteAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbArticle.SelectedItem = null;
            inboxAjouterUnite.Visibility = Visibility.Visible;
        }
        private void AjouterUniteAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterUnite.Visibility = Visibility.Collapsed; }
        //private void AjouterUniteConfirmerAction(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Unite lNouveauUnite = _bdd.AjouterUnite((Article)IAE_cmbArticle.SelectedItem);
        //        inboxAjouterUnite.Visibility = Visibility.Collapsed;
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien unite", MessageBoxButton.OK, MessageBoxImage.Warning); }
        //}
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeUnite.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeUnite.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
