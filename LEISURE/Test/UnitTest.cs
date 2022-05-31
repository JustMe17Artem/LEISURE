using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Core.ado;
using Core.Classes_Core;
using System.Collections.ObjectModel;


namespace Test 
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetPlaceTest()
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
        public void GetUserTest()
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
        [TestMethod]
        public void GettClientTest()
        {
            Client expectedClient = new Client
            {
                Id = 2,
                Name = "artem",
                LastName = "artem",
                ID_User = 3
            };
            Client actualClient = DataAccess.GetCurrentClient(DataAccess.GetUser("artem1", "qwerty123!"));
            Assert.AreEqual(expectedClient.Id, actualClient.Id);
            Assert.AreEqual(expectedClient.Name, actualClient.Name);
            Assert.AreEqual(expectedClient.ID_User, actualClient.ID_User);
        }
        [TestMethod]
        public void GettOwnerTest()
        {
            Owner expectedOwner = new Owner
            {
                Id = 2,
                Name = "Петров",
                LastName = "Пётр"
            };
            Owner actualOwner = DataAccess.GetCurrentOwner(DataAccess.GetUser("2", "2"));
            Assert.AreEqual(expectedOwner.Id, actualOwner.Id);
            Assert.AreEqual(expectedOwner.Name, actualOwner.Name);
        }
        [TestMethod]
        public void GetActivityTest()
        {
            Activity expectedActivity = new Activity
            {
                Id = 17,
                Name = "Рэйв к началу лета",
            };
            Activity actualActivity = DataAccess.GetActivity(17);
            Assert.AreEqual(expectedActivity.Id, actualActivity.Id);
            Assert.AreEqual(expectedActivity.Name, actualActivity.Name);
        }

        [TestMethod]
        public void GetRequestTest()
        {
            Request expectedRequest = new Request
            {
                Id = 2,
                Name = "турнир",
                ID_Status = 2,
                Price = 300
            };
            Request actualRequest = DataAccess.GetRequest(2);
            Assert.AreEqual(expectedRequest.Id, actualRequest.Id);
            Assert.AreEqual(expectedRequest.Name, actualRequest.Name);
            Assert.AreEqual(expectedRequest.Price, actualRequest.Price);
        }

        [TestMethod]
        public void AddReviewTest()
        {
            Review review = new Review
            {
                ID_Client = 1,
                ID_Place = 1,
                Date = DateTime.Now,
                Review_Message = "хорошее место, мне  понравилось"
            };
            DataAccess.AddNewReview(review);
            ObservableCollection<Review> reviews = DataAccess.GetReviews(1);
            Assert.IsTrue(reviews.Contains(review));
        }
    }
}
