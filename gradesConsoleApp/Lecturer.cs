using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradesConsoleApp
{
     class Lecturer
    {
        public string lecturerName;
        public string student;
        public int studentId;
        public int [] grades;
        //int Counter = 0;
        public Lecturer(string lecturerName, string student, int studentId, int[] grades)
        {
            this.lecturerName = lecturerName;
            this.student = student;
            this.studentId = studentId; 
            this.grades = grades;
            
        }
    }
}
