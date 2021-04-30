using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace EnVrac
{
   public  class Categorie : INotifyPropertyChanged
    {
        [Key]
        public int ID { get; internal set; }

        public string Nom { get; set; }
        public ObservableCollection<SousCategorie> SousCategorie { get; private set; } = new ObservableCollection<SousCategorie>();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
