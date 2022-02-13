using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_Databasen
{
    class StudentMenu : Menu
    {
        ClassListMenu classListMenu;
        StudentListMenu stuListMenu;
        StudentInfoMenu stuInfoMenu;
        public StudentMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA ELEVER", "", "[ ] Visa Samtliga", "[ ] Visa Klasser", "[ ] Visa Enskild Elev" });
            classListMenu = new ClassListMenu();
            stuListMenu = new StudentListMenu();
            stuInfoMenu = new StudentInfoMenu();
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
                case 4:
                    MenuInteraction.RunStuInfoMenu(stuInfoMenu);
                    break;
                default:
                    break;
            }         
        }
    }
}
