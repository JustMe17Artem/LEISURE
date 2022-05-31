using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core.ado;
using Core.Classes_Core;


namespace Test 
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GettingPlaceTest()
        {
            Place expectedPlace = new Place
            {
                Id = 1,
                Name = "каток",
                Adress = "адрес"
            };
            Place actualPlace = DataAccess.GetPlace(1);
            Assert.AreEqual(expectedPlace.Id, actualPlace.Id);
            Assert.AreEqual(expectedPlace.Name, actualPlace.Name);
        }

        [TestMethod]
        public void GettingUserTest()
        {
            User expectedUser = new User
            {
                Id = 3,
                Login = "artem1",
                Password = "qwerty123!"
            };
            User actualUser = DataAccess.GetUser("artem1", "qwerty123!");
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
            Assert.AreEqual(expectedUser.Login, actualUser.Login);
        }
    }
}
