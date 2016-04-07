using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int productId);

        IList<Product> List();

        void Add(Product product);

        void Update(Product product);

        void Delete(int productId);
    }
}
