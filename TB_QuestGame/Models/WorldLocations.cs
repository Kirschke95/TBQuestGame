using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class WorldLocations
    {
        #region FIELDS

        private string _name;
        private int _locationID;
        private string _description;
        private bool _locked;
        private int _experiencePoints;
        private int _requiredExp;
        private int _healthAffect;
        private int _roomHeight;
        private int _roomWidth;

        #endregion

        #region PROPERTIES

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int RequiredExp
        {
            get { return _requiredExp; }
            set { _requiredExp = value; }
        }

        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int HealthAffect
        {
            get { return _healthAffect; }
            set { _healthAffect = value; }
        }

        public int RoomHeight
        {
            get { return _roomHeight; }
            set { _roomHeight = value; }
        }

        public int RoomWidth
        {
            get { return _roomWidth; }
            set { _roomWidth = value; }
        }

        #endregion
    }
}
