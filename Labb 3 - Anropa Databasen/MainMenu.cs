using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class MainMenu : Menu
    {
        EmployeeMenu empMenu;
        StudentMenu stuMenu;
        GradeMenu graMenu;
        AddEmpMenu addEmpMenu;
        public MainMenu()
        {
            menuSections.AddRange(new List<string>() { "HUVUDMENY", "", "[ ] Visa Personal", "[ ] Visa Elever", "[ ] Visa Betyg", "[ ] Lägg Till Personal" });
            empMenu = new EmployeeMenu();
            stuMenu = new StudentMenu();
            graMenu = new GradeMenu();
            addEmpMenu = new AddEmpMenu();
        }

        public override void RunFunction(int selection)
        {
            Console.Clear();
            switch (selection)
            {
                case 2:
                    MenuInteraction.RunMenu(empMenu);
                    break;
                case 3:
                    MenuInteraction.RunMenu(stuMenu);
                    break;
                case 4:
                    MenuInteraction.RunMenu(graMenu);
                    break;
                case 5:
                    MenuInteraction.RunMenu(addEmpMenu);
                    break;
                default:
                    break;
            }
        }
    }
}
