using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public abstract class AbstractItem
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Publishing { get; set; }
        public string Genre { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public int ISBN { get; set; }
        public Category Category1 { get; set; }
        public AbstractItem(string name, string author, DateTime dateTime, string genre, double discount, double price, int isbn, Category category)
        {
            Name = name;
            Author = author;
            Publishing = dateTime;
            Genre = genre;
            Discount = discount;
            Price = price;
            ISBN = isbn;
            Category1 = category;
        }
        public enum Category
        {
            None = 0,
            Kitchen = 0b0001,
            Kids = 0b0010,
            Sport = 0b001011,
            Adults = 0b0100,
            Youth = 0b0101
        }
    }
}
