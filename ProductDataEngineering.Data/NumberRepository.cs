using System;
using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public class NumberRepository : INumberRepository
    {
        private readonly NumberContext _numberContext;

        public NumberRepository(NumberContext numberContext)
        {
            _numberContext = numberContext ?? throw new ArgumentNullException(nameof(numberContext));
        }

        public void Add(Number number)
        {
            _numberContext.Add(number);
            _numberContext.SaveChanges();
        }
    }
}
