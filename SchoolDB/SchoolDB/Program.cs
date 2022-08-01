using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace SchoolDB
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo studentFile = new FileInfo(@"E:\Desktop\Csharp\SchoolDB\SchoolDB\SchoolDB.txt");
            StudentRepository studentRepository = new StudentRepository(studentFile);

            // print the first 10 student details
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(studentRepository.Students[i]);
            }

            /* TODO
             * MENU
             * The Menu is displayed in the console
             * 1. Check student details using email. Notify the user if student details are/ aren't available
             * 2. Add new Student details. If email available. Notify the user and discard the object
             * 3. Delete Student using email. If email not available notify the user
             * 4. Update Student details
             *      - first name
             *      - last name
             *      - email
             *      - gpa  
             * FUNCTIONALITY
             * StudentRepository Methods. Specifically implementing the reposity pattern methods
             * Robust implementation of the serialization and deserialization. After every instance of the application the student data is serialized in
             * a different file. 
             * The StudentRepository Find, Delete and Update should use the latest serialized objects.Deserialized.  
             * How to add GradStudents and Undergrad with all their fields to the student repository ? Can I create relations with parent data file having details of  all students
             * while GradStudents and Undergrad store the student emails(foreign keys) and respective details in the classes and read them in the application context respectively.
            */

            string fileName = @"E:\Desktop\Csharp\SchoolDB\SchoolDB\schoolDBBackup.txt";
            IFormatter formatter = new BinaryFormatter();
            SerializeItem(fileName, formatter, studentRepository);
            Console.ReadKey();
        }

        public static void SerializeItem(string fileName, IFormatter formatter, StudentRepository studentRepository)
        {
            List<Student> students = studentRepository.Students;
            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, students);
            s.Close();
        }
    }
}
