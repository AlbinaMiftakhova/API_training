using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace API_training.Infrastructure
{
    /// <summary>
    /// Кэширование рефреш токена
    /// </summary>
    public class JwtRefreshTokenCache : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Конструктор <see cref="JwtRefreshTokenCache"/>
        /// </summary>
        /// <param name="jwtAuthManager"><see cref="IJwtAuthManager"/></param>
        public JwtRefreshTokenCache(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Удаляет каждую минуту старые рефреш токены
        /// </summary>
        /// <param name="stoppingToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(Remove, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаление
        /// </summary>
        private void Remove(object state)
        {
            _jwtAuthManager.RemoveExpiredRT(DateTime.Now);
        }

        /// <summary>
        /// Остановка удаления
        /// </summary>
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Dispose timer.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
