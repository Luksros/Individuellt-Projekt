using Labb_3___Anropa_Databasen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_3___Anropa_Databasen
{
    class GradeAvgMenu : Menu
    {

        public GradeAvgMenu()
        {
            menuSections.AddRange(new List<string>() { "VISA SNITTBETYG", "", "[ ] Historia", "[ ] Matte", "[ ] Fysik", "[ ] Musik", "[ ] Svenska"});
        }
        public override void RunFunction(int selection)
        {
            var stuCourse = MenuInteraction.Context.StudentsInCourses.Where(s => s.CourseId == selection - 1);
            List<Grade> gradeNames = new List<Grade>();
            foreach (var item in MenuInteraction.Context.Grade)
            {
                gradeNames.Add(item);
            }
            
            Console.Clear();
            MenuInteraction.Headline(menuSections[selection][4..].ToUpper() + "\n");

            //Adding the ID of any existing grades in the chosen course to a list, which corresponds with their value: 1 == A and F == 6
            List<int> grades = new List<int>();
            foreach (var item in stuCourse)
            {
                if (item.GradeId != null)
                {
                    grades.Add(item.GradeId ?? default);
                }
            }
            
            
            //If grades.Count isn't more than zero, that means that there are no grades for that course.
            //Therefore, continuing further would result in null exceptions. 
            if (grades.Count > 0)
            {
                //Dividing the total sum of the grades by the total amount of grades to find the average.
                //The lower the value, the better the grade, since the Grade table starts on A.
                //The resulting value will correspond with the average grades position in the Grade table,
                //which will need to subtracted by 1 to work with the indexing of the gradeNames list, since it starts at 0.
                float avgGrade = (grades.Sum() / grades.Count);
                int avgIndex = Convert.ToInt32(Math.Floor(avgGrade)) - 1;

                //since the Grade table starts on A, I find the lowest grade with .Max(), and the highest with .Min().
                Console.WriteLine($"Lägsta betyg: {gradeNames[grades.Max() - 1].Grade1}");
                Console.WriteLine($"Högsta betyg: {gradeNames[grades.Min() - 1].Grade1}");
                Console.WriteLine($"Snittbetyg: {gradeNames[avgIndex].Grade1}");
            }
            else
            {
                Console.WriteLine("Inga betyg satta i denna kurs.");
            }
            Escape();
        }
    }
}
