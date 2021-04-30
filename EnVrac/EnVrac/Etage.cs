using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EnVrac
{
   public  class Etage : INotifyPropertyChanged
    {
        [Key]
        public int ID { get; internal set; }

        public string Nom { get; set; }

        public ObservableCollection<Etagere> Etagere { get; private set; } = new ObservableCollection<Etagere>();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
