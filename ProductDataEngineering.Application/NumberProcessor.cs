using System;
using System.Threading.Tasks;
using ProductDataEngineering.Data;
using ProductDataEngineering.Domain;
using Services;

namespace ProductDataEngineering.Application
{
    public class NumberProcessor : INumberProcessor
    {
        private readonly INumberRepository _numberRepository;
        private readonly IBeeceptorService _beeceptorService;

        public NumberProcessor(INumberRepository numberRepository, IBeeceptorService beeceptorService)
        {
            _numberRepository = numberRepository ?? throw new ArgumentNullException(nameof(numberRepository));
            _beeceptorService = beeceptorService ?? throw new ArgumentNullException(nameof(beeceptorService));
        }

        public async Task PersistAsync(int number)
        {
            _numberRepository.Add(new Number
            {
                Value = number,
                IsProcessed = Constants.Limit >= number,
            });
            await _numberRepository.SaveAsync();
        }

        public async Task SendAsync()
        {
            var next = _numberRepository.GetNextUnprocessed();
            if (next is null)
            {
                return;
            }
            await _beeceptorService.SendNumberAsync(next.Value);
            next.IsProcessed = true;
            await _numberRepository.SaveAsync();
        }
    }
}
