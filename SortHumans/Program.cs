using InviteUser.Lib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortHumans
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    WorkUser.Sort();
                    Console.WriteLine("*");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
