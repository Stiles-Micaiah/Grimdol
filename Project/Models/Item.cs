using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Item : IItem
    {

        public Item(string name, string description)
        {
            this.Name = name;
            this.Description = description;

        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}