using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor.BL;

namespace Dozor.DA.DAO.Interfaces
{
    public interface IProductDAO
    {
        bool InsertProduct(Product product, DateTime currentDate);
        List<Product> GetAllProducts();
        double GetSumOfallProducts();
        bool UpdateProduct(Product product);
        bool RemoveProductById(int id);


    }
}