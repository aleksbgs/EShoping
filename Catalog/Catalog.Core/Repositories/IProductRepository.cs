using System.Collections;
using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductByName(string id);
    Task<IEnumerable<Product>> GetProductByBrand(string id);
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}