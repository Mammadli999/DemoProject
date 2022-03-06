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
                    break;
                case Menu.GroupRemove:
                    break;
                case Menu.GroupSingle:
                    break;
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
                    break;
                case Menu.StudentRemove:
                    break;
                case Menu.StudentSingle:
                    break;
                case Menu.StudentAll:
                    ShowAllStudents(studentMgr);
                    goto readMenu;
                case Menu.All:
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
            Console.Clear();
            Console.WriteLine("**********Groups**********");
            foreach (var item in groupMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllStudents(StudentManager studentMgr)
        {
            Console.Clear();
            Console.WriteLine("**********Students**********");
            foreach (var item in studentMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
