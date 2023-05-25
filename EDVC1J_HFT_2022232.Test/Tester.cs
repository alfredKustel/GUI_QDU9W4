using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using EDVC1J_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EDVC1J_HFT_2022232.Test
{
    [TestFixture]
    public class Tester
    {
        private static ChefLogic chefLogic;
        private static ReceiptLogic receiptLogic;
        private static RestaurantLogic restaurantLogic;

        private static List<Chef> chefList;
        private static List<Receipt> receiptList;
        private static List<Restaurant> restaurantList;

        private static Mock<IChefRepository> chefMock;
        private static Mock<IReceiptRepository> receiptMock;
        private static Mock<IRestaurantRepository> restaurantMock;
    }
}
