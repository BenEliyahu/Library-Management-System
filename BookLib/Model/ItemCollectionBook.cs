using System;
using System.Collections;
using System.Collections.Generic;
using static BookLib.AbstractItem;

namespace BookLib.Model
{
    public class ItemCollectionBook : IDataBook
    {
        public event Action MessageBoxISBN;
        public event Action MessageBoxMiss;
        public event Action<AbstractItem> AddItemEvent;
        public readonly static List<AbstractItem> Items = ItemCollection.Items;
        readonly Hashtable hashTable = ItemCollection.HashTable;


        public bool AddBook(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category, int series)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || isbn <= 0 || dateTime > DateTime.Now || string.IsNullOrEmpty(genre) || price <= 0 || discount <= 0 || series <= 0 || category == default)
            {
                MessageBoxMiss?.Invoke();
                return false;
            }
            var item = new Book(name, author, dateTime, genre, discount, price, isbn, category, series);
            try
            {
                hashTable.Add(isbn, item);
                Items.Add(item);
                AddItemEvent?.Invoke(item);
                return true;
            }
            catch (Exception)
            {
                MessageBoxISBN?.Invoke();
                return false;
            }
        }
    }
}
