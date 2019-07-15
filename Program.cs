using System;
using System.Threading;
using CastleGrimtol.Project;
using CastleGrimtol.Project.Models;
namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO  optionally here or else in the gameservice, get the players name and create an instance of a player with that name
            //TODO  create an instance of a gameservice and then invoke the StartGame method
            string NameStr = "What is your name?";
            for (int i = 0; i < NameStr.Length; i++)
            {
                Console.Write(NameStr[i]);
                Thread.Sleep(250);
            }
            Console.WriteLine();
            string nameOfPlayer = Console.ReadLine();
            Player player = new Player(nameOfPlayer);
            GameService gameservice = new GameService(player);
            gameservice.StartGame();
        }
    }
}




// static void Main(string[] args)
// {
//     // Change to your number of menuitems.
//     const int maxMenuItems = 3;
//     int selector = 0;
//     bool good = false;
//     while (selector != maxMenuItems)
//     {
//         Console.Clear(); 
//         DrawTitle();
//         DrawMenu(maxMenuItems);
//         good = int.TryParse(Console.ReadLine(), out selector);
//         if (good)
//         {
//             switch (selector)
//             {
//                 case 1:
//                     Console.WriteLine("// code for case 1 here");
//                     break;
//                 case 2:
//                     Console.WriteLine("// code for case 2 here");
//                     break;
//                 // possibly more cases here
//                 default:
//                     if (selector != maxMenuItems)
//                     {
//                         ErrorMessage();
//                     }
//                     break;
//             }
//         }
//         else
//         {
//             ErrorMessage();
//         }
//         Console.ReadKey();
//     }
// }
// private static void ErrorMessage()
// {
//     Console.WriteLine("Typing error, press key to continue.");
// }
// private static void DrawStarLine()
// {
//     Console.WriteLine("************************");
// }
// private static void DrawTitle()
// {
//     DrawStarLine();
//     Console.WriteLine("+++   MYTITLE HERE   +++");
//     DrawStarLine();
// }
// private static void DrawMenu(int maxitems)
// {
//     DrawStarLine();
//     Console.WriteLine(" 1. MenuItem One");
//     Console.WriteLine(" 2. MenuItem Two");
//     // more here
//     Console.WriteLine(" 3. Exit program");
//     DrawStarLine();
//     Console.WriteLine("Make your choice: type 1, 2,... or {0} for exit", maxitems);
//     DrawStarLine();
// }