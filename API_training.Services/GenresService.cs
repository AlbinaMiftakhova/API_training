﻿using API_training.Models.DTO;
using API_training.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using API_training.Repositories.Interfaces;

namespace API_training.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о книгах
    /// </summary>
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref=BooksService"/>
        /// </summary>
        /// <param name="repository">Репозиторий</param>
        public GenresService(IGenresRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GenreDTO> CreateAsync(GenreDTO dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GenreDTO> GetAsync(long id, CancellationToken token = default)
        {
            return await _repository.GetAsync(id);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GenreDTO>> GetAsync(CancellationToken token = default)
        {
            return await _repository.GetAsync();
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GenreDTO> UpdateAsync(GenreDTO dto)
        {
            return await _repository.UpdateAsync(dto);
        }
    }
}
