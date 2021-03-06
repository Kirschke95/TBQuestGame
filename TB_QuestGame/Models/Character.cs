﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Thorian,
            Xantorian
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age;
        private bool _friendly;
        private int _locationId;

       

        private RaceType _race;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool Friendly
        {
            get { return _friendly; }
            set { _friendly = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public virtual int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race)
        {
            _name = name;
            _race = race;
        }

        #endregion

        #region METHODS

        public virtual string Greeting() //virtual will allow us to use it directly with subclasses, or OVERRIDE the method
        {
            return $"Hello, my name is {_name}.";
        }

        #endregion
    }
}
