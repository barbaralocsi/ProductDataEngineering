using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDataEngineering.Application
{
    public interface INumberProcessor
    {
        Task ProcessAsync(int number);
    }
}
