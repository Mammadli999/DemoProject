using ConsoleApp.DemoProject.Infrastructure;
using ConsoleApp.DemoProject.Managers;
using System;
using System.Text;

namespace ConsoleApp.DemoProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Student System v.1";

            var  groupMgr = new GroupManager();
            var  studentMgr = new StudentManager();

            readMenu:
            PrintMenu();

            Menu m = ScannerManager.ReadMenu("Menudan Secin: ");

            switch (m)
            {
                case Menu.GroupAdd:
                    Console.Clear();
                    Group g = new Group();
                    g.Name = ScannerManager.ReadString("Qrupun Adini Daxil Edin: ");
                    g.Speciality = ScannerManager.ReadString("Qrupun Ixtisasini Daxil Edin: ");

                    groupMgr.Add(g);

                    goto case Menu.GroupAll;

                case Menu.GroupEdit:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("Ad Deyismek ucun ==> 1 || Ixtisas Deyismek Ucun ==> 2");
                    bool success = int.TryParse(Console.ReadLine(), out int menuNumber);
                    if (success && menuNumber == 1)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Qrupun ID-ni Daxil Edin: ");
                        groupMgr.GroupEditId(value);
                    }
                    else if (success && menuNumber == 2)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Qrupun ID-ni Daxil Edin: ");
                        groupMgr.GroupEditSpeciality(value);
                    }

                    goto case Menu.GroupAll;

                case Menu.GroupRemove:
                    break;
                case Menu.GroupSingle:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    int idvalue = ScannerManager.ReadInteger("Secdiyiniz Qrupun ID-ni Daxil Edin:");
                    groupMgr.GroupSingle(idvalue);
                    goto readMenu;

                case Menu.GroupAll:
                    ShowAllGroups(groupMgr);
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.StudentAdd:
                    Student s = new Student();
                    s.Name = ScannerManager.ReadString("Telebenin Adi: ");
                    s.Surname = ScannerManager.ReadString("Telebenin Soyadi: ");
                    s.BirthDate = ScannerManager.ReadDate("Telebenin Dogum Tarixi: ");
                    Console.WriteLine("--------");
                    ShowAllGroups(groupMgr);
                    Console.WriteLine("--------");
                    s.GroupId = ScannerManager.ReadInteger("Telebenin Qrupu: ");

                    studentMgr.Add(s);
                    goto case Menu.StudentAll;
                case Menu.StudentEdit:

                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    Console.WriteLine("Ad Deyismek ucun ==> 1 || Soyad Deyismek Ucun ==> 2  || Dogum Tarixini Deyismek Ucun ==> 3 || Qrupu Deyismek Ucun ==> 4");
                    bool success1 = int.TryParse(Console.ReadLine(), out int menuNumber1);
                    if (success1 && menuNumber1 == 1)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Telebenin ID-ni Daxil Edin: ");
                        studentMgr.StudentEditName(value);
                    }
                    if (success1 && menuNumber1 == 2)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Telebenin ID-ni Daxil Edin: ");
                        studentMgr.StudentEditSurname(value);
                    }
                    else if (success1 && menuNumber1 == 3)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Telebenin ID-ni Daxil Edin:");
                        studentMgr.StudentEditDateTime(value);
                    }
                    else if (success1 && menuNumber1 == 4)
                    {
                        int value = ScannerManager.ReadInteger("Deyismek Istediyiniz Telebenin ID-ni Daxil Edin:");
                        studentMgr.StudentEditId(value);
                    }
                    goto case Menu.StudentAll;
                case Menu.StudentRemove:
                    break;
                case Menu.StudentSingle:
                    Console.Clear();
                    ShowAllStudents(studentMgr);
                    int idvalue1 = ScannerManager.ReadInteger("Secdiyiniz Telebenin ID-ni Daxil Edin:");
                    studentMgr.StudentSingle(idvalue1);
                    goto readMenu;
                case Menu.StudentAll:
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.All:
                    Console.Clear();
                    ShowAllGroups(groupMgr);
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }
            lEnd:
            Console.WriteLine("END...");
            Console.WriteLine("Cixmaq Ucun Her Hansi Bir Duymeni Sixin");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.WriteLine(new string('-',Console.WindowWidth));

            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);

                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-',Console.WindowWidth)}\n");
        }

        static void ShowAllGroups(GroupManager groupMgr)
        {
            Console.WriteLine("**********Groups************");
            foreach (var item in groupMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllStudents(StudentManager studentMgr)
        {
            Console.WriteLine("**********Students**********");
            foreach (var item in studentMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
