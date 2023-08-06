using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Session
    {
        private Book book;
        private int numberOfPagesRead;
        private int totalBookPages;
        private DateTime date;

        public Session(Book book, int numberOfPagesRead, DateTime date)
        {
            this.book = book;
            this.numberOfPagesRead = numberOfPagesRead;
            this.totalBookPages = book.NumberOfPages;
            this.date = date;
        }

        public Book Book { get { return book; } }
        public int NumberOfPagesRead { get { return numberOfPagesRead; } }

        public override string ToString()
        {
            return $"{book.Title}: {numberOfPagesRead}/{totalBookPages} - {this.date}";
        }
    }
}
