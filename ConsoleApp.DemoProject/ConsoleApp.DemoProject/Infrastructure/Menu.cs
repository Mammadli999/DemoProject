using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DemoProject.Infrastructure
{
    public enum Menu : byte
    {
        GroupAdd = 1,
        GroupEdit,
        GroupRemove,
        GroupSingle,
        GroupAll,


        StudentAdd,
        StudentEdit,
        StudentRemove,
        StudentSingle,
        StudentAll,
        All,
        Exit,
    }
}
