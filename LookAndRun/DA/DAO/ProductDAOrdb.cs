using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor.BL;
using Dozor.DA.DAO.Interfaces;
using System.Data;

namespace Dozor.DA.DAO
{
    public class ProductDAOrdb:IProductDAO
    {
        
        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT c.Name AS Category, p.Category AS CategoryId, p.Name, p.Price, p.CurrentDate, p.Id 
                                               FROM Products p
                                               INNER JOIN Categories c ON p.Category = c.Id");
                    
                    for (int i = 0; i < dataRowCollection.Count; i++)
                    {
                        DataRow row = dataRowCollection[i];
                        Product currentProduct = new Product();

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            currentProduct.Id = ((Int64)row["Id"]);
                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            currentProduct.Name = ((string)row["Name"]);

                        if (!string.IsNullOrEmpty(row["CategoryId"].ToString()))
                            currentProduct.CategoryId = ((int)row["CategoryId"]);
                        if (!string.IsNullOrEmpty(row["Category"].ToString()))
                            currentProduct.CategoryName = ((string)row["Category"]);

                        if (!string.IsNullOrEmpty(row["Price"].ToString()))
                            currentProduct.Price = ((double)row["Price"]);
                        if (!string.IsNullOrEmpty(row["CurrentDate"].ToString()))
                            currentProduct.Date = ((DateTime)row["CurrentDate"]);

                        result.Add(currentProduct);

                    }

                }
            }
            catch (Exception ex) { result = null; }

            return result;
        }

        public bool InsertProduct(Product product, DateTime currentDate)
        {
            bool result = false;
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Category", product.CategoryId);
                    helper.AddSQLCommandParameter("Name", product.Name);
                    helper.AddSQLCommandParameter("Price", product.Price);
                    helper.AddSQLCommandParameter("CurrentDate", currentDate);
                    //String.Format("{0:dd.MM.yyyy HH:mm:ss}", 
                    //helper.Execute("INSERT INTO Products (Category, Name, Price, CurrentDate) VALUES (@Category, @Name, @Price, @CurrentDate)");

                    var result1 = helper.ExecuteAndReturnIdentity("INSERT INTO Products (Category, Name, Price, CurrentDate) VALUES (@Category, @Name, @Price, @CurrentDate)");

                    result = true;
                }
            }
            catch (Exception ex) { result = false; }

            return result;
        }



        public double GetSumOfallProducts()
        {
            var result = 0.0;

            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT SUM(Price) AS Expr1 FROM Products");

                    DataRow row = dataRowCollection[0];

                    if (!string.IsNullOrEmpty(row["Expr1"].ToString()))
                        result = ((double)row["Expr1"]);


                }
            }
            catch (Exception cEx)
            {
            }



            return result;

        }

        public bool UpdateProduct(Product product)
        {
            bool result = false;
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Category", product.CategoryId);
                    helper.AddSQLCommandParameter("Name", product.Name);
                    helper.AddSQLCommandParameter("Price", product.Price);
                    helper.AddSQLCommandParameter("CurrentDate", product.Date);
                    helper.AddSQLCommandParameter("Id", product.Id);

                    helper.Execute(@"UPDATE Products SET Category=@Category, Name=@Name, Price=@Price, CurrentDate = @CurrentDate WHERE Id=@Id");

                    result = true;
                }
            }
            catch (Exception ex) { result = false; }
            return result;
        }

        public bool RemoveProductById(int id)
        {
            bool result = false;
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Id", id);

                    helper.Execute(@"Delete from Products WHERE Id=@Id");

                    result = true;
                }
            }
            catch (Exception ex) { result = false; }
            return result;
        }

    }
}