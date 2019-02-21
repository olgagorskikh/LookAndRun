using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dozor.BL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Division { get; set; }

        public static List<Category> GetAllCategories()
        {
            List<Category> result = new List<Category>();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection("SELECT * FROM Categories");

                    for (int i = 0; i < dataRowCollection.Count; i++)
                    {
                        DataRow row = dataRowCollection[i];
                        Category currentCategory = new Category();

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            currentCategory.Id = ((int)row["Id"]);

                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            currentCategory.Name = ((string)row["Name"]);

                        if (!string.IsNullOrEmpty(row["Division"].ToString()))
                            currentCategory.Division = ((int)row["Division"]);


                        result.Add(currentCategory);
                    }
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public static Category GetCategoryByName(string name)
        {
            Category result = new Category();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Name", name);

                    DataRowCollection dataRowCollection = helper.GetDataRowCollection("SELECT * FROM Categories WHERE Name=@Name");

                    DataRow row = dataRowCollection[0];
                    Category currentCategory = new Category();

                    if (!string.IsNullOrEmpty(row["Id"].ToString()))
                        currentCategory.Id = ((int)row["Id"]);

                    if (!string.IsNullOrEmpty(row["Name"].ToString()))
                        currentCategory.Name = ((string)row["Name"]);

                    if (!string.IsNullOrEmpty(row["Division"].ToString()))
                        currentCategory.Division = ((int)row["Division"]);


                    result = currentCategory;
                    
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public static Category GetCategoryById(int id)
        {
            Category result = new Category();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Id", id);

                    DataRowCollection dataRowCollection = helper.GetDataRowCollection("SELECT * FROM Categories WHERE Id=@Id");

                    DataRow row = dataRowCollection[0];
                    Category currentCategory = new Category();

                    if (!string.IsNullOrEmpty(row["Id"].ToString()))
                        currentCategory.Id = ((int)row["Id"]);

                    if (!string.IsNullOrEmpty(row["Name"].ToString()))
                        currentCategory.Name = ((string)row["Name"]);

                    if (!string.IsNullOrEmpty(row["Division"].ToString()))
                        currentCategory.Division = ((int)row["Division"]);


                    result = currentCategory;

                }
            }
            catch (Exception ex) { }

            return result;
        }
    }
}
