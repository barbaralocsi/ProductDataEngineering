using System.Threading.Tasks;

namespace Services
{
    public interface IBeeceptorService
    {
        Task SendNumberAsync(int number);
    }
}
