using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{
    public class FakeProductRepository : IProductRepository
    {
        public IList<Product> List()
        {
            List<Product> products = new List<Product>();

            Product product1 = new Product
            {
                ProductId = 1,
                Name = "Deportivas Nike",
                Description = "Just do it",
                Category = "Calzado",
                Price = (decimal)99.10
            };

            Product product2 = new Product
            {
                ProductId = 2,
                Name = "Deportivas Adidas",
                Description = "Nothing is impossible",
                Category = "Calzado",
                Price = 59
            };

            Product product3 = new Product
            {
                ProductId = 2,
                Name = "Deportivas Puma",
                Description = "Bambas Puma",
                Category = "Calzado",
                Price = 59
            };

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            return products;
        } 
    }
}
