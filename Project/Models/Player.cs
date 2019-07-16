using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
    public class Player : IPlayer
    {
        public Player(string playerName)
        {
            this.PlayerName = playerName;
            this.Inventory = new List<Item>() { };
        }
        public string PlayerName { get; set; }
        public List<Item> Inventory { get; set; }





        public string addInventory(Item item)
        {
            // Console.WriteLine($" item name {item.Name}");
            // Console.Write(this.Inventory.Contains(item));
            if (!this.Inventory.Contains(item))
            {

                this.Inventory.Add(item);
                string line1 = "Item added to inventory";
                for (int i = 0; i < line1.Length; i++)
                {
                    Console.Write(line1[i]);
                    Thread.Sleep(30);
                }
                return "Item added to inventory";
            }
            string line = "Item exist in current inventory";
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(30);
            }
            return "Item exist in current inventory";
        }
        public string removeInventory(Item item)
        {
            if (this.Inventory.Contains(item))
            {

                this.Inventory.Add(item);
                return "Item destroyed";
            }
            return "much error";
        }

        public void PrintInv()
        {
            if (this.Inventory != null)
            {

                Console.Clear();
                for (int i = 0; i < this.Inventory.Count; i++)
                {
                    Console.WriteLine(Inventory[i].ToString());
                    Thread.Sleep(3);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                string line = "Nothing to show here";
                Console.Clear();
                for (int i = 0; i < line.Length; i++)
                {
                    Console.Write(line[i]);
                    Thread.Sleep(3);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }






    }
}