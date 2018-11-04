using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaneAnderson_B8IT117
{
    //Student Class (should inherit the functionality of base class Person)
    //A class Student which inherits from Person with attributes Status and StudentId. A student’s status can either be a Postgrad or an Undergrad
    //Create a constructor for Student such that all attributes belonging to a Student can be assigned via the constructor

    //ICollection<T>
    //Icollection<T> in the collection consists of IEnumerable<T> + count Contains(), Copying to sn Array,
    //Modifying the collection Add(), Remove(), Clear(), IsReadOnly



    //Plan
    //Students : ICollection<Student>
    //autoimplemented Properties - Student Number & Student Type
    //Constructors
    //Overloaded Constructor => public student : base
    //public overide ToString Method
    //Student Type - PostGraduate & Undergraduate
    //Remove Student via Overloading
    //Student number validation - Starts with a letter followed by digits
    //Polymorphism - Constructor overloading (2 constructors in one class)
    public sealed class Student : Person
    {
        private string _studentNumber;
        private Studentstatus _type;


        //autoimplemented properties
        public string StudentNumber
        {
            get => _studentNumber;

            set
            {
                if (value.StartsWith("S") && value.Length == 4)

                {
                    _studentNumber = value;

                }

                else throw new ArgumentOutOfRangeException($"Invalid Student Number");
            }

        }

        public enum Studentstatus
        {

            Postgraduate,

            Undergraduate


        }


        public Studentstatus Type
        {
            get => _type;
            set
            {

                if (value == Studentstatus.Postgraduate || value == Studentstatus.Undergraduate)
                {
                    _type = value;
                }
                else throw new ArgumentException("Please insert a valid student status");
            }
        }

        //Constructors
        public Student() { }

        public Student(string name, string pps, string address, string phone, string email, string studentNumber)
            : base(name, pps, address, phone, email)
        {

            _studentNumber = studentNumber;
            Pps = pps;
            Name = name;
            Address = Address;
            Phone = phone;
            Email = email;
        }

        //overloaded constructor
        public Student(string name, string pps, string address, string phone, string email, string studentNumber, Studentstatus type)
            : base(name, pps, address, phone, email)
        {

            StudentNumber = studentNumber;
            Pps = pps;
            Name = name;
            Address = Address;
            Phone = phone;
            Email = email;
            Type = type;

        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return base.ToString() + $"\nStudent Number: {StudentNumber}";

        }

    }
    //Student Status
    public enum Studentstatus
    {

        Postgraduate,

        Undergraduate


    }



    public class Students : ICollection<Student>
    {

        private List<Student> List { get; set; }
        int _i;

        public Students()
        {

            List = new List<Student>();

        }

        public int Count { get; }

        public bool IsReadOnly => false;


        #region 



        // Method "Add" avoids Students with the same Student Number
        public void Add(Student item)
        {

            bool flag = false;

            if (List.Count == 0 && flag == false)
            {
                List.Add(item);
                Console.WriteLine("***Student Added***");
            }
            else
            {
                for (_i = 0; _i < List.Count && !flag; _i++)
                {
                    if (List[_i].StudentNumber.Equals(item.StudentNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Student number has already been used");

                        flag = true;
                    }
                }
                if (flag == false)
                {
                    List.Add(item);
                    Console.WriteLine("***Student Added***");
                }
            }
        }


        public bool Remove(Student item)
        {
            bool remove = false;
            for (int i = 0; i < List.Count && !remove; i++)
            {
                if (List[i].StudentNumber == item.StudentNumber)
                {
                    List.Remove(List[i]);
                    remove = true;
                }
            }

            return remove;
        }

        //Overloading Removal Method
        public bool Remove(string studentnumber)
        {
            bool remove = false;
            for (int i = 0; i < List.Count && !remove; i++)
            {
                if (List[i].StudentNumber.ToString() == studentnumber.ToString())
                {
                    List.Remove(List[i]);
                    remove = true;
                }
            }

            return remove;
        }



        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(Student item)
        {
            return List.Contains(item);
        }

        public bool Contains(string id)
        {
            bool found = false;
            for (var i = 0; i < List.Count && !found; i++)
            {
                if (List[i].StudentNumber.Equals(id))
                    found = true;
            }

            return found;
        }


        public IEnumerator<Student> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }





        public void CopyTo(Student[] array, int arrayIndex)
        {
            ((ICollection<Student>)List).CopyTo(array, arrayIndex);
        }



        #endregion

    }
}
