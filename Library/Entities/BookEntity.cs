namespace Library.Entities
{
    internal class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
