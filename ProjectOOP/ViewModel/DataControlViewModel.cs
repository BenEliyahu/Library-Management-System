using BookLib;
using BookLib.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using static BookLib.AbstractItem;

namespace ProjectOOP.ViewModel
{
    public class DataControlViewModel : ViewModelBase
    {
        private readonly IDataJournal journal;
        private readonly IDataBook book;
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand AddJournalCommand { get; set; }

        #region Prop Add To List
        private double _discount;
        private string _name;
        private string _author;
        private string _genre;
        private DateTime _dateTime;
        private double _price;
        private Category _category;
        private int _series;
        private int _legion;
        private int _isbn;
        public string Name { get { return _name; } set { Set(ref _name, value); } }
        public string Author { get { return _author; } set { Set(ref _author, value); } }
        public DateTime Publishing { get { return _dateTime; } set { Set(ref _dateTime, value); } }
        public string Genre { get { return _genre; } set { Set(ref _genre, value); } }
        public double Discount
        {
            get
            {
                if (Category1.HasFlag(Category.Adults) && _discount < 5) _discount = 5;
                if (Category1.HasFlag(Category.Kids) && _discount < 10) _discount = 10;
                if (Category1.HasFlag(Category.Kitchen) && _discount < 15) _discount = 15;
                if (Category1.HasFlag(Category.Sport) && _discount < 20) _discount = 20;
                if (Category1.HasFlag(Category.Youth) && _discount < 22) _discount = 22;

                return _discount;
            }
            set { Set(ref _discount, value); }
        }
        public double Price { get { return _price; } set { Set(ref _price, value); } }
        public int ISBN { get { return _isbn; } set { Set(ref _isbn, value); } }
        public Category Category1 { get { return _category; } set { Set(ref _category, value); } }
        public int Series { get { return _series; } set { Set(ref _series, value); } }
        public int Legion { get { return _legion; } set { Set(ref _legion, value); } }
        #endregion

        public Array AbstractEnum => Enum.GetValues(typeof(Category));
        public DataControlViewModel(IDataBook book, IDataJournal journal)
        {
            this.book = book;
            this.journal = journal;
            AddJournalCommand = new RelayCommand(AddJournal);
            AddBookCommand = new RelayCommand(AddBook);
        }
        private void AddBook()
        {
            book.AddBook(Name, Author, Publishing, Genre, Discount, Price, ISBN, Category1, Series);
            Name = Author = Genre = ""; Discount = Price = ISBN = Series = 0; Publishing = DateTime.MinValue; Category1 = Category.None;
        }
        private void AddJournal()
        {
            journal.AddJournal(Name, Author, Publishing, Genre, Discount, Price, ISBN, Category1, Legion);
            Name = Author = Genre = ""; Discount = Price = ISBN = Legion = 0; Publishing = DateTime.MinValue; Category1 = Category.None;
        }
    }
}
