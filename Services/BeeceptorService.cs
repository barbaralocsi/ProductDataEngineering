using System;
using System.Threading.Tasks;

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
            await _beeceptorApi.SendNumberAsync(new SendNumberRequest { Number = number });
        }
    }
}
