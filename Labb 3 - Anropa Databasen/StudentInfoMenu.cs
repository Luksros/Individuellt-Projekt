using Labb_3___Anropa_Databasen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    public class StudentInfoMenu : Menu
    {
        public StudentUpdateMenu StuUpdMenu;
        public StudentInfoMenu()
        {
            StuUpdMenu = new StudentUpdateMenu();
            menuSections.AddRange(new List<string>() { "VISA ENSKILD ELEV", "", "[↑] Visa Föregående       [ESC] Återgå                [TAB] Ändra Info", "[↓] Visa Nästa            [ENTER] Sök på personnummer", " " });
        }
        public override void RunFunction(int selection) { }
        public int SearchStudent(int input)
        {
            Console.Clear();
            MenuInteraction.Headline($"{menuSections[0]}\n");
            Console.Write("Skriv in personnummer att söka på: [----------]");

            List<Student> AllStudents = new List<Student>();
            foreach (var item in MenuInteraction.Context.Student.OrderBy(v => v.ClassId)) { AllStudents.Add(item); }

            string persNum = MenuInteraction.PersNumInput();

            int studentIndex = -1;
            if (persNum != "ESC")
            {             
                for (int i = 0; i < AllStudents.Count; i++)
                {
                    if (AllStudents[i].PersonalId == persNum)
                    {
                        studentIndex = i;
                        return studentIndex;
                    }
                }
                if (studentIndex == -1)
                {
                    Console.Clear();
                    MenuInteraction.Headline($"{menuSections[0]}\n");
                    Console.WriteLine("Hittade ingen elev med det personnumret.");
                    Escape();
                }
            }
            return input;
        }
    }
}
