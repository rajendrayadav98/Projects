 using System;
using System.Collections.Generic;

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Class { get; set; }
    public double Marks { get; set; }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search by ID");
            Console.WriteLine("4. Delete by ID");
            Console.WriteLine("5. Sort by Marks");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: AddStudent(); break;
                case 2: ViewStudents(); break;
                case 3: SearchStudent(); break;
                case 4: DeleteStudent(); break;
                case 5: SortStudents(); break;
                case 6: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid Choice!"); break;
            }

        } while (choice != 6);
    }

    static void AddStudent()
    {
        Student s = new Student();

        Console.Write("Enter ID: ");
        s.ID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        s.Name = Console.ReadLine();

        Console.Write("Enter Class: ");
        s.Class = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks: ");
        s.Marks = Convert.ToDouble(Console.ReadLine());

        students.Add(s);
        Console.WriteLine("✅ Student added successfully!");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\n--- All Students ---");
        if (students.Count == 0)
        {
            Console.WriteLine("No student records found.");
        }
        else
        {
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.ID}, Name: {s.Name}, Class: {s.Class}, Marks: {s.Marks}");
            }
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter ID to search: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var s = students.Find(stu => stu.ID == id);

        if (s != null)
            Console.WriteLine($"Found: Name = {s.Name}, Class = {s.Class}, Marks = {s.Marks}");
        else
            Console.WriteLine("❌ Student not found!");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var s = students.Find(stu => stu.ID == id);

        if (s != null)
        {
            students.Remove(s);
            Console.WriteLine("✅ Student deleted.");
        }
        else
        {
            Console.WriteLine("❌ Student not found!");
        }
    }

    static void SortStudents()
    {
        students.Sort((x, y) => y.Marks.CompareTo(x.Marks));
        Console.WriteLine("✅ Students sorted by marks (high to low).");
    }
}
