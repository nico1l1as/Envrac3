using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnVrac
{
    public class Pays : INotifyPropertyChanged
    {
        [Key]
        public int ID { get; internal set; }

        public string Nom { get; set; }

        public ObservableCollection<Article> Article { get; private set; } = new ObservableCollection<Article>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
