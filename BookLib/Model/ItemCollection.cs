using BookLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using static BookLib.AbstractItem;

namespace BookLib
{
    public class ItemCollection : IDataService
    {
        public readonly static List<AbstractItem> Items = new List<AbstractItem>();
        public event Action<List<AbstractItem>> RefrashEvent;
        public event Action MessageBoxISBN;
        public readonly static Hashtable HashTable = new Hashtable();

        public List<AbstractItem> Filter(object name1, object discount1, object isbn1, object price1, bool checkName, bool checkDiscount, bool checkPrice, bool checkISBN)
        {
            List<AbstractItem> list = new List<AbstractItem>();
            bool checkingItem = true;

            foreach (var item in Items)
            {
                if (checkISBN == true)
                {
                    string isbn = isbn1.ToString();
                    if (!item.ISBN.ToString().Contains(isbn.ToString())) checkingItem = false;
                }
                if (checkName == true)
                {
                    string name = name1.ToString();
                    if (!item.Name.ToUpper().Contains(name.ToUpper())) checkingItem = false;
                }
                if (checkDiscount == true)
                {
                    string discount = discount1.ToString();
                    if (!item.Discount.ToString().Contains(discount.ToString())) checkingItem = false;
                }
                if (checkPrice == true)
                {
                    string price = price1.ToString();
                    if (!item.Price.ToString().Contains(price.ToString())) checkingItem = false;
                }
                if (checkingItem)
                {
                    list.Add(item);
                }
                checkingItem = true;
            }
            RefrashEvent?.Invoke(list);
            return list;
        }
        public void ReturnAllCollection()
        {
            RefrashEvent?.Invoke(Items);
        }
        public bool EditItems(ref AbstractItem item, string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category)
        {
            if (!string.IsNullOrEmpty(name)) item.Name = name;
            if (!string.IsNullOrEmpty(author)) item.Author = author;
            if (!string.IsNullOrEmpty(dateTime.ToString()) && dateTime != DateTime.MinValue) item.Publishing = dateTime;
            if (!string.IsNullOrEmpty(genre)) item.Genre = genre;
            if (!string.IsNullOrEmpty(discount.ToString()) && discount != 0) item.Discount = discount;
            if (!string.IsNullOrEmpty(price.ToString()) && price != 0) item.Price = price;
            try
            {
                if (!string.IsNullOrEmpty(isbn.ToString()) && isbn != 0)
                {
                    HashTable.Add(isbn, item);
                    item.ISBN = isbn;
                }
            }
            catch (Exception)
            {
                MessageBoxISBN?.Invoke();
            }
            if (!string.IsNullOrEmpty(category.ToString()) && category != Category.None) item.Category1 = category;

            return true;
        }

        #region Indexers
        public AbstractItem this[string name]
        {
            get => Items.Find(item => item.Name == name);
        }
        public AbstractItem this[int isbn]
        {
            get => Items.Find(item => item.ISBN == isbn);
        }
        public AbstractItem this[double price, double discount]
        {
            get => Items.Find(item => item.Price == price && item.Discount == discount);
        }
        #endregion
    }
}


