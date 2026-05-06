namespace Acervo.Domain.Entities
{
    public class Book
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Release { get; set; }
    }
}
