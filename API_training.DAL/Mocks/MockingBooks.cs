using API_training.DAL.Domain;
using System.Collections.Generic;

namespace API_training.DAL.Mocks
{
    /// <summary>
    /// Mocking-объект для коллекции сущностей "Книги"
    /// </summary>
    public static class MockingBooks
    {
        /// <summary>
        /// Коллекция сущностей "Книги"
        /// </summary>
        public static List<Books> Books = new List<Books>
        {
            new Books{Id=1, Author = "Лев Толстой", Name="Война и мир", Publisher = "Лексика", PublishingYear=1996},
            new Books{Id=2, Author = "Михаил Булгаков", Name="Мастер и Маргарита", Publisher = "Аст", PublishingYear=2016},
            new Books{Id=3, Author = "Федор Достоевский", Name="Братья Карамазовы", Publisher = "PocketBook", PublishingYear=2017}
        };
    }
}
