using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book : AbstractItem
    {
        public int Series { get; set; }
        public Book(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn,Category category, int series) : base(name, author, dateTime, genre, discount, price, isbn, category)
        {
            Name = name;
            Author = author;
            Publishing = dateTime;
            Genre = genre;
            Discount = discount;
            Price = price;
            ISBN = isbn;
            Category1 = category;
            Series = series;
        }

    }
}
