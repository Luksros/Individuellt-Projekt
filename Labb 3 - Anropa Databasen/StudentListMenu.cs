using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Labb_3___Anropa_Databasen.Models;

namespace Labb_3___Anropa_Databasen
{
    class StudentListMenu : Menu
    {
        public StudentListMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA SAMTLIGA ELEVER", "", "[ ] Förnamn, Stigande", "[ ] Förnamn, Fallande", "[ ] Efternamn, Stigande", "[ ] Efternamn, Fallande" });
        }
        public override void RunFunction(int selection)
        {
            Console.Clear();
            MenuInteraction.Headline("VISA SAMTLIGA ELEVER\n");
            IOrderedQueryable<Student> students2 = MenuInteraction.Context.Student.OrderBy(s => s.Id);
            List<Class> classes = new List<Class>();
            foreach (var item in MenuInteraction.Context.Class)
            {
                classes.Add(item);
            }
            switch (selection)
            {
                case 2:
                    students2 = students2.OrderBy(s => s.Fname);
                    break;
                case 3:
                    students2 = students2.OrderByDescending(s => s.Fname);
                    break;
                case 4:
                    students2 = students2.OrderBy(s => s.Lname);
                    break;
                case 5:
                    students2 = students2.OrderByDescending(s => s.Lname);                
                    break;
            }
            foreach (var item in students2)
            {
                string space = new string(' ', (17 - ((item.Fname.Length) + (item.Lname.Length))));
                Console.WriteLine((selection < 4) ? $"Personnr: {item.PersonalId} | Namn: {item.Fname} {item.Lname} {space} | Klass: {classes[item.ClassId - 1].ClassName}" :
                                                    $"Personnr: {item.PersonalId} | Namn: {item.Lname} {item.Fname} {space} | Klass: {classes[item.ClassId - 1].ClassName}");
            }
            Escape();
        }
    }
}
