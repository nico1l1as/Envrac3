using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace EnVrac
{
    class ArticlesBDD : DbContext
    {
        #region Tables de la BDD
        internal DbSet<Allergenes> Allergenes { get; set; }
        internal DbSet<Article> Article { get; set; }
        internal DbSet<Categorie> Categorie { get; set; }
        internal DbSet<Contenir> Contenir { get; set; }
        internal DbSet<Etage> Etage { get; set; }
        internal DbSet<Etagere> Etagere { get; set; }
        internal DbSet<Pays> Pays { get; set; }
        internal DbSet<SousCategorie> SousCategorie { get; set; }
        internal DbSet<Unite> Unite { get; set; }
        #endregion

        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDBibliotheque.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contenir>().HasKey(sc => new { sc.ArticleID, sc.AllergenesID });

            modelBuilder.Entity<Allergenes>().HasData(
                new Allergenes() { ID = 1, Nom = "Lactose" },
                new Allergenes() { ID = 2, Nom = "Gluten" }
            );

        }
        internal Allergenes AjouterAllergenes(string nom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterAllergenes)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Allergenes lAllergene = new Allergenes() { Nom = nom };
            Allergenes.Local.Add(lAllergene);
            return lAllergene;
        }
        internal void SupprimerAllergenes(Allergenes allergenes)
        {
            //Gestion des erreurs
            if (allergenes == null) { throw new ArgumentNullException($"{nameof(SupprimerAllergenes)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Allergenes.Local.Remove(allergenes);
        }
        internal Article AjouterArticle(string nom, int quantite, int prixU, int prixKilo, DateTime restockage, DateTime peremption, string remarque, string specificite, string region, int colonne, SousCategorie sousCategorie, Etagere etagere, Pays pays, Unite unite )
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterArticle)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }
            //Ajout du nouvel auteur
            Article lArticle = new Article() { Nom = nom, Quantite = quantite, PrixU = prixU, PrixKilo = prixKilo, Restockage= restockage, Peremption = peremption, Remarque = remarque, Specificite = specificite, Region = region, Colonne = colonne, SousCategorie = sousCategorie, Etagere = etagere, Pays = pays, Unite = unite  };
            Article.Local.Add(lArticle);
            return lArticle;
        }
        internal void SupprimerArticle(Article article)
        {
            //Gestion des erreurs
            if (article == null) { throw new ArgumentNullException($"{nameof(SupprimerArticle)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Article.Local.Remove(article);
        }
        internal Categorie AjouterCategorie(string nom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterCategorie)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Categorie lCategorie = new Categorie() { Nom = nom };
            Categorie.Local.Add(lCategorie);
            return lCategorie;
        }
        internal void SupprimerCategorie(Categorie categorie)
        {
            //Gestion des erreurs
            if (categorie == null) { throw new ArgumentNullException($"{nameof(SupprimerCategorie)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Categorie.Local.Remove(categorie);
        }

        internal Etage AjouterEtage(string nom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterEtage)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Etage lEtage = new Etage() { Nom = nom };
            Etage.Local.Add(lEtage);
            return lEtage;
        }
        internal void SupprimerEtage(Etage etage)
        {
            //Gestion des erreurs
            if (etage == null) { throw new ArgumentNullException($"{nameof(SupprimerEtage)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Etage.Local.Remove(etage);
        }
        internal Etagere AjouterEtagere(string nom, Etage etage, byte longueur, byte x, byte y)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterEtagere)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (Etage == null) { throw new ArgumentNullException($"{nameof(AjouterEtagere)} : Le client doit avoir une ville (valeur NULL)."); }
            //Ajout du nouvel auteur
            Etagere lEtagere = new Etagere() { Nom = nom, Etage=etage, Longueur=longueur, X=x, Y=y  };
            Etagere.Local.Add(lEtagere);
            return lEtagere;
        }
        internal void SupprimerEtagere(Etagere etagere)
        {
            //Gestion des erreurs
            if (etagere == null) { throw new ArgumentNullException($"{nameof(SupprimerEtagere)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Etagere.Local.Remove(etagere);
        }
        internal Pays AjouterPays(string nom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterPays)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Pays lPays = new Pays() { Nom = nom };
           Pays.Local.Add(lPays);
            return lPays;
        }
        internal void SupprimerPays(Pays pays)
        {
            //Gestion des erreurs
            if (pays == null) { throw new ArgumentNullException($"{nameof(SupprimerPays)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Pays.Local.Remove(pays);
        }
        internal SousCategorie AjouterSousCategorie(string nom, Categorie categorie)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterSousCategorie)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            SousCategorie lSousCategorie = new SousCategorie() { Nom = nom, Categorie = categorie };
            SousCategorie.Local.Add(lSousCategorie);
            return lSousCategorie;
        }
        internal void SupprimerSousCategorie(SousCategorie sousCategorie)
        {
            //Gestion des erreurs
            if (sousCategorie == null) { throw new ArgumentNullException($"{nameof(SupprimerSousCategorie)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            SousCategorie.Local.Remove(sousCategorie);
        }
        internal Unite AjouterUnite(string nom)
        {
            //Gestion des erreurs
            if (nom == null || nom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterUnite)} : L'auteur doit avoir un nom (valeur NULL ou chaine vide)."); }

            //Ajout du nouvel auteur
            Unite lUnite = new Unite() { Nom = nom };
            Unite.Local.Add(lUnite);
            return lUnite;
        }
        internal void SupprimerUnite(Unite unite)
        {
            //Gestion des erreurs
            if (unite == null) { throw new ArgumentNullException($"{nameof(SupprimerUnite)} : Il faut un auteur en argument (valeur NULL)."); }
            //Suppression de l'auteur
            Unite.Local.Remove(unite);
        }
    }
}
