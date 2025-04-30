using ManageVM.Api.Core.Entities;
using ManageVM.Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageVM.Api.Infrastructure.Repositories
{
    public class VMRepository : IVMRepository
    {
        private readonly ApplicationDbContext _context;

        public VMRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VM>> GetAll()
        {
            return await _context.VM.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<ActionResult<VM>> GetId(int id)
        {
            return await _context.VM.FindAsync(id);
        }

        public async Task<int> Put(int id, VM vm)
        {

            _context.Entry(vm).State = EntityState.Modified;

            try
            {
                _context.VM.Update(vm);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        public async Task<int> Post(VM vm)
        {
            _context.VM.Add(vm);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var product = await _context.VM.FindAsync(id);
            if (product == null)
            {
                return 0;
            }

            _context.VM.Remove(product);
            return await _context.SaveChangesAsync();
        }
    }
    
}
