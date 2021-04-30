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
    /// Logique d'interaction pour pgPays.xaml
    /// </summary>
    public partial class pgPays : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listePays;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public pgPays()
        {
            InitializeComponent();
            _listePays = CollectionViewSource.GetDefaultView(_bdd.Pays);
            grpPays.DataContext = _listePays;
        }
        private void AjouterPays(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvPays.SelectedItem = _bdd.AjouterPays("Nouveau Pays"); }, nameof(AjouterPays));
        }
        private void SupprimerPays(object sender, RoutedEventArgs e)
        {
            Pays selection = (Pays)lvPays.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le pays {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerPays(selection); }, nameof(SupprimerPays));
                }
            }
        }
        //private void SupprimerPays(object sender, RoutedEventArgs e)
        //{
        //    Pays selection = (Pays)lvPays.SelectedItem;
        //    if (selection != null)
        //    {
        //        if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien Pays {selection.Article} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            Statics.TryCatch(() => { _bdd.SupprimerPays(selection); }, nameof(SupprimerPays));
        //        }
        //    }
        //}
        private void AjouterPaysAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbArticle.SelectedItem = null;
            inboxAjouterPays.Visibility = Visibility.Visible;
        }
        private void AjouterPaysAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterPays.Visibility = Visibility.Collapsed; }
        //private void AjouterPaysConfirmerAction(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Pays lNouveauPays = _bdd.AjouterPays((Article)IAE_cmbArticle.SelectedItem);
        //        inboxAjouterPays.Visibility = Visibility.Collapsed;
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien pays", MessageBoxButton.OK, MessageBoxImage.Warning); }
        //}
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listePays.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listePays.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
