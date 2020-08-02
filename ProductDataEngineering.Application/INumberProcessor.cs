using System.Threading.Tasks;

namespace ProductDataEngineering.Application
{
    public interface INumberProcessor
    {
        Task PersistAsync(int number);
        Task SendAsync();
    }
}
