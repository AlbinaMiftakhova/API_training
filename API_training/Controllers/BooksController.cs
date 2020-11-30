using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_training.Models.DTO;
using API_training.Services.Interfaces;
using API_training.Common;
using System.Threading;
using System.Threading.Tasks;
using API_training.Models.Requests.Books;
using AutoMapper;

namespace API_training.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о книгах
    /// </summary>
    [Route("/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = DocumentPartsConst.Books)]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksController"/>
        /// </summary>
        /// <param name="booksService">Сервис книг</param>
        /// <param name="logger">Логгер</param>
        public BooksController(IBooksService booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        /// <summary>
        /// Получение перечня доступных книг
        /// </summary>
        /// <returns>Коллекция сущностей "Книги"</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Get was requested.");
            var response = await _booksService.GetAsync(cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Получение книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Сущность "Книга"</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Get by id was requested.");
            var response = await _booksService.GetAsync(id, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Добавляет книгу в список доступных книг
        /// </summary>
        /// <param book="book">Экземпляр книги</param>
        /// <returns>Новый список доступных книг</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public async Task<IActionResult> PostAsync(CreateBooksRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Post was requested.");
            var response = await _booksService.CreateAsync(_mapper.Map<DTOBooks>(request));
            return Ok(response);
        }

        /// <summary>
        /// Удаляет сущность "Книги" с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Новый список доступных книг</returns>
        [HttpDelete]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {

            _logger.LogInformation("Books/Delete was requested.");
            await _booksService.DeleteAsync(ids);
            return Ok();
        }

        /// <summary>
        /// Сортирует список сущностей "Книги" по названию
        /// </summary>
        /// <returns>Возвращает отсортированный список сущностей "Книги"</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public async Task<IActionResult> PutAsync(UpdateBooksRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Put was requested.");
            var response = _booksService.UpdateAsync(_mapper.Map<DTOBooks>(request));
            return Ok(response);
        }
    }
}