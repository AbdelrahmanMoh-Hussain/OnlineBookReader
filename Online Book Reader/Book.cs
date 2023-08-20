using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Book
    {
        public Book(string iSBN, string title, string authorName, int numberOfPages, string[] pages)
        {
            ISBN = iSBN;
            Title = title;
            AuthorName = authorName;
            NumberOfPages = numberOfPages;
            Pages = pages;
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int NumberOfPages { get; set; }
        public string[] Pages { get; set; }

        public string this[int index]
        {
            get { return Pages[index]; }
            set { Pages[index] = value; }
        }
    }
}
