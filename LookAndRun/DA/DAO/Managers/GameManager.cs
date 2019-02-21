using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using Dozor .DA;

namespace Dozor .BL.Managers
{
    public static class GameManager
    {
        public static Game GetLastGame()
        {
            IGameDAO pdr = DAOFactory.GetGameDAO();
            var result = pdr.GetLastGame();
            return result;
        }

        public static Game GetNextGame()
        {
            IGameDAO pdr = DAOFactory.GetGameDAO();
            var result = pdr.GetNextGame();
            return result;
        }
    }
}