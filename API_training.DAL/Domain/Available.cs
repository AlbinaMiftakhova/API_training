namespace API_training.DAL.Domain
{
    /// <summary>
    /// Наличие в библиотеке
    /// </summary>
    public class Available : BaseEntityLinks<Books, Libraries>
    {
        /// <summary>
        /// Количество доступных книг
        /// </summary>
        public long Count { get; set; }
    }
}
