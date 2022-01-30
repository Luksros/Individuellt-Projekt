using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class StudentMenu : Menu
    {
        ClassListMenu classListMenu;
        StudentListMenu stuListMenu;
        public StudentMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA ELEVER", "", "[ ] Visa Samtliga", "[ ] Visa Särskild Klass" });
            classListMenu = new ClassListMenu();
            stuListMenu = new StudentListMenu();
        }
        public override void RunFunction(int selection)
        {
            Console.Clear();
            switch (selection)
            {
                case 2:
                    MenuInteraction.RunMenu(stuListMenu);
                    break;                   
                case 3:
                    MenuInteraction.RunMenu(classListMenu);
                    break;
                default:
                    break;
            }         
        }
    }
}
