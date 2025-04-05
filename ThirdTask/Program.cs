using System.Net;
using System.Reflection;

namespace ThirdTask
{
    internal class Program
    {
        class Book
        {
            public string Title { get; set;}
            public string Author { get; set; }
            public string ISBN { get; set; }         
            public bool IsAvailable { get; set; }
            public Book(string title, string author , string isbn)
            {
                Title = title;
                Author = author;
                ISBN = isbn;               
                IsAvailable = true;
        }
        }
        class Library
        {
          private  List<Book> books;
            public Library()
            {
                books = new List<Book>();
            }
            public void Addbook(Book book)
            {
                books.Add(book);
                Console.WriteLine("Book Added");
            }
            public void SearchBook(string keyword)
            {
                int i = 0;
                bool found = false;
                while (i < books.Count) 
                {
                    var book = books[i];
                    if (book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
                        found = true;
                    }
                    i++;
                }

                if (!found)
                {
                    Console.WriteLine("No books found with the given keyword.");
                }
            }
            public void BorrowBook(string isbn)
            {
                int i = 0;
                while(i< books.Count)
                {
                    if (books[i].ISBN == isbn)
                    {
                        if (books[i].IsAvailable)
                        {
                            books[i].IsAvailable = false;
                            Console.WriteLine("book borrowed successfuly"); ;
                        }
                        else
                        {
                            Console.WriteLine("Book is not availbale"); ;
                        }
                        return;
                    }
                    i++;
                }
                Console.WriteLine("book is not found");
            }
            public void ReturnBook(string isbn)
            {
                int i = 0;
                while(i< books.Count)
                {
                    if (books[i].ISBN == isbn)
                    {
                        if (!books[i].IsAvailable)
                        {
                            books[i].IsAvailable = true;
                            Console.WriteLine("book returned succesfully");
                        }
                        else
                        {
                            Console.WriteLine("book is alread returned");
                        }
                        return;
                    }
                    i++;
                }
                Console.WriteLine("book not found");
            }
        }
    
        static void Main(string[] args)
        {

            // add book
            // search for books
            //borrow books
            //return books 
            Library library = new Library();

            library.Addbook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "123456"));
            library.Addbook(new Book("To Kill a Mockingbird", "Harper Lee", "654321"));


            Console.WriteLine("Searching for 'Gatsby':");
            library.SearchBook("Gatsby");


            Console.WriteLine("Searching for 'Gatsby':");
            library.BorrowBook("123456");

            Console.WriteLine("Retruning book with ISBN 123456:");
            library.ReturnBook("123456");
            Console.ReadLine();
        }
    }
}
