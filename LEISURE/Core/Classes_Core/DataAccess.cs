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
        public static ObservableCollection<Role> GetRoles()
        {
            return roles;
        }
    }
}
