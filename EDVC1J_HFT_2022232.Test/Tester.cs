using EDVC1J_HFT_2022232.Logic;
using EDVC1J_HFT_2022232.Models;
using EDVC1J_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [SetUp]

        public static void SetUp()
        {
            chefMock = new Mock<IChefRepository>();
            receiptMock = new Mock<IReceiptRepository>();
            restaurantMock = new Mock<IRestaurantRepository>();

            restaurantList = new List<Restaurant>
            {
                new Restaurant() { ID = 1, Name = "Sushi Sei", WorkingChefs = chefList, Menu = receiptList},
                new Restaurant() { ID = 2, Name = "Pinoccio", WorkingChefs = chefList, Menu = receiptList},
                new Restaurant() { ID = 3, Name = "Pesti Pipi", WorkingChefs = chefList, Menu = receiptList}
            };
            chefList = new List<Chef>
            {
                new Chef() { ID = 1, Name = "FTakumi Aldini", Age = 20, RestaurantID = restaurantList[0].ID, Restaurant = restaurantList[0], Specialities = receiptList},
                new Chef() { ID = 2, Name = "Franco de Milan", Age = 19, RestaurantID = restaurantList[0].ID, Restaurant = restaurantList[0], Specialities = receiptList},
                new Chef() { ID = 3, Name = "Yukihira Soma", Age = 21, RestaurantID = restaurantList[0].ID, Restaurant = restaurantList[0], Specialities = receiptList},
                new Chef() { ID = 4, Name = "Németh Krisztián", Age = 25, RestaurantID = restaurantList[2].ID, Restaurant = restaurantList[2], Specialities = receiptList},
                new Chef() { ID = 5, Name = "Super Mario", Age = 20, RestaurantID = restaurantList[1].ID, Restaurant = restaurantList[1], Specialities = receiptList}
            };

            receiptList = new List<Receipt>
            {
                new Receipt() { ID = 1, Name = "Carbonara", Price = 1400, ChefID = chefList[0].ID, RestaurantID = restaurantList[0].ID, Restaurant = restaurantList[0], Chef = chefList[0]},
                new Receipt() { ID = 2, Name = "Aljas Pipi", Price = 1590, ChefID = chefList[3].ID, RestaurantID = restaurantList[2].ID, Restaurant = restaurantList[2], Chef = chefList[3] },
                new Receipt() { ID = 3, Name = "SunEater Burger", Price = 4000, ChefID = chefList[3].ID, RestaurantID = restaurantList[2].ID, Restaurant = restaurantList[2], Chef = chefList[3]}
            };

            restaurantMock.Setup(restSetup => restSetup.GetAll()).Returns(restaurantList.AsQueryable());
            chefMock.Setup(chefSetup => chefSetup.GetAll()).Returns(chefList.AsQueryable());
            receiptMock.Setup(receiptSetup => receiptSetup.GetAll()).Returns(receiptList.AsQueryable());

            restaurantLogic = new RestaurantLogic(restaurantMock.Object);
            chefLogic = new ChefLogic(chefMock.Object);
            receiptLogic = new ReceiptLogic(receiptMock.Object);
        }
        //getAll
        [Test]
        public static void ChefGetAllTest()
        {
            //Arrange
            List<Chef> expresults = chefList;

            //Act
            var res = chefLogic.GetAll();

            //Assert
            Assert.That(res.Count, Is.EqualTo(expresults.Count));
            Assert.That(res, Is.EquivalentTo(expresults));
            chefMock.Verify(repository => repository.GetAll(), Times.Once);
            chefMock.Verify(repository => repository.Read(It.IsAny<int>()), Times.Never);
        }
        [Test]
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(4)]
        public static void ChefReadTest(int id)
        {
            //Arrange
            chefMock.Setup(repository => repository.Read(It.Is<int>(id => id >= 0 && id < chefList.Count)))
                    .Returns(chefList[id]);

            //Act
            var res = chefLogic.Read(id);

            //Assert
            Assert.That(res, Is.EqualTo(chefList[id]));
            chefMock.Verify(x => x.Read(id), Times.Exactly(1));
        }
        [Test]
        public static void ReceiptAdderTest()
        {
            Receipt newReceipt = new Receipt { ID = 4, Name = "Sushi roll", Price = 2000, ChefID = chefList[2].ID, RestaurantID = restaurantList[0].ID };

            //Arrange
            receiptMock.Setup(repository => repository.Create(newReceipt));

            //Act
            receiptLogic.Create(newReceipt);

            //Assert
            receiptMock.Verify(repository => repository.Create(newReceipt));
            receiptMock.Verify(repository => repository.Create(newReceipt), Times.Once);
        }
        [Test]
        public static void ChefAdderTest()
        {
            Chef newchef = new Chef { ID = 6, Name = "Nakiri Irina", Age = 21, RestaurantID = restaurantList[0].ID };

            //Arrange
            chefMock.Setup(repository => repository.Create(newchef));

            //Act
            chefLogic.Create(newchef);

            //Assert
            chefMock.Verify(repository => repository.Create(newchef));
            chefMock.Verify(repository => repository.Create(newchef), Times.Once);
        }
    }
}
