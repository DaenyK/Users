using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InviteUser.Lib.model;

namespace InvitesUser
{
    class Program
    {
        static void Main(string[] args)
        {
           try
                { while (true)
                {
                    Thread.Sleep(1000);
                    WorkUser.DoWork();
                    Console.WriteLine("*");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
