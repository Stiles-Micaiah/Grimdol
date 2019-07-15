using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Room : IRoom
    {

        public Room(string name, string description, List<Item> items = null, Dictionary<string, Room> exits = null)
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
        public Room North { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }
        public Room East { get; set; }
        public Room Dead { get; set; }


        public Room RoomChange(string dir)
        {
            switch (dir)
            {
                case "north":
                    if (North != null) return North;
                    return this;
                case "south":
                    if (South != null) return South;
                    return this;
                case "west":
                    if (West != null) return West;
                    return this;
                case "east":
                    if (East != null) return East;
                    return this;
                default:
                    return Dead;

            }
        }



    }
}