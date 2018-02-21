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
            "You are now in the Norlon Corporation research facility located in " +
            "the city of Heraklion on the north coast of Crete. You have passed through " +
            "heavy security and descended an unknown number of levels to the top secret " +
            "research lab for the Aion Project.\n" +
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

        public static string InitializeGetSurvivorAge(Survivor gameTraveler)
        {
            string messageBoxText =
                $"Good job {gameTraveler.Name}, I'm surprised you remember. Now we'll get your age.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetSurvivorAttribute(Survivor gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it's important to know what you're good at in a time like this.\n" +
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

        public static string InitializeEchoSurviorInformation(Survivor gameSurvivor)
        {
            string messageBoxText =
                $"Very good then {gameSurvivor.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tTraveler Name: {gameSurvivor.Name}\n" +
                $"\tTraveler Age: {gameSurvivor.Age}\n" +
                $"\tSurvivor starting attribute: {gameSurvivor.StartingAttribute}\n";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Survivor gameTraveler)
        {
            string messageBoxText =
                $"\tTraveler Name: {gameTraveler.Name}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Race: {gameTraveler.Race}\n" +
                " \n";

            return messageBoxText;
        }

        //public static string Travel(int currentSpaceTimeLocationId, List<SpaceTimeLocation> spaceTimeLocations)
        //{
        //    string messageBoxText =
        //        $"{gameTraveler.Name}, Aion Base will need to know the name of the new location.\n" +
        //        " \n" +
        //        "Enter the ID number of your desired location from the table below.\n" +
        //        " \n";


        //    string spaceTimeLocationList = null;

        //    foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
        //    {
        //        if (race != Character.RaceType.None)
        //        {
        //            raceList += $"\t{race}\n";
        //        }
        //    }

        //    messageBoxText += raceList;

        //    return messageBoxText;
        //}

        #endregion
    }
}
