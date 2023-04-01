using Exemplo.Repository.V1.Interfaces;
using Exemplo.Repository.V1.Models;

namespace Exemplo.Repository.V1.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository= productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }
        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
