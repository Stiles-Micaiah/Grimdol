using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {

        public Room(string name, string description, List<Item> items, Dictionary<string, Room> exits)
        {
            this.Name = name;
            this.Description = description;
            this.Items = items;
            this.Exits = exits;

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        public Room Forward { get; set; }
        public Room Aft { get; set; }
        public Room Port { get; set; }
        public Room Starboard { get; set; }
        public Room Ded { get; set; }


        public Room RoomChange(string dir)
        {
            switch (dir)
            {
                case "forward":
                    if (Forward != null) return Forward;
                    return this;
                case "aft":
                    if (Aft != null) return Aft;
                    return this;
                case "port":
                    if (Port != null) return Port;
                    return this;
                case "starboard":
                    if (Starboard != null) return Starboard;
                    return this;
                default:
                    return Ded;

            }
        }
    }
}