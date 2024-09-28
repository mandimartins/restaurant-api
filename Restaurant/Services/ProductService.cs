using AutoMapper;
using Restaurant.Data.DTOs;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModels;
using Restaurant.Repositories.Interfaces;
using Restaurant.Services.Interfaces;
using Restaurant.Utilities.ExtensionMethods;
using Restaurant.Utilities.NotificationPattern;

namespace Restaurant.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationHandler _notificationHandler;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            INotificationHandler notificationHandler,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _notificationHandler = notificationHandler;
            _mapper = mapper;
        }

        public async Task<Product> AddAsync(ProductViewModel productViewModel)
        {
            if (!productViewModel.Validate().Notify(_notificationHandler))
                return new Product();

            var product = _mapper.Map<Product>(productViewModel);

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<Product> GetAsyncAsNoTracking(int Id)
        {
            return await _productRepository.GetAsyncAsNoTracking(Id);
        }

        public async Task<(int totalRows, IList<ProductDTO> data)> GetAllAsyncAsNoTracking(GridFilterViewModel filter)
        {
            return await _productRepository.GetAllAsyncAsNoTracking(filter);
        }

        public Task<Product> UpdateAsync(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
