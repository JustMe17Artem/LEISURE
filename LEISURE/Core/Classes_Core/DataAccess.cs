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
        private static ObservableCollection<Role> roles = new ObservableCollection<Role>(DB_Connection.connection.Role);
        private static ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
        private static ObservableCollection<Owner> managers = new ObservableCollection<Owner>(DB_Connection.connection.Owner);
        public static ObservableCollection<Role> GetRoles()
        {
            return roles;
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

        public static bool AddNewPlace(string name, int idType, string adress, int idOwner, int capacity, byte[] photo)
        {
            Place place = new Place();
            place.Name = name;
            place.ID_Type = idType;
            place.Adress = adress;
            place.ID_Owner = idOwner;
            place.Capacity = capacity;
            place.IsOpen = true;
            place.Visits = 0;
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



    }
}
