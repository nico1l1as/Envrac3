using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EnVrac
{

    public class Contenir : INotifyPropertyChanged
    {
       
        [Key]
        public int ArticleID { get; set; }
       
        public Article Article { get; set; }
       
        public int AllergenesID { get; set; }
        public Allergenes Allergenes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
