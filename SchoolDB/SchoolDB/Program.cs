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

            // List<Student> students = studentRepository.Students;
            string fileName = @"E:\Desktop\Csharp\SchoolDB\SchoolDB\schoolDBBackup.txt";
            IFormatter formatter = new BinaryFormatter();
            Program.SerializeItem(fileName, formatter, studentRepository);
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
