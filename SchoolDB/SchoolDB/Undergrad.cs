using System;

namespace SchoolDB
{
    public enum YearRank
    {
        FRESHMAN,
        SOPHOMORE,
        JUNIOR,
        SENIOR,
        DEGREE_MAJOR
    }
    public class Undergrad : Student
    {
        public Undergrad(string firstName, string lastName, string emailAddress, double GPA, int yearRank) :
            base(firstName, lastName, emailAddress, GPA)
        {
            switch ((YearRank)yearRank)
            {
                case YearRank.FRESHMAN:
                    {
                        _YearRank = "Freshman";
                        break;
                    }
                case YearRank.SOPHOMORE:
                    {
                        _YearRank = "Sophomore";
                        break;
                    }
                case YearRank.JUNIOR:
                    {
                        _YearRank = "Junior";
                        break;
                    }
                case YearRank.SENIOR:
                    {
                        _YearRank = "Senior";
                        break;
                    }
                case YearRank.DEGREE_MAJOR:
                    {
                        _YearRank = "Degree Major";
                        break;
                    }
                default:
                    {
                        _YearRank = null;
                        break;
                    }
            }
        }

        public string _YearRank
        {
            get;
            set;
        }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName} {EmailAddress} {Gpa} {_YearRank}";
        }
    }
}
