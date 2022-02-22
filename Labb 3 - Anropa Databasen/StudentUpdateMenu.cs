using Labb_3___Anropa_Databasen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    public class StudentUpdateMenu : Menu
    {
        public int StudID;
        UpdateGradeMenu updGraMenu;
        public StudentUpdateMenu()
        {
            updGraMenu = new UpdateGradeMenu();
            menuSections.AddRange(new List<string> { "UPPDATERA ELEVINFO", " ", "[ ] NAMN", "[ ] BETYG", "[ ] PERSONNUMMER"});
        }

        public override void RunFunction(int selection)
        {
            Console.Clear();
            switch (selection)
            {
                case 2:
                    updateStudName();
                    break;
                case 3:
                    updGraMenu.StudID = this.StudID;
                    MenuInteraction.RunMenu(updGraMenu);
                    updGraMenu.StudID = -1;
                    break;
                case 4:
                    updateStudPersID();
                    break;
            }
        }        
        public void updateStudName()
        {
            MenuInteraction.Headline("UPPDATERA NAMN\n");
            Console.Write("Skriv in nytt förnamn: ");
            string tempFName = Console.ReadLine();
            Console.Write("Skriv in nytt efternamn: ");
            string tempLName = Console.ReadLine();
            var stud = from students in MenuInteraction.Context.Student.Where(s => s.Id == StudID)
                       select students;
            foreach (var item in stud)
            {
                MenuInteraction.PrintCyan($"\n{item.Fname + " " + item.Lname}'s namn har ändrats till {tempFName + " " + tempLName}!");
                item.Fname = tempFName;
                item.Lname = tempLName;
            }
            MenuInteraction.Context.SaveChanges();
            Escape();
        }
        public void updateStudGrade()
        {
          
        }
        public void updateStudPersID()
        {
            MenuInteraction.Headline("UPPDATERA PERSONNUMMER\n");
            Console.Write("Skriv in nytt personnummer: [----------]");
            string persnum = MenuInteraction.PersNumInput();
            if (persnum != "ESC")
            {
                var stud = from students in MenuInteraction.Context.Student.Where(s => s.Id == StudID)
                           select students;
                foreach (var item in stud)
                {
                    MenuInteraction.PrintCyan($"\n{item.Fname + " " + item.Lname}'s personnummer har ändrats till {persnum}!");
                    item.PersonalId = persnum;
                }
                MenuInteraction.Context.SaveChanges();
                Escape();
            }
        }
    }
}
