using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IToyRepository
    {
        public Task<IList<Toy>> GetAllToys();

        public Task CreateToy(Toy toy, int childId);

        public Task DeleteToy(int id);
    }
}