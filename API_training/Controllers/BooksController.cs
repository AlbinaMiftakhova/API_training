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
using API_training.Models.Responses.Books;
using API_training.Repositories;

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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        private readonly IBooksService _booksService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksController"/>
        /// </summary>
        /// <param name="repo">Репозиторий</param>
        /// <param name="logger">Логгер</param>
        /// <param name="mapper">Маппер</param>
        public BooksController(IUnitOfWork repo, ILogger<BooksController> logger, IMapper mapper, IBooksService booksService)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            _booksService = booksService;
        }


        /// <summary>
        /// Получение перечня доступных книг
        /// </summary>
        /// <returns>Коллекция сущностей "Книги"</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Get was requested.");
            var response = await _repo.BooksRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<BooksResponse>>(response));
        }

        /// <summary>
        /// Получение книги по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Сущность "Книга"</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Get by id was requested.");
            var response = await _repo.BooksRepository.GetAsync(id);
            return Ok(_mapper.Map<BooksResponse>(response));
        }

        /// <summary>
        /// Добавляет книгу в список доступных книг
        /// </summary>
        /// <param book="book">Экземпляр книги</param>
        /// <returns>Возвращает экземпляр добавленной книги</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> PostAsync(CreateBooksRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Post was requested.");
            var response = await _repo.BooksRepository.CreateAsync(_mapper.Map<BookDTO>(request));
            return Ok(_mapper.Map<BooksResponse>(response));
        }

        /// <summary>
        /// Удаляет сущность "Книги" с заданным идентификатором
        /// </summary>
        /// <param name="ids">Идентификаторы книг</param>
        /// <returns>Новый список доступных книг</returns>
        [HttpDelete]
        [Route("{ids:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {

            _logger.LogInformation("Books/Delete was requested.");
            await _repo.BooksRepository.DeleteAsync(ids);
            return Ok();
        }

        /// <summary>
        /// Изменение сущности Книги
        /// </summary>
        /// <returns>Возвращает измененную сущность</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDTO>))]
        public async Task<IActionResult> PutAsync(UpdateBooksRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Books/Put was requested.");
            var response = await _repo.BooksRepository.UpdateAsync(_mapper.Map<BookDTO>(request));
            return Ok(_mapper.Map<BooksResponse>(response));
        }
    }
}