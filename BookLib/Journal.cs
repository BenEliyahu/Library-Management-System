using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Journal : AbstractItem
    {
        public int Legion { get; set; }
        public Journal(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category,int legion) : base(name,author,dateTime,genre,discount,price,isbn,category)
        {
            Name = name;
            Author = author;
            Publishing = dateTime;
            Genre = genre;
            Discount = discount;
            Price = price;
            ISBN = isbn;
            Category1 = category;
            Legion = legion;
        }
    }
}
