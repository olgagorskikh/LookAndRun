using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .DA.DAO.Interfaces;
using Dozor .DA.DAO;

namespace Dozor .DA
{
    public class DAOFactory
    {
        public static IPersonDAO GetPersonDAO()
        {
            return new PersonDAOrdb();
        }

        public static ITeamDAO GetTeamDAO()
        {
            return new TeamDAOrdb();
        }

        public static IGameDAO GetGameDAO()
        {
            return new GameDAOrdb();
        }

        public static IProductDAO GetProductDAO()
        {
            return new ProductDAOrdb();
        }
        
    }
}