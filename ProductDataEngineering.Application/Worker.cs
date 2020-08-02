using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pde.CodingExercise.RandomNumberGenerator;

namespace ProductDataEngineering.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var generator = new NumberGenerator();
            generator.NumberGenerated += NumberReceivedEventHandler;
            generator.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (var scope = _scopeFactory.CreateScope())
                {
                    try
                    {
                        var numberProcessor = scope.ServiceProvider.GetRequiredService<INumberProcessor>();
                        await numberProcessor.SendAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation($"Could not send the number, will try again later. Details: {ex}");
                    }
                }

                await Task.Delay(100, stoppingToken);
            }
        }

        private async void NumberReceivedEventHandler(object? sender, NumberGeneratedEventArgs e)
        {
            _logger.LogInformation($"Number received: {e.Number}");
            var isPersisted = false;

            while (!isPersisted)
            {
                try
                {
                    _logger.LogInformation($"Trying to persist number: {e.Number}");
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var numberProcessor = scope.ServiceProvider.GetRequiredService<INumberProcessor>();
                        await numberProcessor.PersistAsync(e.Number);
                    }

                    isPersisted = true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Could not persist this number: {e.Number}, will try again later. Details: {ex}");
                    await Task.Delay(1000);
                }
            }
        }
    }
}
