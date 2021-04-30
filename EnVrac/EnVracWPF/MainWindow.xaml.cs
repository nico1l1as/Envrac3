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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnVracWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BDDSingleton BDD = BDDSingleton.Instance;
        public MainWindow()
        {
            InitializeComponent();
            Cadre.NavigationService.Navigate(new pgArticle());
        }
        private void AfficherAllergenes(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgAllergenes()); }
        private void AfficherArticle(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgArticle()); }
        private void AfficherCategorie(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgCategorie()); }
        private void AfficherContenir(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgContenir()); }
        private void AfficherEtage(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgEtage()); }
    }
    private void SauvegarderModifications(object sender, RoutedEventArgs e)
    {
        BDD.SauvegarderModifications();
        MessageBox.Show("Modifications sauvegardées dans la base de données.", "Sauvegarde des modifications", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    private void Quitter(object sender, RoutedEventArgs e) { this.Close(); }

    private void NavServiceOnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e) { while (Cadre.NavigationService.RemoveBackEntry() != null) ; }
    private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (BDD.ModificationsEnAttente)
        {
            if (MessageBox.Show("Il y a des modifications en attente voulez vous les sauvegarder avant de quitter ?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                if (MessageBox.Show("La fermeture de l'application va entrainer la perte des modifications non sauvegardées dans la base de données. Etes-vous sûr de vouloir fermer l'application?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            else { BDD.SauvegarderModifications(); }
        }
    }
}
