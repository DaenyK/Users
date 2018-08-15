using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace InviteUser.Lib.model
{
    public static class WorkUser
    {
        public static void DoWork()
        {
            ServiceUser serviceUser = new ServiceUser();
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("results");

            foreach (results item in serviceUser.InvokeUser())
            {
                //имя
                XmlElement name = doc.CreateElement("name");
                XmlElement fName = doc.CreateElement("fName");
                XmlElement lName = doc.CreateElement("lName");
                fName.InnerText = item.name.first;
                lName.InnerText = item.name.last;
                name.AppendChild(fName);
                name.AppendChild(lName);
                root.AppendChild(name);

                //телефон
                XmlElement cell = doc.CreateElement("cell");
                cell.InnerText = item.cell;
                root.AppendChild(cell);

                //др
                XmlElement dob = doc.CreateElement("dob");
                dob.InnerText = item.dob.date;
                root.AppendChild(dob);
                XmlAttribute dobAge = doc.CreateAttribute("age");
                dobAge.InnerText = item.dob.age;
                dob.Attributes.Append(dobAge);

                //пол
                XmlAttribute gender = doc.CreateAttribute("gender");
                gender.InnerText = item.gender;
                root.Attributes.Append(gender);

                //локация
                XmlElement location = doc.CreateElement("location");
                XmlElement city = doc.CreateElement("city");
                XmlElement state = doc.CreateElement("state");
                city.InnerText = item.location.city;
                state.InnerText = item.location.state;
                location.AppendChild(city);
                location.AppendChild(state);
                root.AppendChild(location);
            }
            doc.AppendChild(root);
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\" + Guid.NewGuid() + ".xml");
        }

        public static void Sort()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK");
            foreach (FileInfo item in dirInfo.GetFiles("*.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item.FullName);
                //XmlNode node = doc.SelectSingleNode("/results[@name=gender]");

                InfoMoveTo(doc, item.FullName);
                if (doc.DocumentElement.GetAttribute("gender") == "male")
                    item.MoveTo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\male\" + item.Name);
                else
                    item.MoveTo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\female\" + item.Name);
            }

        }

        public static void InfoMoveTo(XmlDocument docInfo, string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\report\otchet.xml");
            XmlElement root = doc.DocumentElement;

            XmlElement user = doc.CreateElement("user");


            XmlElement fio = doc.CreateElement("fio");
            fio.InnerText = docInfo.SelectSingleNode(@"results/name/fName").InnerText;
            fio.InnerText += docInfo.SelectSingleNode(@"results/name/lName").InnerText;
            user.AppendChild(fio);

            XmlElement phoneNum = doc.CreateElement("phoneNum");
            phoneNum.InnerText = docInfo.SelectSingleNode(@"results/cell").InnerText;
            user.AppendChild(phoneNum);

            XmlElement age = doc.CreateElement("age");
            XmlNode n = docInfo.SelectSingleNode(@"results/dob");
            age.InnerText = n.Attributes[0].InnerText;
            user.AppendChild(age);

            XmlElement address = doc.CreateElement("address");
            address.InnerText = docInfo.SelectSingleNode(@"results/location/city").InnerText;
            address.InnerText += docInfo.SelectSingleNode(@"results/location/state").InnerText;
            user.AppendChild(address);



            XmlElement status = doc.CreateElement("status");
            user.AppendChild(status);

            XmlElement updateUser = doc.CreateElement("updateUser");
            user.AppendChild(updateUser);

            XmlElement fullpath = doc.CreateElement("fullpath");
            fullpath.InnerText = filepath;
            user.AppendChild(fullpath);


            root.AppendChild(user);
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\DK\report\otchet.xml");
        }
    }
}
