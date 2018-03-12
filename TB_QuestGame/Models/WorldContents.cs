using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    
    public class WorldContents
    {
        #region lists maintained by worldcontents

        //
        //list available locations the survivor can travel to
        //
        private List<WorldLocations> _worldLocations;

        public List<WorldLocations> WorldLocations
        {
            get { return _worldLocations; }
            set { _worldLocations = value; }
        }

        #endregion

        #region Constructors
        public WorldContents()
        {
            InitializeWorld();
        }
        #endregion

        #region METHODS

        public bool IsValidLocation(int locationId)
        {
            List<int> locationIds = new List<int>();

            //create list of location ids
            foreach (WorldLocations wl in _worldLocations)
            {
                locationIds.Add(wl.LocationID);
            }

            //determine if location id user typed is valid and return result
            if (locationIds.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public WorldLocations GetLocationById(int Id)
        {
            WorldLocations worldLocation = null;

            //run through world location list and grab correct one
            foreach (WorldLocations location in _worldLocations)
            {
                if (location.LocationID == Id)
                {
                    worldLocation = location;
                }
            }

            //if specified id is not in list of locations
            if (worldLocation == null)
            {
                string feedbackMessage = $"This area doesn't exist here.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return worldLocation;
        }

        public bool IsLockedLocation(int locationId)
        {
            WorldLocations worldLocation = GetLocationById(locationId);
            if (worldLocation.Locked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetMaxLocationId()
        {
            int maxId = 0;

            foreach (WorldLocations location in _worldLocations)
            {
                if (location.LocationID > maxId)
                {
                    maxId = location.LocationID;
                }
            }

            return maxId;
        }

        #endregion

        #region methods to intialize all game elements

        /// <summary>
        /// initialize the world and all available locations
        /// </summary>
        private void InitializeWorld()
        {
            _worldLocations = WorldObjects.WorldLocations;
        }

        #endregion

        
    }
}
