using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NhlSystemClassLibrary
{
    public class Player
    {
        const int MinPlayerNo = 1;
        const int MaxPlayerNo = 98;

        private int _playerNo; //1-98
        private string _name; // not blank
        private Position _position;
        private int _gamePlayed; // > 0
        private int _goals; // > 0
        private int _assists; // > 0
        private int _points; //goal + assist

        public int PlayerNo
        {
            //get
            //{
            //    return _playerNo;
            //}
            get => _playerNo;
            set
            {
                if (value < MinPlayerNo || value > MaxPlayerNo)
                {
                    throw new ArgumentException(nameof(PlayerNo), "Player no. must be between 1 and 98.");
                }
                _playerNo = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be blank.");
                }
                _name = value;
            }
        }

        public Position Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public int GamePlayed
        {
            get
            {
                return _gamePlayed;
            }
            //allow acess to inheritance class - protected 
            protected set
            {
                if(Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException(nameof(GamePlayed), "Game Played cannot be lower than 0.");
                }
                _gamePlayed = value;
            }
        }

        public int Goals
        {
            get
            {
                return _goals;
            }
            private set
            {
                if (Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException(nameof(Goals), "Goals cannot be lower than 0.");
                }
                _goals = value;
            }
        }

        public int Assists
        {
            get
            {
                return _assists;
            }
            private set
            {
                if (Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException(nameof(Assists), "Assists cannot be lower than 0.");
                }
                _assists = value;
            }
        }

        private int Points
        {
            get
            {
                return Goals + Assists;
            }
            set
            {
                _points = value;
            }
        }

        public Player() { }
        public Player(int playerNo, string name, Position position, int gamePlayed, int goals, int assists)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
            GamePlayed = gamePlayed;
            Goals = goals;
            Assists = assists;
        }

        public Player(int playerNo, string name, Position position)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
        }

        public void AddGamesPlayed()
        {
            GamePlayed += 1;
        }

        public void AddGoal()
        {
            Goals += 1;
        }

        public void AddAssist()
        {
            Assists += 1;
        }
    }
}
