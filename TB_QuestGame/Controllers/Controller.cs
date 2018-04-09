using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Survivor _gameSurvivor;
        private WorldContents _worldContents;
        private bool _playingGame;
        private WorldLocations _currentLocation;


        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameSurvivor = new Survivor();
            _worldContents = new WorldContents();
            _gameConsoleView = new ConsoleView(_gameSurvivor, _worldContents);
            SurvivorObject survivorObject;
            _playingGame = true;

            //add event handler for adding.subtracting to/from inventory
            foreach (GameObject gameObject in _worldContents.GameObjects)
            {
                if (gameObject is SurvivorObject)
                {
                    survivorObject = gameObject as SurvivorObject;
                    survivorObject.ObjectAddedToInventory += HandleObjectAddedToInventory;
                }
            }

            //add initial items to the survivor's inventory
            _gameSurvivor.Inventory.Add(_worldContents.GetGameOjbectById(5) as SurvivorObject);
            _gameSurvivor.Inventory.Add(_worldContents.GetGameOjbectById(6) as SurvivorObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            SurvivorAction travelerActionChoice = SurvivorAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");
            _currentLocation = _worldContents.GetLocationById(_gameSurvivor.LocationId);
            _gameConsoleView.DisplayStatusBox();

            //
            // game loop
            //
            while (_playingGame)
            {
                UpdateGameStatus();
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case SurvivorAction.None:
                        break;

                    case SurvivorAction.SurvivorInfo:
                        _gameConsoleView.DisplaySurvivorInfo();
                        _gameConsoleView.DisplayStatusBox();
                        break;

                    case SurvivorAction.SurvivorEdit:

                        break;

                    case SurvivorAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
                        _gameConsoleView.DisplayStatusBox();
                        break;

                    case SurvivorAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        _gameConsoleView.DisplayStatusBox();
                        break;

                    case SurvivorAction.Travel:
                        //get new location choice and update current location

                        _gameSurvivor.LocationId = _gameConsoleView.GetNextLocation();
                        _currentLocation = _worldContents.GetLocationById(_gameSurvivor.LocationId);
                        _gameConsoleView.DisplayStatusBox();
                        //set gameplayscreen as current location info
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation),
                            ActionMenu.MainMenu, "");
                        break;

                    case SurvivorAction.SurvivorLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisisted();
                        _gameConsoleView.DisplayStatusBox();
                        break;

                    case SurvivorAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfGameObjects();
                        _gameConsoleView.DisplayStatusBox();
                        break;

                    case SurvivorAction.LookAt:
                        LookAtAction();
                        break;

                    case SurvivorAction.PickUp:
                        PickUpAction();
                        break;

                    case SurvivorAction.PutDown:
                        PutDownAction();
                        break;

                    case SurvivorAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case SurvivorAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an option from the menu",
                            ActionMenu.AdminMenu, "");
                        break;

                    case SurvivorAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation),
                            ActionMenu.MainMenu, "");
                        break;

                    case SurvivorAction.Exit:
                        _playingGame = false;
                        break;



                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        private void LookAtAction()
        {
            //display list of traveler objects in location id and get player choice
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //display game object info
            if (gameObjectToLookAtId != 0)
            {
                //gets game object from world 
                GameObject gameObject = _worldContents.GetGameOjbectById(gameObjectToLookAtId);

                //displays that item info
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {
            //display list of objects in current location id and get a choice
            int survivorObjectToPickUpId = _gameConsoleView.DisplayGetSurvivorObjectToPickUp();

            //add object to inventory
            if (survivorObjectToPickUpId != 0)
            {
                //get game object from world
                SurvivorObject survivorObject = _worldContents.GetGameOjbectById(survivorObjectToPickUpId) as SurvivorObject;

                //note: object added to list and location id is set to 0 - INVENTORY
                _gameSurvivor.Inventory.Add(survivorObject);
                survivorObject.LocationId = 0; // location id 0 means INVENTORY

                //display confirm message
                _gameConsoleView.DisplayConfirmSurvivorObjectAddedToInventory(survivorObject);
            }
        }

        private void PutDownAction()
        {
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            SurvivorObject survivorObject = _worldContents.GetGameOjbectById(inventoryObjectToPutDownId) as SurvivorObject;

            _gameSurvivor.Inventory.Remove(survivorObject);
            survivorObject.LocationId = _gameSurvivor.LocationId;

            _gameConsoleView.DisplayConfirmSurvivorObjectRemovedFromInventory(survivorObject);
        }

        private void UpdateGameStatus()
        {
            if (!_gameSurvivor.HasVisisted(_currentLocation.LocationID))
            {
                _gameSurvivor.LocationsVisited.Add(_currentLocation.LocationID);
                _gameSurvivor.Exp += _currentLocation.ExperiencePoints;
            }

            if (_currentLocation.RoomWidth > 0)
            {

            }

            if (_gameSurvivor.Health <= 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("You gave it your best, but you are now dead.", "", ActionMenu.MainMenu, "");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Survivor survivor = _gameConsoleView.GetInitialSurviorInformation();


            _gameSurvivor.Name = survivor.Name;
            _gameSurvivor.Age = survivor.Age;
            _gameSurvivor.StartingAttribute = survivor.StartingAttribute;
            _gameSurvivor.BirthState = survivor.BirthState;
            _gameSurvivor.CanKill = survivor.CanKill;
            _gameSurvivor.LocationId = 1;

            _gameSurvivor.Exp = 0;
            _gameSurvivor.Health = 100;
        }

        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(SurvivorObject))
            {
                SurvivorObject survivorObject = gameObject as SurvivorObject;
                switch (survivorObject.Type)
                {
                    case SurvivorObjectType.Food:
                        _gameSurvivor.Health += survivorObject.Value;

                        //REMOVE OBJECT
                        if (survivorObject.IsConsumable)
                        {
                            survivorObject.LocationId = -1; //-1 being used to declare it is gone
                        }
                        break;
                    case SurvivorObjectType.Medicine:
                        break;
                    case SurvivorObjectType.Tool:
                        break;
                    case SurvivorObjectType.Weapon:
                        break;
                    case SurvivorObjectType.Item:
                        break;
                    case SurvivorObjectType.Information:
                        
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleObjectUsed(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(SurvivorObject))
            {
                SurvivorObject survivorObject = gameObject as SurvivorObject;
                switch (survivorObject.Type)
                {
                    case SurvivorObjectType.Food:
                        break;
                    case SurvivorObjectType.Medicine:
                        break;
                    case SurvivorObjectType.Tool:
                        break;
                    case SurvivorObjectType.Weapon:
                        break;
                    case SurvivorObjectType.Item:
                        break;
                    case SurvivorObjectType.Information:
                        if (survivorObject.IsUsable)
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return s.First().ToString().ToUpper() + s.Substring(1);
        }

        public static bool GetYesOrNo()
        {
            string userResponse = Console.ReadLine().ToLower();
            bool userChoice = false;

            if (userResponse == "yes")
            {
                userChoice = true;

            }
            else if (userResponse == "no")
            {
                userChoice = false;

            }
            else
            {
                userChoice = false;
            }

            return userChoice;
        }

        #endregion
    }
}
