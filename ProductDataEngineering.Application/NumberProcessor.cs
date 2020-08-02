using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task ProcessAsync(int number)
        {
            _numberRepository.Add(new Number { Value = number });
            if (number > 800)
            {
                await _beeceptorService.SendNumberAsync(number);
            }
        }
    }
}
