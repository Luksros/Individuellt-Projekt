using System;
using System.Collections.Generic;
using System.Text;
using Labb_3___Anropa_Databasen.Models;

namespace Labb_3___Anropa_Databasen
{
    class AddEmpMenu : Menu
    {
        public AddEmpMenu()
        {
            menuSections.AddRange(new List<string>() { "LÄGG TILL ANSTÄLLD", "", "[ ] Vaktmästare", "[ ] Lärare", "[ ] Administratör" });
        }
        public override void RunFunction(int selection)
        {
            Console.Clear();
            MenuInteraction.Headline($"LÄGG TILL {menuSections[selection][4..].ToUpper()}\n");

            //Collecting required data:
            Console.Write("Fyll i förnamn: ");
            string tempFname = Console.ReadLine();
            Console.Write("Fyll i efternamn: ");
            string tempLname = Console.ReadLine();
            Console.Write("Fyll i personnummer: ");
            string tempPersId = Console.ReadLine();

            //Collected data is put into a new Employee object, that's added to the Employee DbSet. Changes are saved.
            Employee tempEmp = new Employee() { Fname = tempFname, Lname = tempLname, PersonalId = tempPersId, JobId = selection };
            MenuInteraction.Context.Add(tempEmp);
            MenuInteraction.Context.SaveChanges();
            Console.WriteLine($"\n{tempFname} {tempLname} har lagts till bland de anställda!");
            Escape();
        }
    }
}
