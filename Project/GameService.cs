using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
    public class GameService : IGameService
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput(string input)
        {
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
                    CurrentRoom = CurrentRoom.RoomChange(option);
                    break;
                case "look":
                this.Look();
                    break;
                case "inv" || "inventory":
                this.Inventory(input);
                    break;
                case "look":
                .Sign(input);
                    break;
                case "look":
                .Sign(input);
                    break;
                case "look":
                .Sign(input);
                    break;
            }
        }

        public void Go(string direction)
        {
            switch (direction)
            {
                case "north":
                    CurrentRoom = CurrentRoom.RoomChange("north");
                    break;
                case "south":
                    CurrentRoom = CurrentRoom.RoomChange("south");
                    break;
                case "east":
                    CurrentRoom = CurrentRoom.RoomChange("east");
                    break;
                case "west":
                    CurrentRoom = CurrentRoom.RoomChange("west");
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
            if (CurrentPlayer.Inventory.Count > 0)
            {
                return CurrentPlayer.Inventory.ForEach(i => i.Name);///////////////////////////////////////////////////////////
            }
        }

        public void Look()
        {
            Console.Clear();
            Console.Write(CurrentRoom.Description);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Reset()
        { }

        public void Setup()
        {
            Item sword = new Item("Sword of Grindlwald", "This sword has a cheesy nametag. I guess its time to use all that jedi tranning you did as a kid?");
            Item gun = new Item("Colt M1911", "This pistol looks absolutely stunning!!! Your move...");

            Room courtyard = new Room("The Mystery Begins", "There are lots of bushes cut to resemble someone's face. You see a massive door to the north,  and if you look really hard you think you might see a small door to the east. But its a little hard to see with the bushes in your way. You appear to be in a courtyard,   Why are you in a court yard?");
            Room easternDoor = new Room("The Eastern Door", "You make it to the far east and find there is a door, only, its not small at all. Its 12 feet high. making your way in you find a chest with Pistol in it. There is a door to the north.");
            Room entryWay = new Room("The Great Hall", "You enter in the the massive door to find a terribly HUGE hallway. You begin to question, am i dead? is this Valhalla. You begin to slowly wander down the hall, turning and looking at everything. There gold everywhere, massive pillars of them. There is an exit to the north.");
            Room entryWayF = new Room("The Great Hall", "You go through the door and find you are in the room behind the massive door you saw before. And its even bigger than you prieviously thought. You begin to question, am i dead? is this Valhalla. You begin to slowly wander down the hall, turning and looking at everything. There gold everywhere, massive pillars of them. There is an exit to the north.");
            Room bossRoom = new Room("Throne Room", "You enter what you now realize is the throne room. on the throne you see an old man with a spear. The old man takes notice and stands up. 'Do you dare defy Odin Himself? In his own Throne Room!?' \r ");
            Room entryWayE = new Room("The Great Hall", "You find the shimmer was a gold sword. take it?");
            Room dead = new Room("You are dead", "You didn't far well with the Sword");
        }

        public void StartGame()
        {

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
            string WelcomeInfo = @"Welcome to Mystery. A game in which you know nothing about. Please Press enter when ready.";

            while (true)
            {
                Console.Clear();
                if (firstStart)
                {

                    for (int i = 0; i < TitleScreen.Length; i++)
                    {
                        Console.Write(TitleScreen[i]);
                        Thread.Sleep(28);
                    }

                }
                else
                {
                    Console.Write(TitleScreen);
                }
                Console.WriteLine();


                if (firstStart)
                {

                    for (int i = 0; i < WelcomeInfo.Length; i++)
                    {
                        Console.Write(WelcomeInfo[i]);
                        Thread.Sleep(28);
                    }

                }
                else
                {
                    Console.Write(WelcomeInfo);
                }
                Console.WriteLine();

                CastleGrimtol.Project.Models.Menu.Select();
                firstStart = false;
            }

        }

        public string TakeItem(string itemName)
        {
            for (int i = 0; i < CurrentRoom.Items.Count; i++)
            {
                if (CurrentRoom.Items[i].ToString() == itemName)
                {
                    Console.WriteLine("CurrentPlayer.addInventory(CurrentRoom.Items[i])");
                    return "done";
                }
            }
            return "done";

        }

        public void UseItem(string itemName)
        {
            if (CurrentRoom.Name == "Throne Room")
            {
                if (itemName == "Sword of Grindlwald")
                {
                    CurrentRoom = CurrentRoom.RoomChange("dead");
                }
                else
                {
                    CurrentRoom.RoomChange("north");
                }
            }
            else
            {
                Console.WriteLine("You Can't Use That Here!!!");
            }

            Thread.Sleep(1500);
        }
    }
}