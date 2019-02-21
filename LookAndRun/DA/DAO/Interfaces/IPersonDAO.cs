using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;

namespace Dozor .DA.DAO.Interfaces
{
    public interface IPersonDAO
    {
        bool InsertPerson(Person person);

    }
}