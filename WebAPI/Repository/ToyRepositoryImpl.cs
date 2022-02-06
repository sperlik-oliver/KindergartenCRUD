using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ToyRepositoryImpl : IToyRepository
    {
        
        private readonly KinderGartenContext _kinderGartenContext;

        public ToyRepositoryImpl(KinderGartenContext kinderGartenContext)
        {
            _kinderGartenContext = kinderGartenContext;
        }

        public async Task<IList<Toy>> GetAllToys()
        {
            var result = await _kinderGartenContext.Toys.ToListAsync();
            return result;
        }

        public async Task CreateToy(Toy toy, int childId)
        {
            Console.WriteLine(childId);
            var child = await _kinderGartenContext.Children.Include(c => c.Toys).Where(child => child.Id == childId)
                .SingleOrDefaultAsync();
            child.Toys.Add(toy);
            await _kinderGartenContext.Toys.AddAsync(toy);
            await _kinderGartenContext.SaveChangesAsync();
        }

        public async Task DeleteToy(int id)
        {
            var toyToDelete = await _kinderGartenContext.Toys.FirstAsync(c => c.Id == id);
            _kinderGartenContext.Toys.Remove(toyToDelete);
            await _kinderGartenContext.SaveChangesAsync();
        }
    }
}