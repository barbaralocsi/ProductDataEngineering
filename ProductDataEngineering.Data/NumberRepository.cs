using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            _numberContext.SaveChanges();
        }
    }
}
