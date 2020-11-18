using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_training.Models.DTO;
using API_training.Services.Interfaces;
using API_training.Common;

namespace API_training.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = DocumentPartsConst.Books)]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksInterface _booksService;

        public BooksController(IBooksInterface booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult Get()
        {
            _logger.LogInformation("Books/Get was requested.");
            var response = _booksService.Get();
            return Ok(response);
        }


        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Books/Get by id was requested.");
            var response = _booksService.GetById(id);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult Post(string name, string author, long id, string publisher, int publishingYear)
        {
            _logger.LogInformation("Books/Post was requested.");
            var response = _booksService.Post(name, author, id, publisher, publishingYear);
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOBooks>))]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Books/Delete was requested.");
            var response = _booksService.Delete(id);
            return Ok(response);
        }
    }
}
