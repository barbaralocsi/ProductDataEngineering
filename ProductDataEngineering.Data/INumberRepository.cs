using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public interface INumberRepository
    {
        void Add(Number number);
    }
}
