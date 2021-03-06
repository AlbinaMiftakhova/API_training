﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(25)]
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Телефон библиотеки
        /// </summary>
        [StringLength(25)]
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Сайт библиотеки
        /// </summary>
        [StringLength(25)]
        [Required]
        public string Website { get; set; }

        /// <summary>
        /// Наличие книг в данной библиотеке
        /// </summary>
        public ICollection<Available> Availabilities { get; set; }
    }
}
