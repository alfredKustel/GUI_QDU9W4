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
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Chef")
            {
                Console.Write("Enter Chef's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Chef one = rest.Get<Chef>(id, "chefs");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "chef");
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
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53910/", "movie");

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


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Restaurants", () => RestaurantSubMenu.Show())
                .Add("Chefs", () => chefSubMenu.Show())
                .Add("Receipts", () => ReceiptSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
