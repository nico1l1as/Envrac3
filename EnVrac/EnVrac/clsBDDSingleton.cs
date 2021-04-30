using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;



namespace EnVrac
{
    public class clsBDDSingleton
    {
        
        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        public static clsBDDSingleton Instance { get; set; } = new clsBDDSingleton();
        private ArticlesBDD BDD { get; set; }
        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        public ReadOnlyObservableCollection<Allergenes> Allergenes { get; private set; }
        public ReadOnlyObservableCollection<Article> Article { get; private set; }
        public ReadOnlyObservableCollection<Categorie> Categorie { get; private set; }
        public ReadOnlyObservableCollection<Contenir> Contenir { get; private set; }
        public ReadOnlyObservableCollection<Etage> Etage { get; private set; }
        public ReadOnlyObservableCollection<Etagere> Etagere { get; private set; }
        public ReadOnlyObservableCollection<Pays> Pays { get; private set; }
        public ReadOnlyObservableCollection<SousCategorie> SousCategorie { get; private set; }
        public ReadOnlyObservableCollection<Unite> Unite { get; private set; }

        #endregion

        #region Constructeur de la classe
        public clsBDDSingleton()
        {
            BDD = new ArticlesBDD();
            BDD.Database.EnsureCreated();
            BDD.Allergenes.Load();
            Allergenes = new ReadOnlyObservableCollection<Allergenes>(BDD?.Allergenes.Local.ToObservableCollection());
            BDD.Article.Load();
            Article = new ReadOnlyObservableCollection<Article>(BDD?.Article.Local.ToObservableCollection());
            BDD.Categorie.Load();
            Categorie = new ReadOnlyObservableCollection<Categorie>(BDD?.Categorie.Local.ToObservableCollection());
            BDD.Contenir.Load();
            Contenir = new ReadOnlyObservableCollection<Contenir>(BDD?.Contenir.Local.ToObservableCollection());
            BDD.Etage.Load();
            Etage = new ReadOnlyObservableCollection<Etage>(BDD?.Etage.Local.ToObservableCollection());
            BDD.Etagere.Load();
            Etagere = new ReadOnlyObservableCollection<Etagere>(BDD?.Etagere.Local.ToObservableCollection());
            BDD.Pays.Load();
            Pays = new ReadOnlyObservableCollection<Pays>(BDD?.Pays.Local.ToObservableCollection());
            BDD.SousCategorie.Load();
            SousCategorie = new ReadOnlyObservableCollection<SousCategorie>(BDD?.SousCategorie.Local.ToObservableCollection());
            BDD.Unite.Load();
            Unite = new ReadOnlyObservableCollection<Unite>(BDD?.Unite.Local.ToObservableCollection());
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Allergenes AjouterAllergenes(string nom) { return BDD?.AjouterAllergenes(nom); }

        public Article AjouterArticle(string nom) { return BDD?.AjouterArticle(nom); }
       
        public Categorie AjouterCategorie(string nom) { return BDD?.AjouterCategorie(nom); }

        

        public Etage AjouterEtage(string nom) { return BDD?.AjouterEtage(nom); }

        public Etagere AjouterEtagere(string nom, Etage etage) { return BDD?.AjouterEtagere(nom, etage); }

        public Pays AjouterPays(string nom) { return BDD?.AjouterPays(nom); }

        public SousCategorie AjouterSousCategorie(string nom) { return BDD?.AjouterSousCategorie(nom); }

        public Unite AjouterUnite (string nom) { return BDD?.AjouterUnite(nom); }

        public void SupprimerAllergenes(Allergenes allergenes) { BDD?.SupprimerAllergenes(allergenes); }

        public void SupprimerArticle(Article article) { BDD?.SupprimerArticle(article); }
        public void SupprimerCategorie(Categorie categorie) { BDD?.SupprimerCategorie(categorie); }
        
        public void SupprimerEtage(Etage etage) { BDD?.SupprimerEtage(etage); }

        public void SupprimerEtagere(Etagere etagere) { BDD?.SupprimerEtagere(etagere); }
        public void SupprimerPays(Pays pays) { BDD?.SupprimerPays(pays); }
        public void SupprimerSousCategorie(SousCategorie sousCategorie) { BDD?.SupprimerSousCategorie(sousCategorie); }
        public void SupprimerUnite(Unite unite) { BDD?.SupprimerUnite(unite); }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion

    }

}
