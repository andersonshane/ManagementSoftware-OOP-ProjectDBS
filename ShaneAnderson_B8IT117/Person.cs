using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShaneAnderson_B8IT117
{
    //Plan
    //Person Class with attributes pps, Name, Address, Phone & Email
    //Declare Variables
    //Constructors 
    //Auto Implemented Properties - Get & Set
    //Overide tostring for each entity class - helpful when debugging
    //ToString Method - Public overide string ToString()
    //Email & Phone Number Validation

    public class Person
    {
        //variables

        private string _pps;
        private string _name;
        private string _address;
        private string _phone;
        private string _email;
        private bool _validate = false;



        // Autoimplemented properties

        //Expression Bodied properties can be created via the lamda operator => to minimise lines of code
        //Used as syntax shortcut, read only properties, immediately return a value
        //you can implement the get accessor as an expression-bodied member providing there are no "If functions required etc"
        public string Pps
        {
            get => _pps;

            set //pps generally is 7 Numbers & followed by a letter
            {

                if (value.Length == 8 && value.EndsWith("N"))

                {
                    _pps = value;

                }

                else throw new ArgumentOutOfRangeException($"Please enter a valid pps number to continue your good time! :)");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.All(char.IsLetter))
                {

                    _name = value;

                }
                else throw new ArgumentOutOfRangeException($"Please enter a valid Name to continue your good time! :)");
            }
        }
        //Auto Property for Address
        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (value.All(char.IsDigit))
                {
                    _phone = value;
                }
                else throw new ArgumentException($"Please enter a valid phone number to continue your good time! :)");
            }
        }

        public string Email
        {
            get => _email;

            set
            {
                if (Validate(value))
                {

                    _email = value;

                }
                else throw new ArgumentException("Please enter a valid Email to continue your good time! :)");
            }
        }

        //Constructors

        public Person() { }


        public Person(string pps, string name, string address, string phone, string email)
        {
            _pps = pps;
            _name = name;
            _address = address;
            _phone = phone;
            _email = email;

        }

        public override string ToString()
        {
            //String Interpolation
            return $"\nName: {Name} \nPPS: {Pps} \nAddress:{Address} \nPhone:{Phone} \nEmail: {Email}";

        }

        #region Validate Email Method 
        //Email validation found on rextester.com/
        public bool Validate(string strIn)
        {
            _validate = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (_validate)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                _validate = true;
            }
            return match.Groups[1].Value + domainName;
        }
        #endregion
    }
}