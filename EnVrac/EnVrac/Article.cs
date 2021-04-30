using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace EnVrac
{
    public class Article : INotifyPropertyChanged
    {
        [Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; internal set; }
        public string Nom { get; set;}

        private int cQuantite = 0;
        public int Quantite { 
            get => cQuantite;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Le nombre d'article ne peut pas être plus petit que un.");
                }
                cQuantite = value;
                }}
        private int cPrixU = 0;
        public int PrixU {
            get => cPrixU;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le prix unitaire de l'article ne peut pas être plus petit que zero.");
                }
                cPrixU = value;
            }
        }

        private int cPrixKilo = 0;
        public int PrixKilo {
            get => cPrixKilo;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le prix au kilo de l'article ne peut pas être plus petit que zero.");
                }
                cPrixKilo = value;
            }
        }
        public DateTime Restockage { get; set; }
        public DateTime Peremption { get; set; }
        public string Remarque { get; set; }
        public string Specificite { get; set; }
        public string Region { get; set; }

        private int cColonne = 0;
        public int Colonne {
            get => cColonne;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La colonne de l'article ne peut pas être plus petite que zero.");
                }
                cColonne = value;
            }
        }





        /// <summary>
        /// Cardinalité de type [1:N], côté 1 : 1 Ville par client.
        /// </summary>
        public SousCategorie SousCategorie { get; set; }
        public int SousCategorieID { get; internal set; }

        public Etagere Etagere { get; set; }
        public int EtagereID { get; internal set; }

        public Pays Pays { get; set; }
        public int PaysID { get; internal set; }

        public Unite Unite { get; set; }
        public int UniteID { get; internal set; }


        public ObservableCollection<Allergenes> Allergenes { get; private set; } = new ObservableCollection<Allergenes>();
       
        //public ObservableCollection<Pays> Pays { get; private set; } = new ObservableCollection<Pays>();
        //public ObservableCollection<Unite> Unite { get; private set; } = new ObservableCollection<Unite>();

        public event PropertyChangedEventHandler PropertyChanged;
       
    }
}
