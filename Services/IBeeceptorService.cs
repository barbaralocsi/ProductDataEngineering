using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBeeceptorService
    {
        Task SendNumberAsync(int number);
    }
}
