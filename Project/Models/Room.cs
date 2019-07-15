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
                    return this;
                case "south":
                    if (Exits["South"] != null) return Exits["South"];
                    return this;
                case "west":
                    if (Exits["West"] != null) return Exits["West"];
                    return this;
                case "east":
                    if (Exits["East"] != null) return Exits["East"];
                    return this;
                default:
                    return Exits["Dead"];

            }
        }


        public void addRooms(Room addThis, string type)
        {
            switch (type)
            {
                case "north":
                    Exits["North"] = addThis






;
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
                if (spaceCount == 5)
                {
                    Console.WriteLine();
                    spaceCount = 0;
                }
                Console.Write(this.Description[i]);
                Thread.Sleep(100);
            }
        }



    }
}