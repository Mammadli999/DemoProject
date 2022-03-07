using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DemoProject.Managers
{
   public class StudentManager
    {
        Student[] data = new Student[0];

        public void StudentEditName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebenin ID-ni Secin: ");
                    string NewName = ScannerManager.ReadString("Yeni Telebe Elave Edin: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, NewName);
                }
            }
        }

        public void StudentEditSurname(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebenin Soyadini Secin: ");
                    string Surname = ScannerManager.ReadString("Yeni Soyad Elave Edin: ");
                    data[i].Surname = data[i].Surname.Replace(data[i].Surname, Surname);
                }
            }
        }

        public void StudentEditId(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebenin ID-ni Secin: ");
                    string NewId = ScannerManager.ReadString("Yeni Id Daxil Edin: ");

                    
                }
            }
        }




        public void Add(Student entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public Student[] GetAll()
        {
            return data;
        }
    }
}
