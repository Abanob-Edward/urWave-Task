
using Product_Management_System.Dtos.Product;
using Product_Management_System.Dtos.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Application.Services
{
    public interface IProductService 
    {
        Task<ResultDataList<ProductDto>> GetAllPagination(int items, int pagNumber, string sortColumn = "", string sortOrder = "");
        Task<ICollection<ProductDto>> GetAllCategories();
        Task<ResultView<ProductDto>> GetProductByID(int Id);
        Task<ResultDataList<ProductDto>> GetProductByName(string Name);
        Task<ResultView<ProductDto>> CreateProduct(AddOrUpdateProductDto ProductDto);
        Task<ResultView<ProductDto>> UpdateProduct(int Id, AddOrUpdateProductDto ProductDto);
        Task<ResultView<ProductDto>> SoftDelete(int Id);
        Task<ResultView<ProductDto>> HardDelete(int Id);

    }
}
