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
            _playingGame = true;

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
