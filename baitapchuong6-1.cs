using System;
using System.IO;

namespace FileManipulation
{
    class Program
    {
        // Khai báo biến chuỗi không đổi
        private const string FilePath = "data.txt";

        static void Main(string[] args)
        {
            // Tạo tệp mới
            CreateFile(FilePath);
            Console.WriteLine("File created.");

            // Ghi vào tệp
            WriteToFile(FilePath, "This is the initial content.");
            Console.WriteLine("Content written to file.");

            // Đọc từ tệp
            ReadFromFile(FilePath);

            // Nối vào tệp
            AppendToFile(FilePath, " This is appended content.");
            Console.WriteLine("Content appended to file.");

            // Đọc lại từ tệp
            ReadFromFile(FilePath);

            // Xóa tệp
            DeleteFile(FilePath);
            Console.WriteLine("File deleted.");

            Console.ReadLine();
        }

        static void CreateFile(string filePath)
        {
            // Tạo một tệp mới tại filePath được chỉ định
            using (FileStream fs = File.Create(filePath))
            {
                // Đóng tệp ngay sau khi tạo
                fs.Close();
            }
        }

        static void WriteToFile(string filePath, string content)
        {
            // Ghi nội dung vào filePath được chỉ định
            File.WriteAllText(filePath, content);
        }

        static void ReadFromFile(string filePath)
        {
            // Đọc nội dung của tệp tại filePath được chỉ định
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Content of the file:");
            Console.WriteLine(content);
        }

        static void AppendToFile(string filePath, string content)
        {
            // Nối nội dung vào filePath được chỉ định
            File.AppendAllText(filePath, content);
        }

        static void DeleteFile(string filePath)
        {
            // Xóa tệp tại filePath được chỉ định
            File.Delete(filePath);
        }
    }
}