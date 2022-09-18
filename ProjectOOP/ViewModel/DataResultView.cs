using BookLib.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using static BookLib.AbstractItem;

namespace ProjectOOP.ViewModel
{
    public class DataResultView : ViewModelBase
    {
        private readonly IDataService _service;

        #region Prop Result
        public string Name { get; set; }
        public double Discount { get; set; }
        public int ISBN { get; set; }
        public double Price { get; set; }
        public bool CheckName { get; set; }
        public bool CheckDiscount { get; set; }
        public bool CheckPrice { get; set; }
        public bool CheckISBN { get; set; }
        #endregion

        public RelayCommand Filterbtn { get; set; }
        public RelayCommand AllCollection { get; set; }
        public DataResultView(IDataService service)
        {
            _service = service;
            Filterbtn = new RelayCommand(Filter);
            AllCollection = new RelayCommand(service.ReturnAllCollection);
        }
        private void Filter() => _service.Filter(Name, Discount, ISBN, Price, CheckName, CheckDiscount, CheckPrice, CheckISBN);
    }
}