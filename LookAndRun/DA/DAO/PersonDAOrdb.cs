using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using System.Data;

namespace Dozor .DA.DAO
{
    public class PersonDAOrdb : IPersonDAO
    {

     

        public bool InsertPerson(Person person)
        {
            bool result = false;
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("TeamId", person.TeamId);
                    helper.AddSQLCommandParameter("Name", person.Name);
                    helper.AddSQLCommandParameter("Lastname", person.Lastname);

                    helper.Execute("INSERT INTO Members (TeamId, Name, Lastname) VALUES (@TeamId, @Name, @Lastname)");
                    result = true;
                }
            }
            catch (Exception ex) { result = false; }

            return result;
        }

       

     

    }
}