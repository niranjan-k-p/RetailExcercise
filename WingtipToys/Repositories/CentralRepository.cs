using System;
using System.Threading.Tasks;

namespace WingtipToys.Repositories
{
    public class CentralRepository : ICentralRepository, IDisposable
    {
        public WingtipToysEntities EntitiesDb { get; }

        public CentralRepository()
        {
            EntitiesDb = new WingtipToysEntities();
        }

        public async Task<int> Save()
        {
            return await EntitiesDb.SaveChangesAsync();
        }

        public void Dispose()
        {
            EntitiesDb?.Dispose();
        }
    }
}