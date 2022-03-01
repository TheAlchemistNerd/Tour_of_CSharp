using System;

namespace SchoolDB
{
    public class Undergrad : Student
    {
        enum YearRank
        {
            FRESHMAN,
            SOPHOMORE,
            JUNIOR,
            SENIOR,
            DEGREE_MAJOR
        }

        YearRank yeaRank;
        public Undergrad(string firstName, string lastName, string emailAddress, double GPA, int yearRank) :
            base(firstName, lastName, emailAddress, GPA)
        {
            this.yeaRank = (YearRank)yearRank;
        }
    }
}
