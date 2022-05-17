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
            foreach(var r in DataAccess.GetReviews(4))
            {
                Console.WriteLine(r.ID_Client);
            }
        }
    }
}
