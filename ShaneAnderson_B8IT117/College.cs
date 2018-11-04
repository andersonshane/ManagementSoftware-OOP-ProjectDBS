using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ShaneAnderson_B8IT117
{
    //College Class (this is the entry point to the programme)



    //At least one implementation of an overridden ToString() method.
    //Demonstration of the development and use of one more overridden 
    //Demonstrate the use of overloading(other than constructor overloading)


    //Plan
    //College Class try (do, while) catch switch statement may be more selective than else and if 


    //Methods are required
    //Student & Lecturer Addition
    //Illustrate Student & Lecturer
    //Method Overload
    //Method OVeride - completely replace method defined further up in the hierarchy
    //Nested if statements
    class College
    {
        //Student & Lecturer Objects
        public static Students Students = new Students();
        public static Lecturers Lecturers = new Lecturers();


        private static void Main(string[] args)
        {
            try
            {
                //Declare Variables
                int select;

                var end = true;


                do
                {
                    //menu
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.WriteLine("Select");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("1. To add a Student");
                    Console.WriteLine("2. To remove a Student");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("3. To add a Lecturer");
                    Console.WriteLine("4. To remove a Lecturer");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("5. Illustrate details of all Students");
                    Console.WriteLine("6. Illustrate the names of all Lecturers");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("7. To find a Student via Student Number");
                    Console.WriteLine("8. To find a Lecturer via staffId");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("9. To quit");
                    Console.WriteLine("--------------------------------------------");

                    int.TryParse(Console.ReadLine(), out select);

                    switch (select)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Enter Student Number (Starts with S followed by three numbers)");
                            var studentid = Console.ReadLine();
                            Console.WriteLine(Students.Remove(studentid) ? "***Student removed***" : "***Student not removed***");
                            break;
                        case 3:
                            AddLecturer();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Enter Lecturer id (Starts with L followed by three numbers)");
                            var lecturerid = Console.ReadLine();
                            Console.WriteLine(Lecturers.Remove(lecturerid)
                                ? "***Lecturer removed***"
                                : "***Lecturer not removed***");
                            break;
                        case 5:
                            ShowStudents();
                            break;
                        case 6:
                            ShowLecturers();
                            break;
                        case 7:


                            Console.WriteLine("Enter Student Number");
                            var number = Console.ReadLine();
                            if (Students.Contains(number))
                            {
                                Console.WriteLine(
                                    "Student Present, press R to see student details or Any other key to exit");
                                // Nested if to illustrate details
                                if (Console.ReadLine() == "R")
                                    ShowStudents(number);
                                else
                                    break;
                            }
                            else
                            {
                                Console.WriteLine("Student not Present");
                            }

                            break;
                        case 8:


                            Console.WriteLine("Enter Lecturer Number");
                            var lecturernumber = Console.ReadLine();
                            if (Lecturers.Contains(lecturernumber))
                            {
                                Console.WriteLine(
                                    "Lecturer found, press R to see lecturer details or any Keys to exit");
                                // Nested if to illustrate details
                                if (Console.ReadLine() == "R")
                                    ShowLecturers(lecturernumber);
                                else
                                    break;
                            }
                            else
                            {
                                Console.WriteLine("Lecturer not present");
                            }

                            break;

                        case 9:
                            end = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                } while (end);
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press Any key to exit....");
            Console.ReadKey();
        }

        #region Add Methods

        public static void AddStudent()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var student = new Student();
            Console.WriteLine("Enter Student Number (Starts with S followed by three numbers)");
            student.StudentNumber = Console.ReadLine();
            Console.WriteLine("Enter Name");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter PPS Number (Lenght 7 - ends with N)");
            student.Pps = Console.ReadLine();
            Console.WriteLine("Enter Student Status (Postgraduate or Undergraduate)");
            student.Type = (Student.Studentstatus)Enum.Parse(typeof(Studentstatus), Console.ReadLine());
            Console.WriteLine("Enter address:");
            student.Address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            student.Phone = Console.ReadLine();
            Console.WriteLine("Enter Email ( eg. shane.lecturer@dbs.com )");
            student.Email = Console.ReadLine();


            Students.Add(student);
        }


        public static void AddLecturer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var lecturer = new Lecturer();
            Console.WriteLine("Enter Lecturer ID (Starts with L followed by 3 numbers)");
            lecturer.StaffId = Console.ReadLine();
            Console.WriteLine("Enter Name");
            lecturer.Name = Console.ReadLine();
            Console.WriteLine("Enter PPS Number (Lenght 7 - ends with N)");
            lecturer.Pps = Console.ReadLine();
            Console.WriteLine("Enter Subject Taught (Less than 20 words)");
            lecturer.SubjectTaught = Console.ReadLine();
            Console.WriteLine("Enter Subject Area (Less than 20 words)");
            lecturer.SubjectArea = Console.ReadLine();
            Console.WriteLine("Enter Salary (more or equal than 40000 and less or equal than 90000)");
            lecturer.Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter address:");
            lecturer.Address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            lecturer.Phone = Console.ReadLine();
            Console.WriteLine("Enter Email ( eg. shane.student@dbs.com )");
            lecturer.Email = Console.ReadLine();


            Lecturers.Add(lecturer);
        }

        #endregion

        #region ShowAll Students/Lecturers methods with Overloading

        public static void ShowStudents()
        {
            foreach (var i in Students) Console.WriteLine(i);
        }

        //Method Overloaded
        public static void ShowStudents(string number)
        {
            foreach (var i in Students)
                if (i.StudentNumber == number)
                    Console.WriteLine(i);
        }

        public static void ShowLecturers()
        {
            foreach (var i in Lecturers) Console.WriteLine(i.Name);
        }

        //Method Overloaded
        public static void ShowLecturers(string number)
        {
            {
                foreach (var i in Lecturers)
                    if (i.StaffId == number)
                        Console.WriteLine(i);
            }

            #endregion
        }
    }

}

