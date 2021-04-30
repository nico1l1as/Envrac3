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
    /// Logique d'interaction pour pgArticle.xaml
    /// </summary>
    public partial class pgArticle : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeArticles;
        public ReadOnlyObservableCollection<Etagere> Etageres => _bdd.Etagere;
        public ReadOnlyObservableCollection<SousCategorie> SousCategories => _bdd.SousCategorie;
        public ReadOnlyObservableCollection<Unite> Unites => _bdd.Unite;
        public ReadOnlyObservableCollection<Pays> Pays => _bdd.Pays;
        public ReadOnlyObservableCollection<Contenir> Contenirs => _bdd.Contenir;
        public pgArticle()
        {
            InitializeComponent();
            _listeArticles = CollectionViewSource.GetDefaultView(_bdd.Article);
            grpArticles.DataContext = _listeArticles;
        }
        private void AjouterArticle(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvArticles.SelectedItem = _bdd.AjouterArticle("Nouveau"); }, nameof(AjouterArticle));
        }
        private void SupprimerArticle(object sender, RoutedEventArgs e)
        {
            Article selection = (Article)lvArticles.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le client {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerArticle(selection); }, nameof(SupprimerArticle));
                }
            }
        }
        private void lvArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Article article = (Article)lvArticles.SelectedItem;
            if (article != null)
            {
                //On n'affiche que les emprunts qui sont en cours (pas de date de retour)
               // grpEmprunts.DataContext = article.Nom.Where(e => e.DateRetour == null);
            }
        }
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeArticles.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeArticles.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
