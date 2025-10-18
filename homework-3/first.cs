using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class BookSearch
    {
        // Main unit
        static void Main()
        {
            Book[] books = GetBooksFromFile("books.txt");
            int[] yearsRange = GetYearsFromUser();
            Book[] matchedBooks = FindMatchedBooks(books, yearsRange);
            PrintMatchedBooksInfo(matchedBooks);
        }

        // Declaration of existing structures
        struct Book
        {
            private string author;
            private string name;
            private int year;

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
                string[] lineParts = allLines[i].Split('"');
                string author = lineParts[0].Trim();
                string name = lineParts[1];
                int year = Convert.ToInt32(lineParts[2].Trim());
                books[i] = new Book(author, name, year);
            }

            return books;
        }

        static int[] GetYearsFromUser()
        {
            Console.Write("Enter the years range, divided by space:\n>>> ");
            string[] yearsString = Console.ReadLine().Split(' ');
            int[] years = { Convert.ToInt32(yearsString[0]), Convert.ToInt32(yearsString[1]) };

            return years;
        }

        static int[] SortYears(int[] years)
        {
            if (years[0] < years[1])
            {
                return years;
            }
            else
            {
                int yearTemp = years[0];
                years[0] = years[1];
                years[1] = yearTemp;
                
                return years;
            }
        }

        static Book[] FindMatchedBooks(Book[] books, int[] yearsRange)
        {
            List<Book> foundBooks = new List<Book>();

            int[] sortedYears = SortYears(yearsRange);

            for (int i = 0; i < books.Length; i++)
            {
                if (sortedYears[0] <= books[i].Year && books[i].Year <= sortedYears[1])
                {
                    foundBooks.Add(books[i]);
                }
            }

            return foundBooks.ToArray();
        }

        static void PrintMatchedBooksInfo(Book[] books)
        {
            Console.WriteLine("Books that were published in that pedriod:" + books.Length);
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{books[i].Author}: \"{books[i].Name}\", published in {books[i].Year}");
            }
        }
    }
}