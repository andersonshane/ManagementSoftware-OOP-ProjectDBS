using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaneAnderson_B8IT117
{
    //Lecturer Class (Should inherit the functionality of base class Staff)
    //Create a class Lecturer which inherits from Staff with an attribute of SubjectArea and Subjects Taught (List)
    //You can include Teaching Experience/work experience (optional)
    //Create a constructor for Lecturer such that all attributes belonging to a Lecturer can be assigned via the constructor

    //Plan
    //Lecturer inherits Staff
    //ICollection<Lecturer> - Properties
    //Declare Variables
    //Remove Lecturer via Overloading
    public sealed class Lecturer : Staff

    {
        private string _subjectTaught;
        private string _subjectArea;
        

        public string SubjectTaught
        {
            get => _subjectTaught;

            set
            {
                if (value.Length > 0 && value.Length < 20)
                {

                    _subjectTaught = value;
                }
                else throw new ArgumentOutOfRangeException($"Invalid Subject Taught");
            }
        }

        public string SubjectArea
        {
            get => _subjectArea;

            set
            {
                if (value.Length > 0 && value.Length < 20)
                {

                    _subjectArea = value;
                }
                else throw new ArgumentOutOfRangeException($"Invalid Subject Taught");
            }
        }
        public string Level { set; get; }


        public Lecturer()
        {
        }

        public Lecturer(string name, string pps, string address, string phone, string email, string staffId,
            decimal salary, string subjectTaught)
            : base(name, pps, address, phone, email, staffId, salary)

        {
            _subjectTaught = subjectTaught;
            _subjectArea = SubjectArea;

        }



        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return base.ToString() +
                   $"\nSubjectTaught: {SubjectTaught}";

        }
    }
    public class Lecturers : ICollection<Lecturer>
    {

        private List<Lecturer> List { get; set; }
        int i;

        public Lecturers()
        {

            List = new List<Lecturer>();

        }


        #region interface properties
        public int Count { get; }

        public bool IsReadOnly => false;

        #endregion


        #region Methods



        // Method "Add" avoids lecturers with the staff ID
        public void Add(Lecturer item)
        {

            bool flag = false;

            if (List.Count == 0 && flag == false)
            {
                List.Add(item);
                Console.WriteLine("***Lecturer Added***");
            }
            else
            {
                for (i = 0; i < List.Count && !flag; i++)
                {
                    if (List[i].StaffId.Equals(item.StaffId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lecturer cannot be inserted - StaffID unavailable");

                        flag = true;
                    }
                }
                if (flag == false)
                {
                    List.Add(item);
                    Console.WriteLine("***Lecturer Added***");
                }
            }
        }
        public bool Remove(Lecturer item)
        {
            var remove = false;
            for (var i = 0; i < List.Count && !remove; i++)
            {
                if (List[i].StaffId != item.StaffId) continue;
                List.Remove(List[i]);
                remove = true;
            }

            return remove;
        }

        //Overloading Removal Method
        public bool Remove(string Staffid)
        {
            var remove = false;
            for (var i = 0; i < List.Count && !remove; i++)
            {
                if (List[i].StaffId == Staffid)
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

        public bool Contains(Lecturer item)
        {
            return List.Contains(item);
        }

        public bool Contains(string id)
        {
            var found = false;
            for (var i = 0; i < List.Count && !found; i++)
            {
                if (List[i].StaffId.Equals(id))
                    found = true;
            }

            return found;
        }


        public IEnumerator<Lecturer> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public void CopyTo(Lecturer[] array, int arrayIndex)
        {
            ((ICollection<Lecturer>)List).CopyTo(array, arrayIndex);
        }

        #endregion

    }
}
