using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Client
    {
        public string Surname;
        public string Name;
        public string MiddleName;
        public DateOnly DateOfBirth = new DateOnly();

        public Client(string surname, string name, string middleName, DateOnly dateOfBirth)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
        }
    }
}
