using System;
using System.Data.Common;
using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
	public class ProductService
	{
		public static string server = "rafee-db-server.database.windows.net";
		public static string user = "rafeeadmin";
		public static string password = "S3v3nP3@ks";
		public static string database = "rafee-sql-db";

		private SqlConnection GetConnection()
		{
			var _builder = new SqlConnectionStringBuilder();
			_builder.DataSource = server;
			_builder.UserID = user;
			_builder.Password = password;
			_builder.InitialCatalog = database;

			return new SqlConnection(_builder.ConnectionString);
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

