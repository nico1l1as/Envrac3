using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnVrac
{
   public class Allergenes : INotifyPropertyChanged
    {
        [Key]
        public int ID { get; internal set; }
        
        public string Nom { get; set; }

        public ObservableCollection<Contenir> Contenir { get; private set; } = new ObservableCollection<Contenir>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
