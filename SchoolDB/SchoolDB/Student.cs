using System;

namespace SchoolDB
{
    [Serializable]
    public class Student
    {

        // string _firstName, _lastName, _emailAddress;
        // double _gpa;
        
        public Student (string firstName, string lastName, string emailAddress, double GPA) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Gpa = GPA;
        }

        public Student() 
        {

        }

        public Student(string emailAddress)
        {
            EmailAddress = emailAddress;
            // Look up student
        }


        private void Initialize(string firstName, string lastName, string emailAddress, double GPA)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Gpa = GPA;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string EmailAddress
        {
            get;
            set;
        }

        public double Gpa
        {
            get;
            set;
        }
    }
}