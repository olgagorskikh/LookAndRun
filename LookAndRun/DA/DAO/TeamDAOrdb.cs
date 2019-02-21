using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using System.Data;

namespace Dozor .DA.DAO
{
    public class TeamDAOrdb : ITeamDAO
    {

        public int InsertTeam(Team team)
        {
            var result = 0;
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    helper.AddSQLCommandParameter("Name", team.Name);
                    helper.AddSQLCommandParameter("GameId", team.GameId);
                    helper.AddSQLCommandParameter("Language", team.Language);
                    helper.AddSQLCommandParameter("Mobile", team.Mobile);
                    helper.AddSQLCommandParameter("Members", team.Members);

                    result = helper.ExecuteAndReturnIdentity("INSERT INTO Teams (Name, GameId, Language, Mobile, Members) VALUES (@Name, @GameId, @Language, @Mobile, @Members)");
                    
                }
            }
            catch (Exception ex) { result = 0; }

            return result;
        }

        public List<Team> GetOrderedTeamsLastGame()
        {
            var result = new List<Team>();
            try
            {
                using (DBHelper helper = new DBHelper())
                {

                    var gameId = 0;

                    DataRowCollection preDataRowCollection = helper.GetDataRowCollection(@"SELECT Id
                                                                                        FROM Games
                                                                                        ORDER BY Id DESC");

                    DataRow preRow = preDataRowCollection[1];

                    if (!string.IsNullOrEmpty(preRow["Id"].ToString()))
                        gameId = ((int)preRow["Id"]);

                    helper.AddSQLCommandParameter("gameId", gameId);
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT *
                                                                                        FROM Teams
                                                                                        WHERE GameId = @gameId
                                                                                        ORDER BY Result ASC");

                    for (int i = 0; i < dataRowCollection.Count; i++)
                    {
                        DataRow row = dataRowCollection[i];
                        Team currentTeam = new Team();

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            currentTeam.Id = ((int)row["Id"]);

                        if (!string.IsNullOrEmpty(row["Mobile"].ToString()))
                            currentTeam.Mobile = ((string)row["Mobile"]);

                        if (!string.IsNullOrEmpty(row["Language"].ToString()))
                            currentTeam.Language = ((string)row["Language"]);

                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            currentTeam.Name = ((string)row["Name"]);

                        if (!string.IsNullOrEmpty(row["Result"].ToString()))
                            currentTeam.Result = ((string)row["Result"]);
                        
                        result.Add(currentTeam);

                    }

                }
            }
            catch (Exception ex) { result = null; }

            return result;
        }


        public List<Team> GetTeamsNextGame()
        {
            var result = new List<Team>();
            try
            {
                using (DBHelper helper = new DBHelper())
                {

                    var gameId = 0;

                    DataRowCollection preDataRowCollection = helper.GetDataRowCollection(@"SELECT Id
                                                                                        FROM Games
                                                                                        ORDER BY Id DESC");

                    DataRow preRow = preDataRowCollection[0];

                    if (!string.IsNullOrEmpty(preRow["Id"].ToString()))
                        gameId = ((int)preRow["Id"]);

                    helper.AddSQLCommandParameter("gameId", gameId);
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT *
                                                                                        FROM Teams
                                                                                        WHERE GameId = @gameId");

                    for (int i = 0; i < dataRowCollection.Count; i++)
                    {
                        DataRow row = dataRowCollection[i];
                        Team currentTeam = new Team();

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            currentTeam.Id = ((int)row["Id"]);

                        if (!string.IsNullOrEmpty(row["Members"].ToString()))
                            currentTeam.Members = ((int)row["Members"]);

                        if (!string.IsNullOrEmpty(row["Mobile"].ToString()))
                            currentTeam.Mobile = ((string)row["Mobile"]);

                        if (!string.IsNullOrEmpty(row["Language"].ToString()))
                            currentTeam.Language = ((string)row["Language"]);

                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            currentTeam.Name = ((string)row["Name"]);

                        result.Add(currentTeam);

                    }

                }
            }
            catch (Exception ex) { result = null; }

            return result;
        }
     

    }
}