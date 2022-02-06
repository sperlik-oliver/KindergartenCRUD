using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace Blazor.Service
{
    public interface IToyService
    {

        public Task<IList<Toy>> GetAllToys();
        
        public Task CreateToy(Toy toy, int childId);

        public Task DeleteToy(int id);
        
    }
}