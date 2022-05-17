using System;
using Core;
using Core.ado;
using Core.Classes_Core;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var r in DataAccess.GetRoles())
            {
                Console.WriteLine(r.Name);
            }
        }
    }
}
