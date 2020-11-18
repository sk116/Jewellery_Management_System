using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace Jewellery_Management_System.Models
{
    [Serializable]
    public class Owner : INotifyPropertyChanged
    {
        public string ShopName { get; set; }
        public string Name { get; set; }

        public float GoldPrice { get; set; }

        public string MobileNo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
