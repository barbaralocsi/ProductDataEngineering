using System;
using System.Linq;

using System.Threading.Tasks;
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
        }

        public Number GetNextUnprocessed()
        {
            return _numberContext.Numbers.FirstOrDefault(x => x.IsProcessed == false);
        }

        public async Task SaveAsync()
        {
            await _numberContext.SaveChangesAsync();
        }
    }
}
