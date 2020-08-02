using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Services
{
    public interface IBeeceptorApi
    {
        [Post("/numbers")]
        Task SendNumberAsync([Body] SendNumberRequest sendNumberRequest);
    }
}
