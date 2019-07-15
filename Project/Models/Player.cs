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

        }
        public string PlayerName { get; set; }
        public List<Item> Inventory { get; set; }





        public string addInventory(Item item)
        {
            if (!this.Inventory.Contains(item))
            {

                this.Inventory.Add(item);
                return "Item added to inventory";
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
            Console.Clear();
          for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine(Inventory[i].ToString());
                Thread.Sleep(3);
            }

        }






    }
}