using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.IO;

namespace SchoolDB
{
    public interface IStudentRepository : IRepository<Student>, ISerializable
    {

    }
    public class StudentRepository : IStudentRepository
    {
        private FileInfo studentFile;
        private StreamReader reader;
        private List<Student> students;

        public StudentRepository(FileInfo studentFile)
        {
            if (!studentFile.Exists)
                throw new FileNotFoundException("No Student Records Found");
            this.studentFile = studentFile;
        }

        public List<Student> Students => (List<Student>)this.GetAll();
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            this.reader = new StreamReader(this.studentFile.FullName);
            this.students = new List<Student>();

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var columns = line.Split('\t');
                Student student = new Student()
                {
                    FirstName = columns[1],
                    LastName = columns[2],
                    EmailAddress = columns[3],
                    Gpa = double.Parse(columns[4])
                };
                this.students.Add(student);
            }
            return this.students;
        }

        public Student GetByKey(string  emailAddress)
        {
            throw new NotImplementedException();
        }

        public void Create(Student entity)
        {
            this.GetAll();
            this.students.Add(entity);
        }

        public void Delete(Student entity)
        {
            this.GetAll();
            this.students.Remove(entity);
        }

        public void Delete(string emailAddress)
        {
            this.GetAll();
        }

        public void UpDate(Student entity)
        {
            ;
        }
        // Use serialization to backup the database
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Student Data", Students, typeof(string));
        }
    }
}