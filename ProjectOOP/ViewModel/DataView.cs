using BookLib;
using BookLib.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using static BookLib.AbstractItem;

namespace ProjectOOP.ViewModel
{
    public class DataView : ViewModelBase
    {
        private readonly IDataService service;
        private readonly IDataJournal journal;
        private readonly IDataBook book;

        public ObservableCollection<AbstractItem> Items { get; set; }

        private ICollectionView collection;
        public ICollectionView Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }
        private AbstractItem selectItem;
        public AbstractItem SelectItem
        {
            get { return selectItem; }
            set
            {
                Set(ref selectItem, value);
            }
        }

        #region Prop Edit
        private string editName;
        private int editISBN;
        private string editAuthor;
        private double editDiscount;
        private double editPrice;
        private Category editCategory;
        private DateTime editPublishing;
        private string editGenre;
        public double EditPrice { get { return editPrice; } set { Set(ref editPrice, value); } }
        public int EditISBN { get { return editISBN; } set { Set(ref editISBN, value); } }
        public string EditName { get { return editName; } set { Set(ref editName, value); } }
        public string EditAuthor { get { return editAuthor; } set { Set(ref editAuthor, value); } }
        public double EditDiscount
        {
            get
            {
                if (EditCategory.HasFlag(Category.Adults) && editDiscount < 5) editDiscount = 5;
                if (EditCategory.HasFlag(Category.Kids) && editDiscount < 10) editDiscount = 10;
                if (EditCategory.HasFlag(Category.Kitchen) && editDiscount < 15) editDiscount = 15;
                if (EditCategory.HasFlag(Category.Sport) && editDiscount < 20) editDiscount = 20;
                if (EditCategory.HasFlag(Category.Youth) && editDiscount < 22) editDiscount = 22;

                return editDiscount;
            }
            set { Set(ref editDiscount, value); }
        }
        public Category EditCategory { get { return editCategory; } set { Set(ref editCategory, value); } }
        public DateTime EditPublishing { get { return editPublishing; } set { Set(ref editPublishing, value); } }
        public string EditGenre { get { return editGenre; } set { Set(ref editGenre, value); } }
        public RelayCommand Edit { get; set; }
        #endregion

        public Array AbstractEnum => Enum.GetValues(typeof(Category));
        public DataView(IDataService service, IDataJournal journal, IDataBook book)
        {
            this.service = service;
            this.journal = journal;
            this.book = book;
            Items = new ObservableCollection<AbstractItem>();
            service.RefrashEvent += RefreshList;
            Collection = CollectionViewSource.GetDefaultView(Items);
            journal.AddItemEvent += AddItem;
            book.AddItemEvent += AddItem;
            journal.MessageBoxISBN += MessageToList;
            book.MessageBoxISBN += MessageToList;
            service.MessageBoxISBN += MessageToList;
            book.MessageBoxMiss += AddMessegeIfNull;
            journal.MessageBoxMiss += AddMessegeIfNull;
            Edit = new RelayCommand(EditItem);
        }
        private void AddItem(AbstractItem item) => Items.Add(item);
        private void EditItem()
        {
            if (selectItem != null)
            {
                Collection.Refresh();
                service.EditItems(ref selectItem, editName, editAuthor, editPublishing, editGenre, editDiscount, editPrice, editISBN, editCategory);
                EditName = EditAuthor = EditGenre = ""; EditDiscount = EditPrice = EditISBN = 0; EditPublishing = DateTime.MinValue;
            }
        }
        private void AddMessegeIfNull() => MessageBox.Show("Error! You need to fill in all the fields", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);

        private void MessageFilter()
        {
            MessageBox.Show("There is no suitable item", "Notice!");
        }
        private void MessageToList()
        {
            MessageBox.Show("ISBN has already been created. Please select another ISBN", "Notice!");
        }
        private void RefreshList(List<AbstractItem> list)
        {
            if (list != null && list.Count != 0)
            {
                Items.Clear();
                foreach (AbstractItem item in list)
                {
                    Items.Add(item);
                }
            }
            else MessageFilter();
        }
    }
}
