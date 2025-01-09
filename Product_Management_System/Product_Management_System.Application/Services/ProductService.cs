using AutoMapper;
using Product_Management_System.Application.Contract;
using Product_Management_System.Application.Validator;
using Product_Management_System.Dtos.Product;
using Product_Management_System.Dtos.ViewResult;
using Product_Management_System.Models;
using Product_Management_System.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Application.Services
{
    
    public class ProductService : IProductService
    { 
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            this._ProductRepository = ProductRepository;
            this._mapper = mapper;  

        }
        public async Task<ICollection<ProductDto>> GetAllCategories()
        {
            var ProductList = (await _ProductRepository.GetAllAsync());
            ProductList.Where(c => c.IsDeleted == false);
            return _mapper.Map<List<ProductDto>>(ProductList);
        }
        public async Task<ResultDataList<ProductDto>> GetAllPagination(int items, int pagNumber, string sortColumn = "id", string sortOrder = "asc")
        {
            try
            {
                var allData = (await _ProductRepository.GetAllAsync());
                var products = allData.Where(x => x.IsDeleted == false || x.IsDeleted == null);

                // Apply sorting based on sortColumn and sortOrder
                if (string.IsNullOrEmpty(sortColumn))
                {
                    sortColumn = nameof(Product.CreatedDate);
                }
                if (string.IsNullOrEmpty(sortOrder))
                {
                    sortColumn = "desc";
                }

                products = products.OrderBy(sortColumn + " " + sortOrder);

                var pagingModel = products.Skip(items * (pagNumber - 1)).Take(items).ToList();
                var model = _mapper.Map<List<Product>, List<ProductDto>>(pagingModel);
                if (products != null && products.Count() > 0)
                {
                    return new ResultDataList<ProductDto>()
                    {
                        Count = model.Count,
                        Entities = model,

                    };
                }
                else
                {
                    return new ResultDataList<ProductDto>()
                    {
                        Count = 0,
                        Entities = null,
                        Message = "not found any products"

                    };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }
        public async Task<ResultDataList<ProductDto>> GetProductByName(string Name)
        {
            var ProductList = await _ProductRepository.SearchByNameAsync(Name);
            if (ProductList == null)
            {
                return new ResultDataList<ProductDto>()
                {
                    Entities = null,
                    Count = 0,
                    Message = "not found With This Product Name "
                };
            }
            return new ResultDataList<ProductDto>()
            {
                Entities = _mapper.Map<List<Product>, List<ProductDto>>(ProductList.ToList()),
                Count = ProductList.Count(),
                Message = "Get Product Successfully "
            };
        }
        public async Task<ResultView<ProductDto>> GetProductByID(int Id)
        {
            var Product = await _ProductRepository.GetByIdAsync(Id);
            if (Product == null)
            {
                return new ResultView<ProductDto>()
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "not found"
                };
            }
            return new ResultView<ProductDto>()
            {
                Entity = _mapper.Map<Product, ProductDto>(Product),
                IsSuccess = true,
                Message = "Get Product Successfully "
            };
        }
        public  async Task<ResultView<ProductDto>> CreateProduct(AddOrUpdateProductDto ProductDto)
        {
            var Query = (await _ProductRepository.GetAllAsync());
            var OldProduct = Query.Where(c => c.Name == ProductDto.Name ).FirstOrDefault();
            if (OldProduct != null)
            {
                return new ResultView<ProductDto> { Entity = null, IsSuccess = false, Message = "Already Exist" };
            }
            else
            {
              

                var Product = _mapper.Map<Product>(ProductDto);
                Product.CreatedDate = DateTime.Now;
                var NewProduct = await _ProductRepository.CreateAsync(Product);
                await _ProductRepository.SaveChangesAsync();
                var Productdto = _mapper.Map<ProductDto>(NewProduct);
                return new ResultView<ProductDto> { Entity = Productdto, IsSuccess = true, Message = "Created Successfully" };
            }
        }
        public async Task<ResultView<ProductDto>> UpdateProduct(int Id ,AddOrUpdateProductDto ProductDto)
        {
            try
            {
                var Product = (await _ProductRepository.GetByIdAsync(Id));
                
                if(Product == null)
                {
                    return new ResultView<ProductDto>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "the ID not found"
                    };
                }
                      
                Product.IsDeleted = false;
                Product.Name = ProductDto.Name;
                Product.Price = ProductDto.Price;
                Product.Description = ProductDto.Description;
               
                 await _ProductRepository.SaveChangesAsync();
                var bokDto = _mapper.Map<AddOrUpdateProductDto, ProductDto>(ProductDto);
                return new ResultView<ProductDto> { Entity = bokDto, IsSuccess = true, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                return new ResultView<ProductDto> { Entity = null, IsSuccess = false, Message = "Can't updated" };
            }
        }
        public async Task<ResultView<ProductDto>> HardDelete(int ID)
        {
            try
            {
                var Product = await _ProductRepository.GetByIdAsync(ID);
                if (Product == null)
                {
                    return new ResultView<ProductDto>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "the ID not found"
                    };
                }
                await _ProductRepository.DeleteAsync(Product);
                await _ProductRepository.SaveChangesAsync();
                var obj = _mapper.Map<ProductDto>(Product);
                return new ResultView<ProductDto> { Entity = obj, IsSuccess = true, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                return new ResultView<ProductDto> { Entity = null, IsSuccess = false, Message = "Can't updated" };
            }
        }
        public async Task<ResultView<ProductDto>> SoftDelete(int ID)
        {
            try
            {
                var Product = await _ProductRepository.GetByIdAsync(ID);
                if (Product == null)
                {
                    return new ResultView<ProductDto>()
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "Not found Id"
                    };
                }
                Product.IsDeleted = true;
                await _ProductRepository.SaveChangesAsync();
                var cat = _mapper.Map<ProductDto>(Product);
                ResultView<ProductDto> resultView = new ResultView<ProductDto>()
                {
                    Entity = cat,
                    IsSuccess = true,
                    Message = "Deleted Successfully"
                };
                return resultView;
            }
            catch (Exception ex)
            {

                return new ResultView<ProductDto> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }

        
    }
}
