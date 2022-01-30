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
                    List<Student> studentList = new List<Student>();
                    List<Grade> gradeNames = new List<Grade>();
                    List<Course> courses = new List<Course>();
                    var stuCourse = MenuInteraction.Context.StudentsInCourses.Where(s => (s.GradeDate ?? default).CompareTo(DateTime.Now.AddMonths(-1)) > 0);
                    foreach (var item in MenuInteraction.Context.Student)
                    {
                        studentList.Add(item);
                    }                                 
                    foreach (var item in MenuInteraction.Context.Grade)
                    {
                        gradeNames.Add(item);
                    }                   
                    foreach (var item in MenuInteraction.Context.Course)
                    {
                        courses.Add(item);
                    }      
                    
                    MenuInteraction.Headline("VISA BETYG FRÅN SENASTE MÅNADEN\n"); 
                    foreach (var item in stuCourse)
                    {
                        string space = new string(' ', (17 - ((studentList[item.StudentId - 1].Fname.Length) + (studentList[item.StudentId - 1].Lname.Length))));
                        string space2 = new string(' ', 8 - courses[item.CourseId - 1].CourseName.Length);
                        Console.WriteLine($"Namn: {studentList[item.StudentId - 1].Fname} {studentList[item.StudentId - 1].Lname} {space} | Kurs: {courses[item.CourseId-1].CourseName} {space2}| Betyg: {gradeNames[(item.GradeId ?? default) - 1].Grade1} | Datum: {item.GradeDate.Value.ToShortDateString()}");        
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
