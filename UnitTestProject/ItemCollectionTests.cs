using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib.Model;

namespace BookLib.Tests
{
    [TestClass()]
    public class ItemCollectionTests
    {
        ItemCollection collection = new ItemCollection();
        ItemCollectionBook bookCollection = new ItemCollectionBook();
        ItemCollectionJournal journalCollection = new ItemCollectionJournal();
        Book book = new Book("ben", "eliyahu", DateTime.Now, "drama", 4.7, 60, 2, AbstractItem.Category.Kitchen, 3);
        Journal journal = new Journal("ben", "eliyahu", DateTime.Now, "drama", 4.7, 60, 2, AbstractItem.Category.Kitchen, 3);


        [TestMethod()]
        public void AddBookTest() => Assert.IsTrue(bookCollection.AddBook(book.Name, book.Author, book.Publishing, book.Genre, book.Discount, book.Price, book.ISBN, book.Category1, book.Series));


        [TestMethod()]
        public void AddJournalTest() => Assert.IsTrue(journalCollection.AddJournal(journal.Name, journal.Author, journal.Publishing, journal.Genre, journal.Discount, journal.Price, journal.ISBN, journal.Category1, journal.Legion));


        [TestMethod()]
        public void FilterTest() => Assert.IsTrue(collection.Filter("ben", "5", "4", "40", true, false, true, true).GetType() == typeof(List<AbstractItem>));


        [TestMethod()]
        public void ReturnAllCollectionTest()
        {
            try
            {
                collection.ReturnAllCollection();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod()]
        public void EditItems()
        {
            var Abstract = book as AbstractItem;
            Assert.IsTrue(collection.EditItems(ref Abstract, "ben", "eliyahu", DateTime.Now, "drama", 4.8, 50, 5, AbstractItem.Category.Kids));
        }
    }
}