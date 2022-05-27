using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.ado;
using Core.Classes_Core;
using System.Transactions;

namespace LeisureTest
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
            Assert.AreEqual(expectedPlace, actualPlace);
        }
    }
}
