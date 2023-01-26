using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    public class Team
    {
        private string _name;
        private string _city;
        private string _arena;
        public string Name { 
            get 
            {
                return _name;
            } 
            set 
            {
                string letterOnlyPattern = @"^[a-zA-Z]$";

                if (string.IsNullOrEmpty(value) || value.ToLower() == "null")
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be blank.");
                }
                if(!Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
                {
                    throw new ArgumentException(nameof(Name), "Name can contain only letters.");
                }
                //if (string.IsNullOrWhiteSpace(value) || value == null || !value.Contains("[a-zA-Z]+"))
                //{
                //    throw new Exception("Name must not be empty and contain only letters a-z");
                //}
                _name = value.Trim();
            } 
        }
        public string City {
            get
            {
                return _city;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "City cannot be blank.");
                }
                if (value.Trim().Length < 3)
                {
                    throw new Exception("City must not be empty and contain atleast 3 or more characters");
                }
                _city = value.Trim();
            }
        }
        public string Arena
        {
            get
            {
                return _arena;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Arena cannot be blank.");
                }
                _arena = value.Trim();
            }
        }
        public Conference Conference { get; private set; }
        public Division Division { get; private set; }

        public Team()
        {
        }
        public Team(string name, string city, string arena, Conference conference, Division division)
        {
            Name = name;
            City = city;
            Arena = arena;
            Conference = conference;
            Division = division;
            players = new List<Player>();
        }

        public Team(string name, Conference conference, Division division)
        {
            Name = name;
            Conference = conference;
            Division = division;
        }

        public Team(string name)
        {
            Name = name;
        }

        public List<Player> players { get; private set; }

        //TODO: Add method to add a new player
        //1) Validate newPlayer is not null
        //2) Validate newPlayer Player No is not already on the players list
        //3) Validate players list is not already full (max 23 players per team)
        public void AddPlayer(Player newPlayer)
        {
            if(newPlayer == null)
            {
                throw new ArgumentNullException(nameof(AddPlayer), "Player cannot be null");
            }
            if(players.Count == 23)
            {
                throw new Exception("Team is full.");
            }
            int index = players.FindIndex(x => x.PlayerNo == newPlayer.PlayerNo);
            if (index >= 0)
            {
                throw new Exception("Player no. is already existed.");
            }
            players.Add(newPlayer);
        }
    }
}
