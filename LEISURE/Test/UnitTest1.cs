using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core.ado;
using Core.Classes_Core;


namespace Test 
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
