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


    }
}
