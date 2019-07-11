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

        public void GetUserInput()
        {
            throw new System.NotImplementedException();
        }

        public void Go(string direction)
        {
            switch (direction)
            {
                case "forward":
                    CurrentRoom = CurrentRoom.RoomChange("forward");
                    break;
                case "aft":
                    CurrentRoom = CurrentRoom.RoomChange("aft");
                    break;
                case "port":
                    CurrentRoom = CurrentRoom.RoomChange("port");
                    break;
                case "starboard":
                    CurrentRoom = CurrentRoom.RoomChange("starboard");
                    break;

            }
        }

        public void Help()
        {
            throw new System.NotImplementedException();
        }

        public void Inventory()
        {
            throw new System.NotImplementedException();
        }

        public void Look()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void Reset()
        {
           List<Item> shit = new List<Item>(){
              new Item("name", "yeet"),
              new Item("name1", "yeet"),
              new Item("name2", "yeet")
            };
           Dictionary<string, Room> exitshit = new Dictionary<string, Room>(){
              new Room("upstairs", "you shit yourself"),
              new Room("upstairs", "you shit yourself", shit, exitshit),
              new Room("upstairs", "you shit yourself", shit, exitshit)
            };


Room shit = new Room("upstairs", "you shit yourself", shit, exitshit)        }

        public void Setup()
        {
            throw new System.NotImplementedException();
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
            string WelcomeInfo = @"Welcome to Mystery. A game in which you know nothing about.
To get started just press /start/. For information on how to
play, just press /I'm retarded/ :) ";

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

        public void TakeItem(string itemName)
        {
            for (int i = 0; i < CurrentRoom.Items.Count; i++)
            {
                if (CurrentRoom.Items[i].ToString() == itemName)
                {
                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                }
            }
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}