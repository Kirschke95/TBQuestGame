using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "The Survivor" };
        public static List<string> FooterText = new List<string>() { "Kirschke Productions, 2018" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You have woken up with little recollection of who you are. It's cold and dark." +
            "You can smell something fowl. You look around, and you can tell you're in a " +
            "dark room, but not sure where you are. This is going to be tough. You will" +
            "struggle. There will be obstacles. Good luck.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "The rest of your life begins now.\n" +
            " \n" +
            "\tFirst you'll jot down what you do remember about yourself..\n" +
            " \n" +
            "\tPress any key to open your journal and attempt to remember.\n";

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "You are now in a dark room. What's outside is unknown. " +
            "The air is dry and smells awful. You can't really see much. " +
            "You should look around, and see if you can feel anything in the room. " +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before we start, let's get some information Survivor.\n" +
                " \n" +
                "You will be prompted for the required information. Please write the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeGetSurvivorName()
        {
            string messageBoxText =
                "Enter your name survivor.\n" +
                " \n" +
                "Please use the name you will be called for the remainder of your days.";

            return messageBoxText;
        }

        public static string InitializeGetSurvivorAge(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Good job {gameSurvivor.Name}, I'm surprised you remember. Now we'll get your age.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeJournalGetSurvivorAttribute(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"{gameSurvivor.Name}, it's important to know what you're good at in a time like this.\n" +
                " \n" +
                "Jot down your starting attribute.\n";


            string attributeList = null;

            foreach (Survivor.StarterAttribute attribute in Enum.GetValues(typeof(Survivor.StarterAttribute)))
            {
                if (attribute != Survivor.StarterAttribute.None)
                {
                    attributeList += $"\t{attribute}\n";
                }
            }

            messageBoxText += attributeList;

            return messageBoxText;
        }

        public static string InitializeJournalGetSurvivorBirthState(Survivor gameSurvivor)
        {
            string messageBoxText = $"{gameSurvivor.Name}, we need to know where you come from.\n" +
                "\n" +
                "Please write the state  you were born in below in your journal.\n";

            return messageBoxText;
        }

        public static string InitializeJournalGetSurvivorCanKill(Survivor gameSurvivor)
        {
            string messageBoxText = $"This is a drastically important piece of info {gameSurvivor.Name}.\n" +
                "\n" +
                "Do you have the potential to kill a person if it means surviving?\n";

            return messageBoxText;
        }

        public static string InitializeEchoSurviorInformation(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Very good then {gameSurvivor.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tSurvivor Name: {gameSurvivor.Name}\n" +
                $"\tSurvivor Age: {gameSurvivor.Age}\n" +
                $"\tSurvivor starting attribute: {gameSurvivor.StartingAttribute}\n" +
                $"\tSurvivor birth state: {gameSurvivor.BirthState}\n" +
                $"\tSurvivor has potential to KILL: {gameSurvivor.CanKill}";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string ListWorldLocations(IEnumerable<WorldLocations> worldLocations)
        {
            string messageboxText =
                "All World Locations\n" +
                "\n" +

                //display a table header
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //display all world locations
            string worldLocationsList = null;
            foreach (WorldLocations worldLocation in worldLocations)
            {
                worldLocationsList +=
                    $"{worldLocation.LocationID}".PadRight(10) +
                    $"{worldLocation.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageboxText += worldLocationsList;

            return messageboxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //display table name 
            string messageboxText =
                "All Game Objects\n" +
                "\n" +

                //display a table header
                "ID".PadRight(10) + "Name".PadRight(30) + "LocationId".PadRight(10) + "\n" + 
                "---".PadRight(10) + "----------------------".PadRight(30) + "----------------------".PadRight(10) + "\n";

            //display all world locations
            string gameObjectList = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectList +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageboxText += gameObjectList;

            return messageboxText;
        }

        public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
        {
            //table name
            string messageboxTest = 
                "NPC Objects\n" +
                " \n" +

                //table header
                "ID".PadRight(10) + "Name".PadRight(30) + "Location ID".PadRight(10) + "\n" +
                 "---".PadRight(10) + "----------------------".PadRight(30) + "----------------------".PadRight(10) + "\n";

            //display npc objects in rows
            string npcObjectRows = null;
            foreach (Npc npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageboxTest += npcObjectRows;

            return messageboxTest;
        }

        public static string NpcsChooseList(IEnumerable<Npc> npcs)
        {
            //table name
            string messageboxTest =
                "NPC Objects\n" +
                " \n" +

                //table header
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                 "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //display npc objects in rows
            string npcRows = null;
            foreach (Npc npc in npcs)
            {
                npcRows +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageboxTest += npcRows;

            return messageboxTest;
        }
        public static string SurvivorInfo(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"\t Survivor Name: {gameSurvivor.Name}\n" +
                $"\t Survivor Age: {gameSurvivor.Age}\n" +
                $"\t Survivor Starter Attribute: {gameSurvivor.StartingAttribute}\n" +
                $"\t Survivor birth state: {gameSurvivor.BirthState}\n" +
                $"\t Survivor has potential to KILL: {gameSurvivor.CanKill}" +
                $"\n\n\t {gameSurvivor.Greeting()}" +
                " \n\n\n";

            //gameSurvivor.Greeting();

            return messageBoxText;
        }

        //public static string EditInfo(Survivor gameSurvivor)
        //{
        //    if (gameSurvivor.HasEnoughExp(100))
        //    {
        //        string messageBoxText = "You have enough experience to change your starting attribute"
        //    }
        //}

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //table name and column headers
            string messageBoxText = "Game Objects\n" +
                "\n" +

                //table header
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //display all survivor objects
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;
            return messageBoxText;

        }

        public static string DisplayJournalInformation(IEnumerable<GameObject> gameObjects)
        {
            string messageBoxText = "";

            //display table header
            messageBoxText =
                $"ID".PadRight(10) +
                $"Name".PadRight(30) +
                $"Location".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "------------------------------".PadRight(30) +
                "---------------------".PadRight(10) +
                "\n";

            string gameObjectRow = null;

            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRow +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRow;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                "\n" +
                gameObject.Description + "\n" +
                "\n";

            if (gameObject is SurvivorObject)
            {
                SurvivorObject survivorObject = gameObject as SurvivorObject;

                messageBoxText += $"The {survivorObject.Name} has a value of {survivorObject.Value} and ";

                if (survivorObject.CanInventory)
                {
                    messageBoxText += "can be picked up.";
                }
                else
                {
                    messageBoxText += "can not be picked up.";
                }

            }
            else
            {
                messageBoxText += $"The {gameObject.Name} cannot be picked up";
            }

            return messageBoxText;
        }

        public static string LookAround(WorldLocations worldLocation)
        {
            string messageBox = $"You are currently in {worldLocation.Name}\n" +
                $"\n";
            //add room contents later when we get into world objects 
            return messageBox;
        }

        public static string CurrentInventory(IEnumerable<SurvivorObject> inventory)
        {
            string messageBoxText = "";

            //display table header
            messageBoxText =
                $"ID".PadRight(10) +
                $"Name".PadRight(30) +
                $"Type".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "------------------------------".PadRight(30) +
                "---------------------".PadRight(10) +
                "\n";

            string inventoryObjectRows = null;
            foreach (SurvivorObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        public static string Travel(Survivor gameSurvivor, List<WorldLocations> worldLocations)
        {
            string messageBoxText =
                $"{gameSurvivor.Name}, you need to make a move if you want to make it out of here.\n" +
                " \n" +
                "Pick your next location to move too, and make your choice carefully.\n" +
                "\n" +

                //display list of the locations to travel to
                "ID".PadRight(10) + "Location".PadRight(30) + "Locked".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-----".PadRight(10) + "\n";

            string locationList = null;
            foreach (WorldLocations location in worldLocations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.Name}".PadRight(30) +
                    $"{location.Locked}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        public static string CurrentLocationInfo(WorldLocations worldLocation)
        {
            string messageBoxText =
                $"You are currently in {worldLocation.Name}\n" +
                "\n" + worldLocation.Description;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<WorldLocations> worldLocations)
        {
            string messageboxText =
                "Locations Visisted\n" +
                "\n" +

                //display a table header
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //display all world locations
            string worldLocationsList = null;
            foreach (WorldLocations worldLocation in worldLocations)
            {
                worldLocationsList +=
                    $"{worldLocation.LocationID}".PadRight(10) +
                    $"{worldLocation.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageboxText += worldLocationsList;

            return messageboxText;
        }
        public static List<string> StatusBox(Survivor survivor, WorldContents _worldContents)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {survivor.Exp}\n");
            statusBoxText.Add($"Health: {survivor.Health}\n");

            return statusBoxText;


            #endregion
        }
    }
}
