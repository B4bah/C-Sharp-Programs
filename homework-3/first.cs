using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class BookSearch
    {
        static void Main()
        {
            Book[] books = GetBooksFromFile("books.txt");
            int[] yearsRange = GetYearsFromUser();
            Book[] matchedBooks = FindMatchedBooks(books, period);
            PrintMatchedBooksInfo(matchedBooks);
        }

        struct Book
        {
            private string author;
            private string name;
            private int Year;

            public string Author { get { return author; } }
            public string Name { get { return name; } }
            public int Year { get { return year; } }

            public Book(string author, string name, int year)
            {
                this.author = author;
                this.name = name;
                this.year = year;
            }
        }

        // Declaration of functions
        static Book[] GetBooksFromFile(string filename)
        {
            string[] allLines = File.ReadAllLines(filename);
            Book[] books = new Book[allLines.Length];

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] lineParts = allLines[i].Split(' ');

                string author = lineParts[0];
                string name = lineParts[1];
                
            }

            return books;
        }
    }
}