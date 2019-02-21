using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dozor .BL
{
    public class Game
    {
        public Game()
        {
            Id = 0;
            Name = 
            Event =
            Photo =
            Data = String.Empty;
        }

        public Game(int _id, string _name, string _data)
        {
            Id = _id;
            Name = _name;
            Data = _data;
            Photo =
            Event = String.Empty;
        }
        private int _id; 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _event;
        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }

        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private string _data;
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        
    }
}