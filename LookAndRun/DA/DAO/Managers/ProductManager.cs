using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor.BL;
using Dozor.DA.DAO.Interfaces;
using Dozor.DA;

namespace Dozor.BL.Managers
{
    public static class ProductManager
    {
        public static List<Product> GetAllProducts()
        {
            IProductDAO pdr = DAOFactory.GetProductDAO();
            var result = pdr.GetAllProducts();
            return result;
        }
    }
}