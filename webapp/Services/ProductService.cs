using System;
using System.Data.Common;
using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _productList = new();
            string statement = "SELECT * from Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader _reader = cmd.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _productList.Add(_product);
                }
            }
            conn.Close();
            return _productList;
        }
    }
}

