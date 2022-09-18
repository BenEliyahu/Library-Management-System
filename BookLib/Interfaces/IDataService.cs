using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static BookLib.AbstractItem;

namespace BookLib.Model
{
    public interface IDataService
    {
        event Action<List<AbstractItem>> RefrashEvent;
        event Action MessageBoxISBN;

        List<AbstractItem> Filter(object name, object discount, object isbn, object price, bool checkName, bool checkDiscount, bool checkPrice, bool checkISBN);
        void ReturnAllCollection();
        bool EditItems(ref AbstractItem item, string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category);
    }
}
