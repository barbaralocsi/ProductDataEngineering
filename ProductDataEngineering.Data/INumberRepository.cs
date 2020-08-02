using System.Threading.Tasks;
using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public interface INumberRepository
    {
        void Add(Number number);

        Number GetNextUnprocessed();

        Task SaveAsync();
    }
}
