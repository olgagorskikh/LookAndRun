using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dozor.BL
{
    public class Product
    {
        public Int64 Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public Product()
        {
            Id = CategoryId = 0;
            Name = CategoryName = "";
            Price = 0.0;
            Date = DateTime.Now;
        }

        public Product(int categoryId, string name, double price)
        {
            CategoryId = categoryId;
            Name = name;
            Price = price;
        }

        public Product(int categoryId, string name, double price, DateTime date, int id)
        {
            CategoryId = categoryId;
            Name = name;
            Price = price;
            Date = date;
            Id = id;
        }

      

       
    }
}
