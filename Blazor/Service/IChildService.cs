using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace Blazor.Service
{
    public interface IChildService
    {

        public Task<IList<Child>?> GetAllChildren();
        
        public Task CreateChild(Child child);
    }
}