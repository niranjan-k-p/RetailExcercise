using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    public interface ICentralRepository
    {
        WingtipToysEntities EntitiesDb { get; }

        Task<int> Save();
    }
}