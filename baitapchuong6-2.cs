using System;
using System.Collections.Generic;
using System.IO;

namespace CsvManipulation
{
    class BTChuong6_2
    {
        static void Main(string[] args)
        {
            string filePath = @"students.csv";
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "John Doe", Age = 20, Grade = 3.5 },
                new Student { Id = 2, Name = "Jane Smith", Age = 22, Grade = 3.8 }
            };

            // Ghi danh sách sinh viên vào tệp CSV
            WriteStudentsToCsv(filePath, students);
            Console.WriteLine("Students written to CSV file.");

            // Đọc danh sách sinh viên từ tệp CSV
            List<Student> readStudents = ReadStudentsFromCsv(filePath);
            Console.WriteLine("Students read from CSV file:");

            foreach (var student in readStudents)
            {
                Console.WriteLine($"{student.Id}, {student.Name}, {student.Age}, {student.Grade}");
            }
        }

        public static void WriteStudentsToCsv(string filePath, List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,Name,Age,Grade");
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Id},{student.Name},{student.Age},{student.Grade}");
                }
            }
        }

        public static List<Student> ReadStudentsFromCsv(string filePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                // Bỏ qua dòng tiêu đề
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    Student student = new Student
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1],
                        Age = int.Parse(values[2]),
                        Grade = double.Parse(values[3])
                    };
                    students.Add(student);
                }
            }

            return students;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }
}
