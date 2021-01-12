namespace BookDepo.Dtos
{
    public class BookReadDto
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public string Title { get; set; }
    
        public int PublishedYear { get; set; }

        public string Publisher { get; set; }
    }
}