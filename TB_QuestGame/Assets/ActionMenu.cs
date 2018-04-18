using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {

        public enum CurrentMenu
        {
            MissionIntro,
            InitalizeMission,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            SurvivorMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                    {
                        { ' ', SurvivorAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
                {
                    { '1', SurvivorAction.LookAround },
                    { '2', SurvivorAction.Travel },
                    { '3', SurvivorAction.ObjectMenu },
                    { '4', SurvivorAction.NonplayerCharacterMenu },
                    { '5', SurvivorAction.SurvivorMenu },
                    { '6', SurvivorAction.AdminMenu },                   
                    { '0', SurvivorAction.Exit }
                }
        };

        public static Menu SurvivorMenu = new Menu()
        {
            MenuName = "SurvivorMenu",
            MenuTitle = "Survivor Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
            {
                { '1', SurvivorAction.SurvivorInfo },
                { '2', SurvivorAction.Inventory },
                { '3', SurvivorAction.SurvivorLocationsVisited },
                { '4', SurvivorAction.ReturnToMainMenu }
            }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMnu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
            {
                { '1', SurvivorAction.LookAt },
                { '2', SurvivorAction.PickUp },
                { '3', SurvivorAction.PutDown },
                { '4', SurvivorAction.ReturnToMainMenu }
            }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "Npc Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
            {
                { '1', SurvivorAction.TalkTo },
                { '2', SurvivorAction.ReturnToMainMenu }
            }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, SurvivorAction>()
            {
                { '1', SurvivorAction.ListLocations },
                { '2', SurvivorAction.ListGameObjects },
                { '3', SurvivorAction.DisplayNonPlayableCharacters },
                { '0', SurvivorAction.ReturnToMainMenu }
            }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Survivor",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.SurvivorInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
