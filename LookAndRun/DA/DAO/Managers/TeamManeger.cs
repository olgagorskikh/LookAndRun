using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using Dozor .DA;

namespace Dozor .BL.Managers
{
    public static class TeamManager
    {
        public static int InsertTeam(Team team)
        {
            ITeamDAO pdr = DAOFactory.GetTeamDAO();
            var result = pdr.InsertTeam(team);
            return result;
        }

        public static List<Team> GetOrderedTeamsLastGame()
        {
            ITeamDAO pdr = DAOFactory.GetTeamDAO();
            var result = pdr.GetOrderedTeamsLastGame();
            return result;
        }

        public static List<Team> GetTeamsNextGame()
        {
            ITeamDAO pdr = DAOFactory.GetTeamDAO();
            var result = pdr.GetTeamsNextGame();
            return result;
        }
    }
}