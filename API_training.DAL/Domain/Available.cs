using System.ComponentModel.DataAnnotations;

namespace API_training.DAL.Domain
{
    /// <summary>
    /// Наличие в библиотеке
    /// </summary>
     public class Available : BaseEntityWithLinks<Books, Libraries>
    {
        /// <summary>
        /// Количество доступных единиц.
        /// </summary>
        [Required]
        public long Count { get; set; }
     }
}
