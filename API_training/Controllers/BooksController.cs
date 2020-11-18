using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_training.Models.DTO;
using API_training.Services.Interfaces;
using API_training.Common;

namespace API_training.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о книгах.
    /// </summary>
    [Route("/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = DocumentPartsConst.Books)]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksInterface _booksService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksController"/>
        /// </summary>
        /// <param name="booksService">Сервис одежды.</param>
        /// <param name="logger">Логгер.</param>
        public BooksController(IBooksInterface booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        /// <summary>
        /// Получение перечня доступных книг.
        /// </summary>
        /// <returns>Коллекция сущностей "Книги".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult Get()
        {
            _logger.LogInformation("Books/Get was requested.");
            var response = _booksService.Get();
            return Ok(response);
        }

        /// <summary>
        /// Получение книги по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Сущность "Книга"</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult GetById(long id)
        {
            _logger.LogInformation("Books/Get by id was requested.");
            var response = _booksService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Добавляет книгу в список доступных книг.
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <param name="author">Автор книги</param>
        /// <param name="id">Идентификатор книги</param>
        /// <param name="publisher">Издательство</param>
        /// <param name="publishingYear">Год издания</param>
        /// <returns>Новый список доступных книг.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult AddBook(string name, string author, long id, string publisher, int publishingYear)
        {
            _logger.LogInformation("Books/Post was requested.");
            var response = _booksService.Post(name, author, id, publisher, publishingYear);
            return Ok(response);
        }

        /// <summary>
        /// Удаляет сущность "Книги" с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Новый список доступных книг.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult DeleteBook(long id)
        {
            _logger.LogInformation("Books/Delete was requested.");
            var response = _booksService.Delete(id);
            return Ok(response);
        }

        /// <summary>
        /// Сортирует список сущностей "Книги" по названию.
        /// </summary>
        /// <returns>Возвращает отсортированный список сущностей "Книги"</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult SortByName()
        {
            _logger.LogInformation("Books/Put was requested.");
            var response = _booksService.SortByName();
            return Ok(response);
        }
    }
}
