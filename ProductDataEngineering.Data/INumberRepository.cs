using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public interface INumberRepository
    {
        void Add(Number number);
        Number GetNextUnprocessed();
        void Save();
    }
}
