using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnVrac
{
    public class Unite : INotifyPropertyChanged
    {
        [Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; internal set; }

        public string Nom { get; set; }

        public ObservableCollection<Article> Article { get; private set; } = new ObservableCollection<Article>();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
