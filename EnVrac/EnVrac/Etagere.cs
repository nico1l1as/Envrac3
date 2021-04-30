using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EnVrac
{
    public class Etagere : INotifyPropertyChanged
    {
        [Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; internal set; }

        public Etage Etage { get; set; }
        public int EtageID { get;internal set; }

        public string Nom { get; set; }

        public byte Longueur { get; set; }

        public byte X { get; set; }

        public byte Y { get; set; }

        public ObservableCollection<Article> Article { get; private set; } = new ObservableCollection<Article>();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
