using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pde.CodingExercise.RandomNumberGenerator;
using ProductDataEngineering.Data;
using ProductDataEngineering.Domain;
using Services;

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
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async void NumberReceivedEventHandler(object? sender, NumberGeneratedEventArgs e)
        {
            // TODO: Currently the message is not (fully) processed in case of an exception. It is possible that it was added to the database, but it was not sent to the service.
            try 
            {
                _logger.LogInformation($"Number received: {e.Number}");
                using (var scope = _scopeFactory.CreateScope())
                {
                    var numberProcessor = scope.ServiceProvider.GetRequiredService<INumberProcessor>();
                    await numberProcessor.ProcessAsync(e.Number);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during the processing of number: {e.Number}. Error: {ex}");
            }
        }
    }
}
