using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Model
{
    public class BookModel
    {
        public BookModel(int id, string title, int year, string genre, string author) 
        {
            Id = id;
            Title = title;
            Year = year;
            Genre = genre;
            Author = author;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

        public static (BookModel book, string Error) Create(int id, string title, int year, string genre, string author)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > 250)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            var book = new BookModel(id, title, year, genre, author);
            return (book, error);
        }
    }
}
