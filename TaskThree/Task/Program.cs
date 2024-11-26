using System.Reflection;
using System.Threading.Channels;

namespace Task
{
    public class Book
    {
        string title;
        string author;
        string isbn;
        bool availability;

        public Book(string title, string author, string isbn, bool availability = true)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availability = availability;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public string GetIsbn()
        {
            return isbn;
        }
        public bool GetAvailability()
        {
            return availability;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetISBN(string isbn)
        {
            this.isbn = isbn;
        }
        public void SetAvailability(bool availability)
        {
            this.availability = availability;
        }
    }
    public class Library
    {
        public List<Book> books;

        public Library()
        {
            this.books = new List<Book>();

        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("The book was added successfully");
        }

        public void SearchBook(string title = "", string author = "")
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle() == title)
                {
                    Console.WriteLine($"Book found: Title = '{books[i].GetTitle()}'");
                    return; 
                }
                if (books[i].GetAuthor() == author)
                {
                    Console.WriteLine($"Book found: Title = '{books[i].GetTitle()}'");
                    return; 
                }
            }
            Console.WriteLine("No matching book found.");
        }

        public void BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle() == title && books[i].GetAvailability() == true)
                {
                    books[i].SetAvailability(false);
                    Console.WriteLine($"You have borrowed the book: {books[i].GetTitle()}");
                    return; 
                }
                else if (books[i].GetTitle() == title && !books[i].GetAvailability())
                {
                    Console.WriteLine($"The book {books[i].GetTitle()} is not available");
                    return; 
                }
            }
            Console.WriteLine("This book is not in the library");
        }

        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle() == title)
                {
                    if (!books[i].GetAvailability())
                    {
                        books[i].SetAvailability(true);
                        Console.WriteLine($"You have successfully returned '{books[i].GetTitle()}'");
                        return;
                        
                    }             
                }
            }
            Console.WriteLine("This book is not borrowed");
            return;

        }


        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();

                // Adding books to the library
                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
                library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

                // Searching and borrowing books
                Console.WriteLine("Searching and borrowing books...");
                library.SearchBook("Gatsby");
                library.BorrowBook("Gatsby");
                library.SearchBook("1984");
                library.BorrowBook("1984");
                library.SearchBook("Harry Potter");
                library.BorrowBook("Harry Potter");// This book is not in the library

                // Returning books
                Console.WriteLine("\nReturning books...");
                library.ReturnBook("Gatsby");
                library.ReturnBook("1984");
                library.BorrowBook("1984");
                library.ReturnBook("Harry Potter"); // This book is not borrowed
            
            }
        }
    }
}
