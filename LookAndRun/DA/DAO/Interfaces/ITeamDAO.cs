using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;

namespace Dozor .DA.DAO.Interfaces
{
    public interface ITeamDAO
    {
        int InsertTeam(Team team);
        List<Team> GetOrderedTeamsLastGame();
        List<Team> GetTeamsNextGame();
    }
}