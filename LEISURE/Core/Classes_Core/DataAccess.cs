using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ado;
using System.Collections.ObjectModel;

namespace Core.Classes_Core
{
    public class DataAccess
    {
        private static ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
        private static ObservableCollection<Owner> managers = new ObservableCollection<Owner>(DB_Connection.connection.Owner);
        private static ObservableCollection<Client> clients = new ObservableCollection<Client>(DB_Connection.connection.Client);
        public static ObservableCollection<Role> GetRoles()
        {
            ObservableCollection<Role> roles = new ObservableCollection<Role>(DB_Connection.connection.Role);
            return roles;
        }
        public static ObservableCollection<Client> GetClients()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>(DB_Connection.connection.Client);
            return clients;
        }

        public static ObservableCollection<Activity> GetActivities()
        {
            ObservableCollection<Activity> activities = new ObservableCollection<Activity>(DB_Connection.connection.Activity);
            return activities;
        }
        public static List<Role> Get() // метод миши. не работает
        {
            return DB_Connection.connection.Role.ToList();
        }
        public static List<Role> GetRolesList() // для получения ролей, хорошо работает с апишкой
        {
            List<Role> dbRoles = new List<Role>(DB_Connection.connection.Role);
            List<Role> roles = new List<Role>(dbRoles);
            foreach (var role in dbRoles)
            {
                roles.Add(
                    new Role
                    {
                        Id = role.Id,
                        Name = role.Name
                    });
            }
            return roles;
        }

        public static IEnumerable<Place> GetPlacesList()
        {
            return (IEnumerable<Place>)DataAccess.GetPlaces().Where(p => p.IsOpen == true).ToList();
        }
        public static ObservableCollection<Place_Type> GetPlaceTypes()  
        {
            ObservableCollection<Place_Type> placeTypes = new ObservableCollection<Place_Type>(DB_Connection.connection.Place_Type);
            return placeTypes;
        }

        public static bool IsCorrectUser(string login, string password)
        {
            var currentUser = users.Where(u => u.Login == login && u.Password == password).ToList();
            return currentUser.Count == 1;
        }
        
        public static bool IsOwner(User user)
        {
            var manger = managers.Where(m => m.ID_User == user.Id).FirstOrDefault();
            return managers.Count == 1;
        }

        public static User GetUser(string login, string password)
        {
            User currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            return currentUser;
        }

        public static Owner GetCurrentOwner(User user)
        {   
            Owner owner = user.Owner.Where(o => o.ID_User == user.Id).FirstOrDefault();
            return owner;
        }

        public static User GetUserFromOwner(Owner owner)
        {
            User user = users.Where(u => u.Id == owner.ID_User).FirstOrDefault();
            return user;
        }
        public static Client GetCurrentClient(User user)
        {
            Client client = user.Client.Where(o => o.ID_User == user.Id).FirstOrDefault();
            return client;
        }

