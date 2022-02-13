using Labb_3___Anropa_Databasen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class GradeMenu : Menu
    {
        GradeAvgMenu avgGrade;
        public GradeMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA BETYG", "", "[ ] Visa Betyg Från Senaste Månaden", "[ ] Visa Snittbetyg" });
            avgGrade = new GradeAvgMenu();
        }
        public override void RunFunction(int selection)
        {
            Console.Clear();

            switch (selection)
            {
                case 2:
                    var stuCourse = from stuC in MenuInteraction.Context.StudentsInCourses.Where(s => (s.GradeDate ?? default).CompareTo(DateTime.Now.AddMonths(-1)) > 0)
                                    join stud in MenuInteraction.Context.Student on stuC.StudentId equals stud.Id
                                    join grade in MenuInteraction.Context.Grade on stuC.GradeId equals grade.Id
                                    join course in MenuInteraction.Context.Course on stuC.CourseId equals course.Id
                                    select new {FName = stud.Fname, LName = stud.Lname, CoName = course.CourseName, grName = grade.Grade1, grDate = stuC.GradeDate };

                    MenuInteraction.Headline("VISA BETYG FRÅN SENASTE MÅNADEN\n"); 
                    foreach (var item in stuCourse)
                    {
                        string space = new string(' ', (17 - ((item.FName.Length) + (item.LName.Length))));
                        string space2 = new string(' ', 8 - item.CoName.Length);
                        Console.WriteLine($"Namn: {item.FName} {item.LName} {space} | Kurs: {item.CoName} {space2}| Betyg: {item.grName} | Datum: {item.grDate.Value.ToShortDateString()}");        
                    }
                    Escape();
                    break;

                case 3:
                    MenuInteraction.RunMenu(avgGrade);
                    break;
                default:
                    break;
            }
            
        }
    }
}
