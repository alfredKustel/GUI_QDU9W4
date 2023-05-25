using EDVC1J_HFT_2022232.Models;
using System;
using System.Threading;

namespace EDVC1J_HFT_2022232.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000);

            RestService restService = new RestService("http://localhost:5967");
            var recipes = restService.Get<Receipt>("receipt");
            var chefs = restService.Get<Chef>("chef");
            var restaurants = restService.Get<Restaurant>("restaurant");
            var q1 = restService.Get<Receipt>("stat/PeepReceipts");
            var q2 = restService.Get<Chef>("stat/HeadChefOfPeep");
            var q3 = restService.Get<Receipt>("stat/FrancoDeMilanReceipts");
            var q4 = restService.Get<Chef>("stat/FreshChefsFromPinoccio");
            var q5 = restService.Get<Chef>("stat/SushiSeiChefs");

            Console.WriteLine("Menu options: ");
            Console.WriteLine("1 - Recepies");
            Console.WriteLine("2 - Chefs");
            Console.WriteLine("3 - Restaurants");
            Console.WriteLine("4 - NonC-Methods");
            Console.WriteLine("5 - C-Method");
            Console.WriteLine("0 - Exit");

            Console.WriteLine("Make your choice: ");
            int menuchoice;
            do
            {
                menuchoice = int.Parse(Console.ReadLine());

                switch (menuchoice)
                {

                    case 1:
                        Console.Clear();
                        foreach (var recipe in recipes)
                        {
                            Console.WriteLine(recipe.Name);
                        }

                        break;
                    case 2:
                        Console.Clear();
                        foreach (var chef in chefs)
                        {
                            Console.WriteLine(chef.Name);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        foreach (var restaurant in restaurants)
                        {
                            Console.WriteLine(restaurant.Name);
                        }
                        break;
                    default:
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Pipi recepies: ");
                        foreach (var result in q1)
                        {
                            Console.WriteLine(result.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pipi headchef: ");
                        foreach (var result in q2)
                        {
                            Console.WriteLine(result.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Franko de Milan recepies: ");
                        foreach (var result in q3)
                        {
                            Console.WriteLine(result.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pinoccio jungest:");
                        foreach (var result in q4)
                        {
                            Console.WriteLine(result.Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Chefs in Sushi Sei: ");
                        foreach (var result in q5)
                        {
                            Console.WriteLine(result.Name);
                        }
                        break;
                    case 5:
                        Console.Clear();
                        restService.Post(new Restaurant()
                        {
                            Name = "Hamburger",
                        }, "restaurant");
                        Console.WriteLine("Restaurant posted");
                        break;
                }
            } while (menuchoice != 0);
        }
    }
}
