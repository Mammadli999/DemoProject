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

        public void StudentRemove(Student entity)
        {
            int index = Array.IndexOf(data, entity);

            if (index == -1)
            {
                return;
            }

            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
            {
                Array.Resize(ref data, data.Length - 1);
            }

        }



        public void StudentSingle(int value)
        {
            string stundetSingle = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    stundetSingle = $"Telebe Id: {data[i].Id}\n" +
                        $"Telebenin Adi: {data[i].Name}\n" +
                        $"Telebenin Soyadi: {data[i].Surname}\n" +
                        $"Telebenin Dogum Tarixi: {data[i].BirthDate:dd.MM.yyyy}\n";
                }
                Console.WriteLine(stundetSingle);
            }
        }



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

        public void StudentEditDateTime(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    Console.WriteLine("Telebenin ID-ni Secin: ");
                    DateTime NewBirth = ScannerManager.ReadDate("Yeni Dogum Tarixi Daxil Edin: ");
                    data[i].BirthDate = NewBirth;
                    break;
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
                    int NewId = ScannerManager.ReadInteger("Yeni Id Daxil Edin: ");
                    data[i].GroupId = NewId;
                    break;
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
