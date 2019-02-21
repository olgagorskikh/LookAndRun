using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dozor .BL;
using Dozor .DA.DAO.Interfaces;
using System.Data;

namespace Dozor .DA.DAO
{
    public class GameDAOrdb : IGameDAO
    {

        public Game GetLastGame()
        {
            var result = new Game();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT *
                                                                                        FROM Games
                                                                                        ORDER BY Id DESC");
                    
                        DataRow row = dataRowCollection[1];

                        if (!string.IsNullOrEmpty(row["Id"].ToString()))
                            result.Id = ((int)row["Id"]);

                        if (!string.IsNullOrEmpty(row["Data"].ToString()))
                            result.Data = ((string)row["Data"]);

                        if (!string.IsNullOrEmpty(row["Name"].ToString()))
                            result.Name = ((string)row["Name"]);

                        if (!string.IsNullOrEmpty(row["Event"].ToString()))
                            result.Event = ((string)row["Event"]);

                        if (!string.IsNullOrEmpty(row["Photo"].ToString()))
                            result.Photo = ((string)row["Photo"]);

                   

                }
            }
            catch (Exception ex) { result = null; }

            return result;
        }

        public Game GetNextGame()
        {
            var result = new Game();
            try
            {
                using (DBHelper helper = new DBHelper())
                {
                    DataRowCollection dataRowCollection = helper.GetDataRowCollection(@"SELECT *
                                                                                        FROM Games
                                                                                        ORDER BY Id DESC");

                    DataRow row = dataRowCollection[0];

                    if (!string.IsNullOrEmpty(row["Id"].ToString()))
                        result.Id = ((int)row["Id"]);

                    if (!string.IsNullOrEmpty(row["Data"].ToString()))
                        result.Data = ((string)row["Data"]);

                    if (!string.IsNullOrEmpty(row["Name"].ToString()))
                        result.Name = ((string)row["Name"]);

                    if (!string.IsNullOrEmpty(row["Event"].ToString()))
                        result.Event = ((string)row["Event"]);

                    if (!string.IsNullOrEmpty(row["Photo"].ToString()))
                        result.Photo = ((string)row["Photo"]);


                }
            }
            catch (Exception ex) { result = null; }

            return result;
        }

     

    }
}