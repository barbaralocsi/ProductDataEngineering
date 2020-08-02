using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Services
{
    public class BeeceptorService : IBeeceptorService
    {
        private readonly IBeeceptorApi _beeceptorApi;

        public BeeceptorService(IBeeceptorApi beeceptorApi)
        {
            _beeceptorApi = beeceptorApi ?? throw new ArgumentNullException(nameof(beeceptorApi));
        }

        public async Task SendNumberAsync(int number)
        {
            await _beeceptorApi.SendNumberAsync(new SendNumberRequest{Number = number});
        }
    }
}
