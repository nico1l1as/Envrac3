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
    /// Logique d'interaction pour pgContenir.xaml
    /// </summary>
    public partial class pgContenir : Page
    {
        clsBDDSingleton _bdd = clsBDDSingleton.Instance;
        ICollectionView _listeContenir;
        public ReadOnlyObservableCollection<Allergenes> Allergenes => _bdd.Allergenes;
        public ReadOnlyObservableCollection<Article> Articles => _bdd.Article;
        public pgContenir()
        {
            InitializeComponent();
            _listeContenir = CollectionViewSource.GetDefaultView(_bdd.Contenir);
            grpContenir.DataContext = _listeContenir;
        }
        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeContenir.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeContenir.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