        public static bool AddNewPlace(string name, int idType, string adress, int idOwner, string capacity, byte[] photo, string description)
        {
            Place place = new Place();
            place.Name = name;
            place.ID_Type = idType;
            place.Adress = adress;
            place.ID_Owner = idOwner;
            place.Capacity = capacity;
            place.IsOpen = true;
            place.Visits = 0;
            place.Description = description;
            place.Photo = photo;
            try
            {
                DB_Connection.connection.Place.Add(place);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewPlaceType(Place_Type type)
        {
            try
            {
                DB_Connection.connection.Place_Type.Add(type);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewUser( string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            user.ID_Role = 1;
            try
            {
                DB_Connection.connection.User.Add(user);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewClient(string name, string lastName)
        {
            int lastId = users.Last().Id+1;
            Client client = new Client();
            client.Name = name;
            client.LastName = lastName;
            client.RegDate = DateTime.Now;
            client.ID_User = lastId;
            try
            {
                DB_Connection.connection.Client.Add(client);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoginExists(string login)
        {
            if (users.Where(u => u.Login == login).ToList().Count != 0)
                return true;
            else 
                return false;

        }

        public static bool UpdatePlaceType(Place_Type type)
        {
            var place = DataAccess.GetPlaceType(type.Id);
            place.Name = type.Name;
            try
            {
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public static ObservableCollection<Place> GetPlacesByOwner(Owner owner)
        {
            return new ObservableCollection<Place>(DB_Connection.connection.Place.Where(p => p.ID_Owner == owner.Id));
        }

        public static Place_Type GetPlaceType(int id)
        {
           ObservableCollection<Place_Type> types = new ObservableCollection<Place_Type>(DB_Connection.connection.Place_Type);
            return types.Where(t => t.Id == id).FirstOrDefault();
        }

        public static Client GetClientById(int id)
        {
            return clients.Where(c => c.Id == id).FirstOrDefault();
        }


        public static ObservableCollection<Place> GetPlacesByNameOrAdress(string content)
        {
            return new ObservableCollection<Place>(DB_Connection.connection.Place.Where(place => (place.Name.Contains(content) || place.Adress.Contains(content)) && place.IsOpen == true));
        }
        public static ObservableCollection<Place> GetPlaces()
        {
            return new ObservableCollection<Place>(DB_Connection.connection.Place);
        }
        public static Place GetPlace(int id)
        {
            return GetPlaces().Where(p => p.Id == id).FirstOrDefault();
        }

        public static bool CurrentUserIsClient(User user)
        {
            var client = clients.Where(c => c.ID_User == user.Id).ToList();
            return client.Count == 1;
        }

        public static bool EditPlace(Place place,  string name, int idType, string adress, string capacity, byte[] photo, string description)
        {
            try
            {
                place.Name = name;
                place.ID_Type = idType;
                place.Adress = adress;
                place.Capacity = capacity;
                place.IsOpen = true;
                place.Visits = 0;
                place.Photo = photo;
                place.Description = description;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddActivityByRequest(Request request)
        {
            try
            {
                Activity activity = new Activity();
                activity.Name = request.Name;
                activity.Description = request.Description;
                activity.Price = request.Price;
                activity.ID_Place = request.ID_Place;
                activity.Start_Date = request.DateStart;
                activity.Time_Start = request.TimeStart;
                activity.Photo = request.Photo;
                activity.ID_Type = request.ID_Type;
                activity.ID_Request = request.Id;
                activity.Visits = 0;
                DB_Connection.connection.Activity.Add(activity);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewRequest(Place place, DateTime start, TimeSpan startTime, Nullable<float> price, string description,  string name, Nullable<int> idType, string info, string comment, byte[] photo)
        {
            try
            {
                Request request = new Request();
                request.ID_Place = place.Id;
                request.DateStart = start;
                request.TimeStart = startTime;
                request.Price = price;
                request.Description = description;
                request.Photo = photo;
                request.Name = name;
                request.ID_Status = 1;
                request.ID_Type = idType;
                request.ContactInfo = info;
                request.Comment = comment;
                DB_Connection.connection.Request.Add(request);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewActivity(Place place, DateTime start, TimeSpan startTime, float price, string description, byte[] photo, string name, int idType)
        {
            try
            {
                Activity activity = new Activity();
                activity.ID_Place = place.Id;
                activity.Start_Date = start;
                activity.Time_Start = startTime;
                activity.Price = price;
                activity.Description = description;
                activity.Photo = photo;
                activity.Name = name;
                activity.Visits = 0;
                activity.ID_Type = idType;
                
                DB_Connection.connection.Activity.Add(activity);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewReview(int idClient, int idPlace, string message)
        {
            try
            {
                Review review = new Review();
                review.ID_Client = idClient;
                review.ID_Place = idPlace;
                review.Date = DateTime.Now.Date;
                review.Review_Message = message;
                DB_Connection.connection.Review.Add(review);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ObservableCollection<Request> GetRequestsForOwner(int idOwner)
        {
            return new ObservableCollection<Request>(DB_Connection.connection.Request.Where(r => r.Place.ID_Owner == idOwner));
        }


        public static bool ClosePlace(Place place)
        {
            try
            {
                place.IsOpen = false;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ObservableCollection<Place> GetPlacesByType(int id)
        {
            return new ObservableCollection<Place>(DB_Connection.connection.Place.Where(p => p.ID_Type == id || p.ID_Type == -1));
        }
        public static ObservableCollection<Activity> GetActivitiesByType(int id)
        {
            return new ObservableCollection<Activity>(DB_Connection.connection.Activity.Where(p => p.ID_Type == id || p.ID_Type == -1));
        }

        public static ObservableCollection<Activity_Type> GetActivityTypes()
        {
            return new ObservableCollection<Activity_Type>(DB_Connection.connection.Activity_Type);
        }

        public static ObservableCollection<Review> GetReviews(int idPlace)
        {
            return new ObservableCollection<Review>(DB_Connection.connection.Review.Where(r => r.ID_Place == idPlace));
        }


        public static bool AddVisitToPlace(Place place)
        {
            try
            {
                place.Visits += 1;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddVisitToActivity(Activity activity)
        {
            try
            {
                activity.Visits += 1;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AcceptRequest(Request request)
        {
            try
            {
                request.ID_Status = 2;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeclineRequest(Request request)
        {
            try
            {
                request.ID_Status = 3;
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
