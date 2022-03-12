using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DemoProject.Managers
{
   public class GroupManager
    {
        Group[] data = new Group[0];

        public void GroupRemove(Group entity)
        {
            int index = Array.IndexOf(data, entity);

            if (index == -1)
            {
                return;
            }

            for (int i = index ; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
            {
                Array.Resize(ref data, data.Length - 1);
            }
            
        }

        public void GroupSingle(int value)
        {
            string singleGroup = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    singleGroup = $"Qrup ID: {data[i].Id}\n" +
                        $"Qrupun Adi: {data[i].Name}\n" +
                        $"Qrupun Ixtisasi: {data[i].Speciality}";
                }
            }
            Console.WriteLine(singleGroup);
        }

        public void GroupEditId(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Qrup Adini Secin: ");
                    string NewName = ScannerManager.ReadString("Yeni Ad Daxil Edin: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, NewName);
                }
            }
        }

        public void GroupEditSpeciality(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Qrup Ixtisasini Secin: ");
                    string Speciality = ScannerManager.ReadString("Yeni Ixtisas Daxil Edin: ");
                    data[i].Speciality = data[i].Speciality.Replace(data[i].Speciality, Speciality);
                }
            }
        }


        public void Add(Group entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public Group[] GetAll()
        {
            return data;
        }
    }
}
