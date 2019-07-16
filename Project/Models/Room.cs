using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {

        public Room(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Items = new List<Item>() { };
            this.Exits = new Dictionary<string, Room>();
            Exits.Add("North", null);
            Exits.Add("South", null);
            Exits.Add("East", null);
            Exits.Add("West", null);
            Exits.Add("Dead", null);
            Exits.Add("WinnerWinnerChicken", null);
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        // public Room North { get; set; }
        // public Room South { get; set; }
        // public Room West { get; set; }
        // public Room East { get; set; }
        // public Room Dead { get; set; }


        public Room RoomChange(string dir)
        {
            switch (dir)
            {
                case "north":
                    if (Exits["North"] != null) return Exits["North"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                case "south":
                    if (Exits["South"] != null) return Exits["South"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                case "west":
                    if (Exits["West"] != null) return Exits["West"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                case "east":
                    if (Exits["East"] != null) return Exits["East"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                case "winnerwinnerchickendinnr":
                    if (Exits["WinnerWinnerChickenDinnr"] != null) return Exits["WinnerWinnerChickenDinnr"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                case "dead":
                    if (Exits["Dead"] != null) return Exits["Dead"];
                    Console.WriteLine("No exits of that direction in this room.");
                    Thread.Sleep(5000);
                    this.Print();
                    return this;
                default:
                    this.Print();
                    Console.Write("Invalid, type 'help' to see accepted commands");
                    Thread.Sleep(5000);
                    return this;
            }
        }


        public void addRooms(Room addThis, string type)
        {
            switch (type)
            {
                case "north":
                    Exits["North"] = addThis;
                    break;
                case "south":
                    Exits["South"] = addThis;
                    break;
                case "west":
                    Exits["West"] = addThis;
                    break;
                case "east":
                    Exits["East"] = addThis;
                    break;
                case "dead":
                    Exits["Dead"] = addThis;
                    break;
                case "winnerWinnerChickenDinner":
                    Exits["WinnerWinnerChickenDinnr"] = addThis;
                    break;
                default:
                    throw new System.ArgumentException("Incorrect String Value", "type");
            }
        }


        public void addItems(Item addThis)
        {

            this.Items.Add(addThis);

        }

        public void Print()
        {
            Console.Clear();
            int spaceCount = 0;
            for (int i = 0; i < this.Description.Length; i++)
            {
                if (this.Description[i] == ' ')
                {
                    spaceCount++;
                }
                if (spaceCount == 7)
                {
                    Console.WriteLine();
                    spaceCount = 0;
                }
                Console.Write(this.Description[i]);
                Thread.Sleep(30);
            }
        }



    }
}