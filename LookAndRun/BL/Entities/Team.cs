using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dozor.BL
{
    public class Team
    {
        public Team()
        {
            Id =
            Members =
            GameId = 0;
            Name = 
            Language = 
            Mobile = 
            Result = String.Empty; 
        }

        public Team(int _id, int _gameId,
             string _language, string _name, string _mobile, int _members)
        {
            Id = _id;
            GameId = _gameId;
            Name = _name;
            Language = _language;
            Mobile = _mobile;
            Members = _members;
            Result = String.Empty;
        }



        private int _id; 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _members;
        public int Members
        {
            get { return _members; }
            set { _members = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        private int _gameId;
        public int GameId
        {
            get { return _gameId; }
            set { _gameId = value; }
        }

        private string _language;
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
        
    }
}