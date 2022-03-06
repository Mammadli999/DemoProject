using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DemoProject
{
   public class Group
    {
        static int counter = 0;

        public Group()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Speciality { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} ({Speciality})";
        }
    }
}
