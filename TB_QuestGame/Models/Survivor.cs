using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Survivor : Character
    {
        #region ENUMERABLES

        public enum StarterAttribute
        {
            None,
            Strength,
            Charm,
            Knowledge,
            Craftsmanship,
            Sneak
        }

        #endregion

        #region FIELDS

        private StarterAttribute _startingAttribute;
        private string _birthState;
        private bool _canKill; //asking player if they will have the potential to kill to survive
        private int _kills; //number of kills collected during game
        private List<int> _locationsVisited;
        private int _locationId;
        private int _exp;
        private int _health;
      
        #endregion

        #region PROPERTIES

        public StarterAttribute StartingAttribute
        {
            get { return _startingAttribute; }
            set { _startingAttribute = value; }
        }

        public string BirthState
        {
            get { return _birthState; }
            set { _birthState = value; }
        }

        public bool CanKill
        {
            get { return _canKill; }
            set { _canKill = value; }
        }

        public int Kills
        {
            get { return _kills; }
            set { _kills = value; }
        }

        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }
        public int Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Survivor()
        {
            _locationsVisited = new List<int>();
        }

        public Survivor(string name, RaceType race) : base(name, race)
        {
            _locationsVisited = new List<int>();
        }

        #endregion

        #region METHODS

        public override string Greeting()
        {
            return $"Hi, I'm {base.Name}. I mean no harm, I am only trying to survive.";
        }

        public bool HasVisisted(int _locationId)
        {
            if (LocationsVisited.Contains(_locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasEnoughExp(int expReq)
        {           
            if (Exp >= expReq)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }

        #endregion
    }
}
