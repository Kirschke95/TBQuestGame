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
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

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

        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentLocationId)
        {
            List<int> gameObjectIds = new List<int>();

            //create list of game object ids in current location id
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocationId)
                {
                    gameObjectIds.Add(gameObject.Id);
                }
            }

            //determine if game object id is valid id and return result
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UnlockRoom(int roomToUnlock)
        {
            GetLocationById(roomToUnlock).Locked = false;
            
        }

        public void RevealItem(int itemToReveal)
        {
            GetGameOjbectById(itemToReveal).IsVisible = true;
        }

        public GameObject GetGameOjbectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //run through gameobject list and find the correct one
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //specified id was not found
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The game object Id {Id} does not exist here.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return gameObjectToReturn;
        }

        public bool IsValidSurvivorObjectByLocationId(int survivorObjectId, int currentLocationId)
        {
            List<int> survivorObjectIds = new List<int>();

            //create list of survivor object ids that are in current location id
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocationId && gameObject is SurvivorObject)
                {
                    survivorObjectIds.Add(gameObject.Id);
                }
            }

            //determine if game object id is valid id and return the result
            if (survivorObjectIds.Contains(survivorObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidNpcByLocationId(int npcId, int currentLocationId)
        {
            List<int> npcIds = new List<int>();

            //create list of npcs in current location
            foreach (Npc npc in _npcs)
            {
                if (npc.LocationId == currentLocationId)
                {
                    npcIds.Add(npc.Id);
                }
            }

            //determine if object id is valid id and return result
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //specified id wasnt found do this
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The Npc Id {Id} does not exist.";
                throw new ArgumentException(feedbackMessage, Id.ToString());
            }

            return npcToReturn;
        }

        public List<Npc> GetNpcsByLocationId(int locationId)
        {
            List<Npc> npcs = new List<Npc>();

            foreach (Npc npc in _npcs)
            {
                if (npc.LocationId == locationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        public List<SurvivorObject> GetSurvivorObjectsByLocationId(int locationId)
        {
            List<SurvivorObject> survivorObjects = new List<SurvivorObject>();

            //run through game object list and grab all that are in current location id
            foreach (GameObject gameObject in _gameObjects)

            {
                if (gameObject.LocationId == locationId && gameObject is SellableObject)
                {
                    survivorObjects.Add(gameObject as SurvivorObject);
                }

                if (gameObject.LocationId == locationId && gameObject is SurvivorObject && gameObject.IsVisible == true)
                {
                    survivorObjects.Add(gameObject as SurvivorObject);
                }
            }

            return survivorObjects;
        }

        public List<GameObject> GetGameObjectsByLocationId(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == locationId && gameObject.IsVisible == true)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public List<SurvivorObject> SurvivorInventory()
        {
            List<SurvivorObject> inventory = new List<SurvivorObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == 0)
                {
                    inventory.Add(gameObject as SurvivorObject);
                }
            }

            return inventory;
        }
        #endregion

        #region methods to intialize all game elements

        /// <summary>
        /// initialize the world and all available locations
        /// </summary>
        private void InitializeWorld()
        {
            _worldLocations = WorldObjects.WorldLocations;
            _gameObjects = WorldObjects.gameObjects;
            _npcs = WorldObjects.Npcs;
        }

        #endregion


    }
}
