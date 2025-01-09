using Product_Management_System.Application.Contract;
using Product_Management_System.Context;
using Product_Management_System.Models;
using Product_Management_System.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Infrastructure
{
    public class ProductRepository : Repository<Product, int> , IProductRepository
    {


        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }
        public async Task<IQueryable<Product>> SearchByNameAsync(string txt)
        {
            var book =  _context.Product.Where(t => t.Name.ToLower().Contains(txt.ToLower()));
            return book;
        }

       
    }
}
