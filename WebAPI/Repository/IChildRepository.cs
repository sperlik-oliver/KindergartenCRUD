using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IChildRepository
    {

        public Task<IList<Child>> GetAllChildren();
        public Task CreateChild(Child child);

        //This functionality is not part of the exam => I implemented it for testing purposes, so that I can get rid of too many children
        public Task DeleteChild(int id);
    }
}