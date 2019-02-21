using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dozor .BL
{
    public class Person
    {
        public Person()
        {
            Id = 
            TeamId = 0;
            Name = 
            Lastname = String.Empty;
        }

        public Person(int _id, int _teamId,
             string _name, string _lastname)
        {
            Id = _id;
            TeamId = _teamId;
            Name = _name;
            Lastname = _lastname;            
        }



        private int _id; 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _teamId;
        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        
        public string FullName
        {
            get { return Name + Lastname; }
        }
    }
}