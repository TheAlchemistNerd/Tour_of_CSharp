using System;

namespace SchoolDB
{
    public class GradStudent : Student
    {

        public GradStudent(string firstName, string lastName, string emailAddress, double GPA) :
            base(firstName, lastName, emailAddress, GPA)
        {
            FacultyAdvisor = true;
            TutionCredit = true;
        }

        public bool FacultyAdvisor{ get; }
        public bool TutionCredit{ get; }
    }
}
