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
    /// Logique d'interaction pour pgAllergenes.xaml
    /// </summary>
    public partial class pgAllergenes : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeAllergenes;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public ReadOnlyObservableCollection<Contenir> Contenir => _bdd.Contenir;
        public pgAllergenes()
        {
            InitializeComponent();
            _listeAllergenes = CollectionViewSource.GetDefaultView(_bdd.Allergenes);
            grpAllergenes.DataContext = _listeAllergenes;
        }
        private void AjouterAllergene(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvAllergenes.SelectedItem = _bdd.AjouterAllergenes("Nouveau Allergene"); }, nameof(AjouterAllergene));
        }
        private void SupprimerAllergene(object sender, RoutedEventArgs e)
        {
            Allergenes selection = (Allergenes)lvAllergenes.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien allergie {selection.Contenir} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerAllergenes(selection); }, nameof(SupprimerAllergene));
                }
            }
        }
        private void AjouterAllergeneAfficherInbox(object sender, RoutedEventArgs e)
        {
            
            //IAE_cmbArticle.SelectedItem = null;
            inboxAjouterAllergene.Visibility = Visibility.Visible;
        }
     private void AjouterAllergeneAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterAllergene.Visibility = Visibility.Collapsed; }

       // private void AjouterAllergeneConfirmerAction(object sender, RoutedEventArgs e)
       // {
       //     try
       //     {
       //         Allergenes lNouveauEcrire = _bdd.AjouterAllergenes((Article)IAE_cmbArticle.SelectedItem);
       //         inboxAjouterAllergene.Visibility = Visibility.Collapsed;
       //     }
       //     catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien allergene", MessageBoxButton.OK, MessageBoxImage.Warning); }
       // }

        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeAllergenes.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeAllergenes.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }


}
