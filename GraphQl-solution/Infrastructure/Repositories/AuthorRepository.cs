using GraphQl_solution.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<Author>> GetAll()
        {
            throw new NotImplementedException();
            //return null;
        }

        public async Task<Author> GetDetail(int id) => await Task.FromResult(
            _context.Authors.Include(a => a.Books).FirstOrDefault(i => i.Id == id));
    }
}
