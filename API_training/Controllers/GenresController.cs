using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_training.Models.DTO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using API_training.Models.Requests.Genres;
using API_training.Models.Responses.Genres;
using API_training.Repositories;
using API_training.Common;

namespace API_training.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о книгах
    /// </summary>
    [Route("/[controller]/[action]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = DocumentPartsConst.Genre)]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GenresController"/>
        /// </summary>
        /// <param name="repo">Репозиторий</param>
        /// <param name="logger">Логгер</param>
        /// <param name="mapper">Маппер</param>
        public GenresController(UnitOfWork repo, ILogger<GenresController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня жанров
        /// </summary>
        /// <returns>Коллекция сущностей "Жанры"</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreDTO>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genres/Get was requested.");
            var response = await _repo.GenresRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<GenresResponse>>(response));
        }

        /// <summary>
        /// Получение жанра по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        /// <returns>Сущность "Жанр"</returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreDTO>))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genres/Get by id was requested.");
            var response = await _repo.GenresRepository.GetAsync(id);
            return Ok(_mapper.Map<GenresResponse>(response));
        }

        /// <summary>
        /// Добавляет жанр
        /// </summary>
        /// <returns>Новый список жанров</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreDTO>))]
        public async Task<IActionResult> PostAsync(CreateGenresRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genres/Post was requested.");
            var response = await _repo.GenresRepository.CreateAsync(_mapper.Map<GenreDTO>(request));
            return Ok(_mapper.Map<GenresResponse>(response));
        }

        /// <summary>
        /// Удаляет жанр
        /// </summary>
        /// <param name="ids">Идентификаторы жанров</param>
        /// <returns>Новый список жанров</returns>
        [HttpDelete]
        [Route("{ids:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreDTO>))]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {

            _logger.LogInformation("Genres/Delete was requested.");
            await _repo.GenresRepository.DeleteAsync(ids);
            return Ok();
        }

        /// <summary>
        /// Изменяет сущность "Жанр"
        /// </summary>
        /// <returns>Возвращает изменненную запись</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreDTO>))]
        public async Task<IActionResult> PutAsync(UpdateGenresRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genres/Put was requested.");
            var response = await _repo.GenresRepository.UpdateAsync(_mapper.Map<GenreDTO>(request));
            return Ok(_mapper.Map<GenresResponse>(response));
        }
    }
}