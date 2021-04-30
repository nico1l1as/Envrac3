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
    /// Logique d'interaction pour pgEtagere.xaml
    /// </summary>
    public partial class pgEtagere : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeEtagere;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public ReadOnlyObservableCollection<Etage> Etages => _bdd.Etage;
        public pgEtagere()
        {
            InitializeComponent();
            _listeEtagere = CollectionViewSource.GetDefaultView(_bdd.Etagere);
            grpEtagere.DataContext = _listeEtagere;
        }
        private void AjouterEtagere(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvEtagere.SelectedItem = _bdd.AjouterEtagere("Nouveau etagere",_bdd.Etage.FirstOrDefault()); }, nameof(AjouterEtagere));
        }
        private void SupprimerEtagere(object sender, RoutedEventArgs e)
        {
            Etagere selection = (Etagere)lvEtagere.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer l'etagere {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerEtagere(selection); }, nameof(SupprimerEtagere));
                }
            }
        }
        //private void SupprimerEtagere(object sender, RoutedEventArgs e)
        //{
        //    Etagere selection = (Etagere)lvEtagere.SelectedItem;
        //    if (selection != null)
        //    {
        //        if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien Etagere {selection.Article} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            Statics.TryCatch(() => { _bdd.SupprimerEtagere(selection); }, nameof(SupprimerEtagere));
        //        }
        //    }
        //}
        private void AjouterEtagereAfficherInbox(object sender, RoutedEventArgs e)
        {

            //IAE_cmbArticle.SelectedItem = null;
            inboxAjouterEtagere.Visibility = Visibility.Visible;
        }
        private void AjouterEtagereAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterEtagere.Visibility = Visibility.Collapsed; }
       // private void AjouterEtagereConfirmerAction(object sender, RoutedEventArgs e)
       // {
       //     try
       //     {
       //         Etagere lNouveauEtagere = _bdd.AjouterEtagere((Article)IAE_cmbArticle.SelectedItem);
       //         inboxAjouterEtagere.Visibility = Visibility.Collapsed;
       //     }
       //     catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien etagere", MessageBoxButton.OK, MessageBoxImage.Warning); }
       // }
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeEtagere.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeEtagere.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
