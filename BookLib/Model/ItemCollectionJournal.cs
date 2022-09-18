using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLib.AbstractItem;

namespace BookLib.Model
{
    public class ItemCollectionJournal : IDataJournal
    {
        public event Action MessageBoxISBN;
        public event Action MessageBoxMiss;
        public readonly static List<AbstractItem> Items = ItemCollection.Items;
        public event Action<AbstractItem> AddItemEvent;

        readonly Hashtable hashTable = ItemCollection.HashTable;

        public bool AddJournal(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category, int legion)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || isbn <= 0 || dateTime > DateTime.Now || string.IsNullOrEmpty(genre) || price <= 0 || discount <= 0 || legion <= 0 || category == default)
            {
                MessageBoxMiss?.Invoke();
                return false;
            }
            var item = new Journal(name, author, dateTime, genre, discount, price, isbn, category, legion);
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
