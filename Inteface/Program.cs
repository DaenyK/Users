using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Inteface
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\report\otchet.xml");
            Console.Write("введите возраст, чтобы вывести информацию о людях до этого возраста: ");
            int age = Int32.Parse(Console.ReadLine());

            foreach (XmlNode item in doc.SelectNodes("users/user"))
            {
                int ageUser = Int32.Parse(item.SelectSingleNode("age").InnerText);
                if (ageUser<age)
                    Console.WriteLine(item.SelectSingleNode("fio").InnerText);
                Console.WriteLine("введите статус: ");
                item.SelectSingleNode("status").InnerText = Guid.NewGuid().ToString();
                item.SelectSingleNode("updateUser").InnerText = DateTime.Now.ToString();

            }
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\report\otchet.xml");

        }
        

    }
}
