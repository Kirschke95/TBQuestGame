using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        public enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
            
        }

        #endregion
        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Survivor _gameSurvivor;
        WorldContents _worldContents;

        ViewStatus _viewStatus = ViewStatus.PlayingGame;
        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Survivor gameSurvivor, WorldContents worldContents)
        {
            _gameSurvivor = gameSurvivor;
            _worldContents = worldContents;

            _viewStatus = ViewStatus.PlayingGame;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public SurvivorAction GetActionMenuChoice(Menu menu)
        {
            SurvivorAction choosenAction = SurvivorAction.None;

            //
            //create array of valid menu choices
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            //validate key pressed against menuchoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));


            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("All locations", Text.ListWorldLocations(_worldContents.WorldLocations),
                ActionMenu.AdminMenu, "");
        }

        public void DisplayListOfGameObjects()
        {
            DisplayGamePlayScreen("All Game Objects", Text.ListAllGameObjects(_worldContents.GameObjects),
                ActionMenu.AdminMenu, "");
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Inventory", Text.CurrentInventory(_gameSurvivor.Inventory), ActionMenu.MainMenu, "");
        }

        public int GetNextTravelLocation()
        {
            int locationId = 0;
            bool validLocationId = false;

            return locationId;
        }

        public void DisplayLocationsVisisted()
        {
            //create a list of locations that survivor has been to
            List<WorldLocations> visitedLocations = new List<WorldLocations>();
            foreach (int locationId in _gameSurvivor.LocationsVisited)
            {
                visitedLocations.Add(_worldContents.GetLocationById(locationId));
            }

            DisplayGamePlayScreen("Locations you've been too", Text.VisitedLocations(visitedLocations), ActionMenu.MainMenu, "");
        }

        public void DisplayLookAround()
        {
            WorldLocations currentLocation = _worldContents.GetLocationById(_gameSurvivor.LocationId);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentLocation), ActionMenu.MainMenu, "");
        }

        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGameObject = false;

            //list of game objects in current location
            List<GameObject> currentLocationObjects = _worldContents.GetGameObjectsByLocationId(_gameSurvivor.LocationId);

            if (currentLocationObjects.Count > 0)
            {
                DisplayGamePlayScreen("Look at an item", Text.GameObjectsChooseList(currentLocationObjects), ActionMenu.MainMenu, "");

                while (!validGameObject)
                {
                    //get integer from user
                    GetInteger($"Enter the Id number of the object you want to look at: ", 0, 0, out gameObjectId);

                    if (_worldContents.IsValidGameObjectByLocationId(gameObjectId, _gameSurvivor.LocationId))
                    {
                        validGameObject = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered in invalid game object Id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at an item", "This room has no items.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public int DisplayGetSurvivorObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //get list of survivor objects in current location
            List<SurvivorObject> survivorObjectsInCurrentLocation = _worldContents.GetSurvivorObjectsByLocationId(_gameSurvivor.LocationId);

            if (survivorObjectsInCurrentLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick up item", Text.GameObjectsChooseList(survivorObjectsInCurrentLocation), ActionMenu.MainMenu, "");

                while (!validGameObjectId)
                {
                    //get int from user
                    GetInteger($"Enter the Id number of the item you want to pick up:", 0, 0, out gameObjectId);

                    //validate integer as valid object id AND in current location
                    if (_worldContents.IsValidGameObjectByLocationId(gameObjectId, _gameSurvivor.LocationId))
                    {
                        SurvivorObject survivorObject = _worldContents.GetGameOjbectById(gameObjectId) as SurvivorObject;
                        if (survivorObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("You cannot pick that item up. Try again.");
                        }
                    }
                    else
                    {
                        DisplayInputErrorMessage("You entered an invalid item Id, try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick up item", "There are no items here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public int DisplayGetInventoryObjectToPutDown()
        {
            int survivorObjectId = 0;
            bool validInventoryObject = false;

            if (_gameSurvivor.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Item", Text.GameObjectsChooseList(_gameSurvivor.Inventory), ActionMenu.MainMenu, "");

                while (!validInventoryObject)
                {
                    //get integer from user
                    GetInteger($"Enter the Id number of the item you want to put down: ", 0, 0, out survivorObjectId);

                    //find object in inventory
                    //note: LINQ used, but foreach loop may also be used
                    SurvivorObject objectToPutDown = _gameSurvivor.Inventory.FirstOrDefault(o => o.Id == survivorObjectId);

                    //validate object is in inventory
                    if (objectToPutDown != null)
                    {
                        validInventoryObject = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an Id that is not in your inventory. Try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Put Down Item", "You have nothing in your inventory.", ActionMenu.MainMenu, "");
            }

            return survivorObjectId;
        }

        public void DisplayConfirmSurvivorObjectRemovedFromInventory(SurvivorObject objectToPutDown)
        {
            DisplayGamePlayScreen("Put Down Item", $"The {objectToPutDown.Name} has been removed.", ActionMenu.MainMenu, "");
        }

        public void DisplayConfirmSurvivorObjectAddedToInventory(SurvivorObject objectAddedToInventory)
        {
            if (objectAddedToInventory.PickUpMessage != null)
            {
                DisplayGamePlayScreen("Pick up game item", objectAddedToInventory.PickUpMessage, ActionMenu.MainMenu, "");
            }
            else
            {
                DisplayGamePlayScreen("Pick up game item", $"The {objectAddedToInventory.Name} has been added to your inventory", ActionMenu.MainMenu, "");
            }
            
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.MainMenu, "");
        }

        public int GetNextLocation()
        {
            int locationId = 0;
            bool validLocation = false;

            DisplayGamePlayScreen("Move to a new location", Text.Travel(_gameSurvivor, _worldContents.WorldLocations),
                ActionMenu.MainMenu, "");

            while (!validLocation)
            {
                //get integer from user
                GetInteger($"Enter where you want to move {_gameSurvivor.Name}: ", 1,
                    _worldContents.GetMaxLocationId(), out locationId);


                //validate integer as valid location id, then by locked or not
                if (_worldContents.IsValidLocation(locationId))
                {
                    if (_worldContents.IsLockedLocation(locationId))
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It seems this room is locked. Pick a new location.");
                    }
                    else if (_worldContents.GetLocationById(locationId).RequiredExp > _gameSurvivor.Exp)
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You do not have the required experience to travel here.");
                    }
                    else
                    {
                        validLocation = true;
                    }
                    

                }
                else
                {
                    DisplayInputErrorMessage("It seems you're trying to go somewhere that doesn't exist. Try again.");
                }

            }

            return locationId;
        }

        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);
                               
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameSurvivor, _worldContents))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            
            
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //validate on range if ither minmumvalue or max are not 0
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                    
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Survivor.StarterAttribute GetStarterAttribute()
        {
            Survivor.StarterAttribute attibuteChoice;
            Enum.TryParse<Survivor.StarterAttribute>(Controller.UppercaseFirst(Console.ReadLine()), out attibuteChoice);

            return attibuteChoice;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            //Console.WriteLine(tabSpace + @" _____ _              ___  _               ______          _           _   ");
            //Console.WriteLine(tabSpace + @"|_   _| |            / _ \(_)              | ___ \        (_)         | |  ");
            //Console.WriteLine(tabSpace + @"  | | | |__   ___   / /_\ \_  ___  _ __    | |_/ _ __ ___  _  ___  ___| |_ ");
            //Console.WriteLine(tabSpace + @"  | | | '_ \ / _ \  |  _  | |/ _ \| '_ \   |  __| '__/ _ \| |/ _ \/ __| __|");
            //Console.WriteLine(tabSpace + @"  | | | | | |  __/  | | | | | (_) | | | |  | |  | | | (_) | |  __| (__| |_ ");
            //Console.WriteLine(tabSpace + @"  \_/ |_| |_|\___|  \_| |_|_|\___/|_| |_|  \_|  |_|  \___/| |\___|\___|\__|");
            //Console.WriteLine(tabSpace + @"                                                         _/ |              ");
            //Console.WriteLine(tabSpace + @"                                                        |__/             ");

            Console.WriteLine(tabSpace + @"___________.__               _________                  .__              .__");
            Console.WriteLine(tabSpace + @"\__    ___/|  |__   ____    /   _____/__ ____________  _|__|__  _______  |  | ");
            Console.WriteLine(tabSpace + @"  |    |   |  |  \_/ __ \   \_____  \|  |  \_  __ \  \/ /  \  \/ /\__  \ |  |");
            Console.WriteLine(tabSpace + @"  |    |   |   Y  \  ___/   /        \  |  /|  | \/\   /|  |\   /  / __ \|  |__");
            Console.WriteLine(tabSpace + @"  |____|   |___|  /\___  > /_______  /____/ |__|    \_/ |__| \_/  (____  /____/");
            Console.WriteLine(tabSpace + @"                \/     \/          \/                                  \/      ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Survivor";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, SurvivorAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != SurvivorAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>survivor object with all properties updated</returns>
        public Survivor GetInitialSurviorInformation()
        {
            Survivor survivor = new Survivor();

            //
            // intro
            //
            DisplayGamePlayScreen("Journal Entry", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get survivor's name
            //
            DisplayGamePlayScreen("Journal Entry - Name", Text.InitializeGetSurvivorName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Write your name: ");
            survivor.Name = Controller.UppercaseFirst(GetString());

            //
            // get survivor's age
            //
            DisplayGamePlayScreen("Journal Entry - Age", Text.InitializeGetSurvivorAge(survivor), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Write your age {survivor.Name}: ", 0, 1000000, out gameTravelerAge);
            survivor.Age = gameTravelerAge;

            //
            // get survivor's race
            //
            DisplayGamePlayScreen("Journal Entry - Starting Attribute", Text.InitializeJournalGetSurvivorAttribute(survivor), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Choose your starting attribute {survivor.Name}: ");
            survivor.StartingAttribute = GetStarterAttribute();

            //
            // get survivor's birth state
            //
            DisplayGamePlayScreen("Journal Entry - Birth State", Text.InitializeJournalGetSurvivorBirthState(survivor), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Write down your birth state: ");
            survivor.BirthState = Controller.UppercaseFirst(GetString());

            //
            // get survivor's potential to kill
            //
            DisplayGamePlayScreen("Journal Entry - Potential to Kill", Text.InitializeJournalGetSurvivorCanKill(survivor), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Can you kill to survive?");
            survivor.CanKill = Controller.GetYesOrNo();

            //
            // echo the survivor's info
            //
            DisplayGamePlayScreen("Journal Entry - Complete", Text.InitializeEchoSurviorInformation(survivor), ActionMenu.MissionIntro, "");
            GetContinueKey();


            return survivor;
        }

        #region ----- display responses to menu action choices -----

        public void DisplaySurvivorInfo()
        {
            DisplayGamePlayScreen("Survivor Information", Text.SurvivorInfo(_gameSurvivor), ActionMenu.MainMenu, "");

        }

        

        //public void DisplayUpdateSurvivorInfo()
        //{
        //    DisplayGamePlayScreen("Edit Your Info", Text.EditInfo(_gameSurvivor), ActionMenu.MainMenu, "");
        //}

        #endregion

        #endregion
    }
}
