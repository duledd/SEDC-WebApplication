using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet<T> table;

        public GenericRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(configuration.GetConnectionString("SEDC2"));
            _context = new ApplicationDbContext(optionBuilder.Options);
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            List<T> result = await table.Skip(skip).Take(take).ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        { 
            T result = await table.FindAsync(id);
            return result;
        }

        public async Task Save(T item)
        {
                //User user = new User();
                //user.Employee = item;
            await table.AddAsync(item);
            _context.SaveChanges();
        }
        public async Task Update(T item)
        {
                //db.Entry<Employee>(item).State = EntityState.Modified;
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
