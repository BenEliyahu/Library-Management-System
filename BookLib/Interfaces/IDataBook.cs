using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLib.AbstractItem;

namespace BookLib.Model
{
    public interface IDataBook
    {
        event Action MessageBoxISBN;
        event Action MessageBoxMiss;
        event Action<AbstractItem> AddItemEvent;

        bool AddBook(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category, int series);

    }
}
