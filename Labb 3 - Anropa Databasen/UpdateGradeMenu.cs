using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class UpdateGradeMenu : Menu
    {
        public int StudID;
        public UpdateGradeMenu()
        {
            menuSections.AddRange(new List<string> { "UPPDATERA BETYG", " ", "[ ] HISTORIA", "[ ] MATTE", "[ ] FYSIK", "[ ] MUSIK", "[ ] SVENSKA" });
        }

        public override void RunFunction(int selection)
        {
            Console.Clear();
            MenuInteraction.Headline($"UPPDATERA BETYG I {menuSections[selection].Substring(4)}\n");
            var stuC = (from studInC in MenuInteraction.Context.StudentsInCourses.Where(s => s.StudentId == StudID && s.CourseId == selection - 1)
                        select studInC).FirstOrDefault();

            var getGrade = from students in MenuInteraction.Context.Student.Where(s => s.Id == StudID)
                           join stuCo in MenuInteraction.Context.StudentsInCourses.Where(st => st.CourseId == selection - 1) on students.Id equals stuCo.StudentId
                           join course in MenuInteraction.Context.Course on stuCo.CourseId equals course.Id
                           join grade in MenuInteraction.Context.Grade on stuCo.GradeId equals grade.Id
                           select new { FName = students.Fname, LName = students.Lname, courName = course.CourseName, curGrade = grade.Grade1 };

            if (stuC != null)
            {
                foreach (var item in getGrade) { Console.WriteLine($"Nuvarande betyg: {item.curGrade}"); }
                Console.Write("Sätt nytt betyg (A - F): [-]");
                string newGrade = MenuInteraction.GradeInput();
                Console.Write(newGrade);
                Console.WriteLine();
                if (newGrade != "ESC")
                {
                  //  foreach (var item in stuC)
                   // {
                        stuC.GradeId = Convert.ToChar(newGrade) - 64;
                        stuC.GradeDate = DateTime.Now;
                   // }
                    MenuInteraction.Context.SaveChanges();
                    foreach (var item in getGrade) { MenuInteraction.PrintCyan($"\n{item.FName + " " + item.LName}'s betyg i {item.courName} har uppdaterats till {newGrade}!"); }
                    Escape();
                }
                //foreach (var item in stuC)
                //{
                //    Console.WriteLine(item.CourseId + " " + item.StudentId + (Convert.ToChar(newGrade) - 64));
                //}
                //Escape();
            }
            else
            {
                foreach (var item in getGrade) { MenuInteraction.PrintCyan($"{item.FName + " " + item.LName} studerar inte den här kursen."); }
                Escape();
            }
        }
    }
}
