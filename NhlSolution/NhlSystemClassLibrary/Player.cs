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
                if(!Utilities.IsPositiveOrZero(value))
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
                if (!Utilities.IsPositiveOrZero(value))
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
                if (!Utilities.IsPositiveOrZero(value))
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

        public static Player Parse(string csvLine)
        {
            const char Delimiter = ',';
            /**the order of the column value are 
             0) PlayerNo
             1) Name
             2) Position
             3) GamedPlayed
             4) Goals
             5) Assists
            */
            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.Split(Delimiter);
            //verify that the length of the array
            if(tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"csv line must contain exactly {ExpectedColumnCount} values.");
            }
            int playerNo = int.Parse(tokens[0]);
            string name = tokens[1];
            Position position = Enum.Parse<Position>(tokens[2]);
            //Position position = (Position)Enum.Parse(typeof(Position), tokens[2]);
            int gamePlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);
            return new Player(playerNo, name, position, gamePlayed, goals, assists);
        }

        public static bool TryParse(string csvLine, out Player currentPlayer)
        {
            bool success = false;

            try
            {
                currentPlayer = Parse(csvLine);
                success = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Player TryParse method failed with exception {ex.Message}");
            }

            return success;
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
