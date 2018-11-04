using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ShaneAnderson_B8IT117
{
    //Staff Class (should inherit the functionality of base class Person)
    //Create a class Staff that inherits from Person with an attribute of Id, Salary

    //Plan
    //Staff Class 
    //Declare Variablels
    //Constructors
    //Auto Implemented Properties
    //Method
    //ToString() overide
    //Staff Id validation

    //Person
    //Id
    //Salary
    public abstract class Staff : Person

    {
        //variables
        private string _staffId;
        private decimal _salary;



        //autoimplemented properties
        public string StaffId
        {
            get => _staffId;
            set
            {
                if (value.StartsWith("L") && value.Length == 4)
                {
                    _staffId = value;
                }
                else throw new ArgumentOutOfRangeException($"Invalid Staff Number");
            }
        }

        public decimal Salary
        {
            get => _salary;
            set
            {    //Validates whether Salary is within that range otherwise a exception is thrown
                if (value >= 40000m && value <= 90000m)
                {
                    _salary = value;
                }
                else throw new ArgumentOutOfRangeException($"Invalid Salary");

            }
        }

        //constructors
        public Staff() { }

        public Staff(string name, string pps, string address, string phone, string email, string staffId, decimal salary)
            : base(name, pps, address, phone, email)
        {
            _staffId = staffId;
            _salary = salary;
        }


        public override string ToString()
        {

            return base.ToString() + $"\nStaffId: {StaffId} \nSalary: {Salary}";

        }


    }
}
