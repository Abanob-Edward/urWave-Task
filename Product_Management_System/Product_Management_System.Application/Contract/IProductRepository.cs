using Product_Management_System.Models;
using Product_Management_System.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Product_Management_System.Application.Contract
{


    public interface IProductRepository : IRepository<Product,int>
    {
        Task<IQueryable<Product>> SearchByNameAsync(string txt);

    }
}
