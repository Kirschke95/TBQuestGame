using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{

    //Name: Tyler Kirschke
    //Capstone Project: The Text Based Quest Game - The Survival
    //Class: CIT 195
    //Instructor: John Velis
    //Date: 04/29/2018
    //Description: A text based game using the console window to let a user create a character with basic info
    //and navigate through a simple game using multiple menus to make decisions. This game requires the user
    //to navigate and unlock specific rooms and gather items in order to escape a mysterious building. 

    class Program
    {
        /// <summary>
        /// instantiate the game controller, passing all control to the new Controller object
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Controller gameController = new Controller();

            Console.ReadKey();
        }


    }
}
