using System.Threading.Tasks;

namespace ProductDataEngineering.Application
{
    public interface INumberProcessor
    {
        Task ProcessAsync(int number);
    }
}
