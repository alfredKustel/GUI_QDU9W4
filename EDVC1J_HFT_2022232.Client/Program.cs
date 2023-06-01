using ConsoleTools;
using EDVC1J_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EDVC1J_HFT_2022232.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Chef")
            {
                Console.Write("Enter Chef Name: ");
                string name = Console.ReadLine();
                rest.Post(new Chef() { Name = name }, "chef");
            }
            if (entity == "Receipt")
            {
                Console.Write("Enter Receipt Name: ");
                string name = Console.ReadLine();
                rest.Post(new Receipt() { Name = name }, "receipt");
            }
            if (entity == "Restaurant")
            {
                Console.Write("Enter Restaurant Name: ");
                string name = Console.ReadLine();
                rest.Post(new Restaurant() { Name = name }, "restaurant");
            }
        }
        static void List(string entity)
        {
            if (entity == "Chef")
            {
                List<Chef> chefs = rest.Get<Chef>("chef");
                foreach (var item in chefs)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            
            if (entity == "Receipt")
            {
                List<Receipt> receipts = rest.Get<Receipt>("receipt");
                foreach (var item in receipts)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "Restaurant")
            {
                List<Restaurant> restaurants = rest.Get<Restaurant>("restaurant");
                foreach (var item in restaurants)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "SushiSeiChefs")
            {
                List<Chef> chefs = rest.Get<Chef>("stat/SushiSeiChefs");
                foreach (var item in chefs)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "FreshChefsFromPinoccio")
            {
                List<Chef> chefs = rest.Get<Chef>("stat/FreshChefsFromPinoccio");
                foreach (var item in chefs)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "FrancoDeMilanReceipts")
            {
                List<Receipt> receipts = rest.Get<Receipt>("stat/FrancoDeMilanReceipts");
                foreach (var item in receipts)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "PeepReceipts")
            {
                List<Receipt> receipts = rest.Get<Receipt>("stat/PeepReceipts");
                foreach (var item in receipts)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }
            if (entity == "HeadChefOfPeep")
            {
                List<Chef> receipts = rest.Get<Chef>("stat/HeadChefOfPeep");
                foreach (var item in receipts)
                {
                    Console.WriteLine(item.ID + ": " + item.Name);
                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Chef")
            {
                Console.Write("Enter Chef's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Chef one = rest.Get<Chef>(id, "chef");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "chef");
            }
            if (entity == "Receipt")
            {
                Console.Write("Enter Receipt's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Receipt one = rest.Get<Receipt>(id, "receipt");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "receipt");
            }
            if (entity == "Restaurant")
            {
                Console.Write("Enter Restaurant's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Restaurant one = rest.Get<Restaurant>(id, "restaurant");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "restaurant");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Chef")
            {
                Console.Write("Enter Chef's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "chef");
            }
            if (entity == "Receipt")
            {
                Console.Write("Enter Receipt's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "receipt");
            }
            if (entity == "Restaurant")
            {
                Console.Write("Enter Restaurant's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "restaurant");
            }
        }

        //static void Stat(string entity)
        //{

        //    if (entity == "SushiSeiChefs")
        //    {
        //        List<Chef> chefs = rest.Get<Chef>("stat/SushiSeiChefs");
        //        foreach (var item in chefs)
        //        {
        //            Console.WriteLine(item.ID + ": " + item.Name);
        //        }
        //    }
        //    if (entity == "FreshChefsFromPinoccio")
        //    {
        //       List<Chef> chefs2=  rest.Get<Chef>("stat/FreshChefsFromPinoccio");
        //        foreach (var item in chefs2)
        //        {
        //            Console.WriteLine(item.Name);
        //        }

        //    }
        //    if (entity == "FrancoDeMilanReceipts")
        //    {
        //        List<Receipt> receipt = rest.Get<Receipt>("stat/FrancoDeMilanReceipts");
        //        foreach (var item in receipt)
        //        {
        //            Console.WriteLine(item.Name);
        //        }

        //    }
        //    if (entity == "PeepReceipts")
        //    {
        //        List<Receipt> receipt2 = rest.Get<Receipt>("stat/PeepReceipts");
        //        foreach (var item in receipt2)
        //        {
        //            Console.WriteLine(item.Name);
        //        }

        //    }
        //    if (entity == "HeadChefOfPeep")
        //    {
        //        List<Chef> chefs3 = rest.Get<Chef>("stat/HeadChefOfPeep");
        //        foreach (var item in chefs3)
        //        {
        //            Console.WriteLine(item.Name);
        //        }

        //    }

        //}


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:49326/", "restaurant");

            var chefSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Chef"))
                .Add("Create", () => Create("Chef"))
                .Add("Delete", () => Delete("Chef"))
                .Add("Update", () => Update("Chef"))
                .Add("Exit", ConsoleMenu.Close);

            var ReceiptSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Receipt"))
                .Add("Create", () => Create("Receipt"))
                .Add("Delete", () => Delete("Receipt"))
                .Add("Update", () => Update("Receipt"))
                .Add("Exit", ConsoleMenu.Close);

            var RestaurantSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Restaurant"))
                .Add("Create", () => Create("Restaurant"))
                .Add("Delete", () => Delete("Restaurant"))
                .Add("Update", () => Update("Restaurant"))
                .Add("Exit", ConsoleMenu.Close);

            var NonCRUDSubMenu = new ConsoleMenu(args, level: 1)
                .Add("SushiSeiChefs", () => List("SushiSeiChefs"))
                .Add("FreshChefsFromPinoccio", () => List("FreshChefsFromPinoccio"))
                .Add("PeepReceipts", () => List("PeepReceipts"))
                .Add("HeadChefOfPeep", () => List("HeadChefOfPeep"))
                .Add("FrancoDeMilanReceipts", () => List("FrancoDeMilanReceipts"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Chefs", () => chefSubMenu.Show())
                .Add("Receipts", () => ReceiptSubMenu.Show())
                .Add("Restaurants", () => RestaurantSubMenu.Show())
                .Add("nonCRUD Methods", () => NonCRUDSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
