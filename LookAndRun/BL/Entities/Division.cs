using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dozor.BL
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Division> GetAllCategories()
        {
            List<Division> result = new List<Division>();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection("SELECT * FROM Division");

                    for (int i = 0; i < dataRowCollection.Count; i++)
                    {
                        DataRow row = dataRowCollection[i];
                        Division currentDivision = new Division();

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            currentDivision.Id = ((int)row["Id"]);

                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            currentDivision.Name = ((string)row["Name"]);

                        result.Add(currentDivision);
                    }
                }
            }
            catch (Exception ex) { }

            return result;
        }
    }
}
