using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
    public class GameService : IGameService
    {
        public GameService(Player currentPlayer)
        {
            this.CurrentPlayer = currentPlayer;
        }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {
            do
            {
                string upperInput = Console.ReadLine();
                string input = upperInput.ToLower();
                string[] inputs = input.Split(' ');
                string command = inputs[0];
                string option = "";
                if (inputs.Length > 1)
                {
                    option = inputs[1];
                }
                switch (command)
                {
                    case "go":
                        this.Go(option);
                        break;
                    case "look":
                        this.Look();
                        break;
                    case "inv":
                        this.Inventory();
                        break;
                    case "inventory":
                        this.Inventory();
                        break;
                    case "help":
                        this.Help();
                        break;
                    case "quit":
                        this.Quit();
                        break;
                    case "exit":
                        this.Quit();
                        break;
                    case "take":
                        this.TakeItem(option);
                        break;
                    case "use":
                        this.UseItem(option);
                        break;
                    default:
                        Console.Clear();
                        Console.Write("invalid Command");
                        break;
                }

            } while (true);
        }

        public void Go(string direction)
        {
            switch (direction)
            {
                case "north":
                    CurrentRoom = CurrentRoom.RoomChange("north");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                case "south":
                    CurrentRoom = CurrentRoom.RoomChange("south");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                case "east":
                    CurrentRoom = CurrentRoom.RoomChange("east");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                case "west":
                    CurrentRoom = CurrentRoom.RoomChange("west");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                case "dead":
                    CurrentRoom = CurrentRoom.RoomChange("dead");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                case "winnerwinnerchickendinner":
                    CurrentRoom = CurrentRoom.RoomChange("winnerWinnerChickenDinner");
                    Console.Clear();
                    CurrentRoom.Print();
                    break;
                    default: 
                    Console.Clear();
                    Console.Write("FUUUCK THIS GO METHODS");
                    Thread.Sleep(7000);
                    break;

            }
        }

        public void Help()
        {
            Console.Clear();
            Console.Write(@"Options avaibible are as follows: 
            inventory:,
            look:,
            quit:,
            take: [item]
            ");
            Thread.Sleep(3000);
            Look();
        }

        public void Inventory()
        {
            CurrentPlayer.PrintInv();
        }

        public void Look()
        {
            Console.Clear();
            CurrentRoom.Print();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Reset()
        {
            Setup();
            StartGame();
        }

        public void Setup()
        {
            Item sword = new Item("Sword", "This sword has a cheesy nametag, 'Sword of Grindlwald'. I guess its time to use all that jedi tranning you did as a kid?");

            Item gun = new Item("Pistol", "This pistol looks absolutely stunning, it's a Colt M1911!!! Your move...");

            Room courtyard = new Room("The Mystery Begins", "There are lots of bushes cut to resemble someone's face. You see a massive door to the north,  and if you look really hard you think you might see a small door to the east. But its a little hard to see with the bushes in your way. You appear to be in a courtyard,   Why are you in a court yard?");

            Room courtyardD = new Room("The Mystery Begins", "There are lots of bushes cut to resemble someone's face. You see a massive door to the north,  and if you look really hard you think you might see a small door to the east. But its a little hard to see with the bushes in your way. You appear to be in a courtyard,   Why are you in a court yard?");

            Room easternDoor = new Room("The Eastern Door", "You make it to the far east and find there is a door, only, its not small at all. Its 12 feet high. making your way in you find a chest with Pistol in it. There is a door to the north, and another to the east.");
            Room easternDoorF = new Room("The Eastern Door", "You enter a small room with a large extirior door. there is a chest on the floor with a pistol in it. and door to the west, and a door to the east.");

            Room easternDoorD = new Room("The Eastern Door", "You are back in the Eastern Room. the chest is still there. There is a door to the north, and another to the east.");

            Room entryWay = new Room("The Great Hall", "You enter in the the massive door to find a terribly HUGE hallway. You begin to question, am i dead? is this Valhalla. You begin to slowly wander down the hall, turning and looking at everything. There's gold everywhere, massive pillars of them. There is an exit to the north and east, and to the west a shimmering object.");

            Room entryWayF = new Room("The Great Hall", "You go through the door and find you are in the room behind the massive door you saw before. And its even bigger than you prieviously thought. You begin to question, am i dead? is this Valhalla. You begin to slowly wander down the hall, turning and looking at everything. There's gold everywhere, massive pillars of them. There is an exit to the north and east, and to the west a shimmering object.");

            Room bossRoom = new Room("Throne Room", "You enter what you now realize is the throne room. on the throne you see an old man with a spear. The old man takes notice and stands up. 'Do you dare defy Odin Himself? In his own Throne Room!?' There is the exit you came in to the south.");

            Room entryWayE = new Room("The Great Hall", "You find the shimmer was in fact a gold sword. take it?");

            Room entryWayD = new Room("The Great Hall", "You are now back in the same entry hall as before. You begin to slowly wander down the hall, turning and looking at everything. There's gold everywhere, massive pillars of them. There is an exit to the north and east, is where the shimmering onject was.");


            Room bossRoomD = new Room("Throne Room", "You enter what you now dread. The Throne Room. You stand there as Odin taunts you. There is the exit you came in to the south.");


            Room dead = new Room("You are dead", "You didn't far well with the Sword");

            Room winnerWinnerChickenDinner = new Room("Victory", "You have destroyed the god of thunder. You have won!!!         .... for the love of all that is good, dont break my game, please type victory to end the game.");


            courtyard.addRooms(entryWay, "north");
            courtyard.addRooms(easternDoor, "east");

            easternDoor.addRooms(entryWayF, "north");
            easternDoor.addRooms(courtyardD, "west");

            entryWay.addRooms(entryWayE, "west");
            entryWay.addRooms(bossRoom, "north");
            entryWay.addRooms(easternDoorF, "east");
            entryWay.addRooms(courtyardD, "south");

            entryWayF.addRooms(entryWayE, "west");
            entryWayF.addRooms(bossRoom, "north");
            entryWayF.addRooms(courtyardD, "south");
            entryWayF.addRooms(easternDoorD, "east");

            entryWayE.addRooms(bossRoom, "north");
            entryWayE.addRooms(easternDoor, "east");
            entryWayE.addRooms(courtyardD, "south");

            entryWayD.addRooms(bossRoom, "north");
            entryWayD.addRooms(easternDoor, "east");
            entryWayD.addRooms(courtyardD, "south");

            bossRoom.addRooms(entryWayD, "south");

            courtyard.addRooms(dead, "dead");
            easternDoor.addRooms(dead, "dead");
            entryWay.addRooms(dead, "dead");
            entryWayE.addRooms(dead, "dead");
            entryWayF.addRooms(dead, "dead");
            bossRoom.addRooms(dead, "dead");

            bossRoom.addRooms(winnerWinnerChickenDinner, "winnerWinnerChickenDinner");

            easternDoor.addItems(gun);
            easternDoorD.addItems(gun);
            easternDoorF.addItems(gun);

            entryWayE.addItems(sword);

            //TODO add exits to all the rooms
            // TODO assign the CurrentRoom property equal to an instance of a room
            CurrentRoom = courtyard;
        }

        public void StartGame()
        {
            bool inTitle = true;
            bool firstStart = true;
            string TitleScreen = $@"
  /\\,/\\,                ,
 /| || ||                ||
 || || ||  '\\/\\  _-_, =||=  _-_  ,._-_ '\\/\\
 ||=|= ||   || ;' ||_.   ||  || \\  ||    || ;'
~|| || ||   ||/    ~ ||  ||  ||/    ||    ||/
 |, \\,\\,  |/    ,-_-   \\, \\,/   \\,   |/
_-         (                             (
            -_-                           -_-
               ";
            string WelcomeInfo = @"Welcome to Mystery. A game in which you know nothing about. Press any key to start game.";

            while (inTitle)
            {
                Console.Clear();
                if (firstStart)
                {

                    for (int i = 0; i < TitleScreen.Length; i++)
                    {
                        Console.Write(TitleScreen[i]);
                        Thread.Sleep(28);
                    }

                    Console.WriteLine();



                    for (int i = 0; i < WelcomeInfo.Length; i++)
                    {
                        Console.Write(WelcomeInfo[i]);
                        Thread.Sleep(28);
                    }


                    Console.WriteLine();
                    Console.ReadKey();
                    Setup();
                }
                CurrentRoom.Print();
                GetUserInput();

                firstStart = false;
            }

        }

        public void TakeItem(string itemName)
        {
            Console.Clear();
            string line1 = $"taking {itemName}";
            for (int i = 0; i < line1.Length; i++)
            {
                Console.Write(line1[i]);
                Thread.Sleep(40);
            }
            Thread.Sleep(1000);
            if (CurrentRoom.Items.Count > 0)
            {
                Item test = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
                bool found = CurrentRoom.Items.Contains(test);
                // Console.Write(found);
                Console.WriteLine();
                Thread.Sleep(3000);


                if (found)
                {
                    CurrentPlayer.addInventory(test);
                    // Console.Write("Took it");
                    // Thread.Sleep(2000);
                    this.Look();

                }
                else
                {
                    Console.Clear();
                    string line = "No items found with that name???";
                    for (int i = 0; i < line.Length; i++)
                    {
                        Console.Write(line[i]);
                        Thread.Sleep(30);
                    }
                    Thread.Sleep(2000);
                    this.Look();
                }
            }
            else
            {
                Console.Clear();
                string line = "No items in room.";
                for (int i = 0; i < line.Length; i++)
                {
                    Console.Write(line[i]);
                    Thread.Sleep(30);
                }
                this.Look();
            }


        }

        public void UseItem(string itemName)
        {
            if (CurrentRoom.Name == "Throne Room" && itemName == "sword")
            {
                if (itemName == "sword")
                {
                    this.Go("dead");
                    Console.Write("YEETOUS go dead");
                    Thread.Sleep(7000);
                }
                else
                {
                    Console.Write("YEETOUS go dead wrong");
                    Thread.Sleep(7000);
                    throw new Exception("Your not dead......?");
                }
            }
            else if (CurrentRoom.Name == "Throne Room" && itemName == "pistol")
            {
                if (itemName == "pistol")
                {
                    this.Go("winnerWinnerChickenDinner");
                    Console.Write("YEETOUS win shit");
                    Console.Write(CurrentRoom.Name);
                    Thread.Sleep(7000);
                }
                else
                {
                    Console.Write("YEETOUS win shit wrong");
                    Thread.Sleep(7000);
                    throw new Exception("Your not dead......?");
                }
            }
            else
            {
                Console.WriteLine("You Can't Use That Here!!!");
                Thread.Sleep(7000);
            }

            Thread.Sleep(1500);
            Thread.Sleep(7000);
        }

        // TODO create a constructor function and within the code block of the constructor invoke the Setup method
    }
}