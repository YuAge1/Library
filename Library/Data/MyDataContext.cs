using Library.Model;

namespace Library.Data
{
    public class MyDataContext
    {
        public List<BookModel> Books { get; set; }

        public MyDataContext()
        {
            Books = new List<BookModel>();
        }
    }
}
