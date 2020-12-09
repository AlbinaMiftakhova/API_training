using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_training.DAL.Domain
{
    /// <summary>
    /// Библиотеки
    /// </summary>
    public class Libraries : BaseEntity
    {
        /// <summary>
        /// Адрес библиотеки
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Телефон библиотеки.
        /// </summary>
        [StringLength(25)]
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Сайт библиотеки.
        /// </summary>
        [StringLength(25)]
        [Required]
        public string Website { get; set; }

        /// <summary>
        /// Наличие книг в библиотеке.
        /// </summary>
        public ICollection<Available> Availability { get; set; }
    }
}
