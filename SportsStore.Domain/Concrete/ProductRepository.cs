using System.Configuration;
using System.Data.SqlClient;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

        public Product GetById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = "SELECT * FROM Products WHERE productId = @productId";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var product = new Product();
                        while (reader.Read())
                        {
                            product.ProductId = (int)reader["ProductId"];
                            product.Name = reader["Name"].ToString();
                            product.Description = reader["Description"].ToString();
                            product.Price = (decimal)reader["Price"];
                            product.Category = reader["Category"].ToString();
                        }
                        return product;
                    }
                }
            }
        }

        public IList<Product> List()
        {
            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.ProductId = (int)reader["productId"];
                            product.Name = reader["Name"].ToString();
                            product.Description = reader["Description"].ToString();
                            product.Price = (decimal)reader["Price"];
                            product.Category = reader["Category"].ToString();

                            products.Add(product);
                        }
                        return products;
                    }
                }
            }
        }

        public void Add(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = "INSERT INTO Products(name, description, category, price) VALUES (@name, @description, @category, @price)";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@name", product.Name));
                    command.Parameters.Add(new SqlParameter("@description", product.Description));
                    command.Parameters.Add(new SqlParameter("@category", product.Category));
                    command.Parameters.Add(new SqlParameter("@price", product.Price));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = "UPDATE Products SET Name = @name, Description = @description, category = @category, price = @price WHERE ProductID = @productId";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@category", product.Category);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@productId", product.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = string.Concat("DELETE FROM Products where productId = ", productId);
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
