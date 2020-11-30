namespace API_training.Models.Responses.Books
{
    /// <summary>
    /// Ответ на запросы для книг
    /// </summary>
    public class BooksResponse
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
