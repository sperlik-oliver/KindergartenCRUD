using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ChildRepositoryImpl : IChildRepository
    {
        private readonly KinderGartenContext _kinderGartenContext;

        public ChildRepositoryImpl(KinderGartenContext kinderGartenContext)
        {
            _kinderGartenContext = kinderGartenContext;
        }


        public async Task<IList<Child>> GetAllChildren()
        {
            var result = await _kinderGartenContext.Children.Include(child => child.Toys).ToListAsync();
            return result;
        }
        
        
        public async Task CreateChild(Child child)
        {
            await _kinderGartenContext.Children.AddAsync(child);
            await _kinderGartenContext.SaveChangesAsync();
        }

        //This functionality is not part of the exam => I implemented it for testing purposes, so that I can get rid of too many children
        public async Task DeleteChild(int id)
        {
            var childToDelete = await _kinderGartenContext.Children.Include(child => child.Toys)
                .FirstAsync(c => c.Id == id);
            _kinderGartenContext.Children.Remove(childToDelete);
            foreach (Toy toy in childToDelete.Toys)
            {
                _kinderGartenContext.Toys.Remove(toy);
            }
            
            await _kinderGartenContext.SaveChangesAsync();
        }
    }
}