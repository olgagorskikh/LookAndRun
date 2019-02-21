using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using Dozor .DA;

namespace Dozor .BL.Managers
{
    public static class PersonManager
    {
        public static bool InsertPerson(Person person)
        {
            IPersonDAO pdr = DAOFactory.GetPersonDAO();
            bool result = pdr.InsertPerson(person);
            return result;
        }
    }
}