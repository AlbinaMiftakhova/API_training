namespace API_training.Database.Domain
{
    /// <summary>
    /// Книги
    /// </summary>
    public class Books
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int PublishingYear { get; set; }
    }
}
