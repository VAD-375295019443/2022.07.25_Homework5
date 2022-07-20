using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Client
    {
        public string? Surname;
        public string? Name;
        public string? MiddleName;
        public DateOnly DateOfBirth;

        public Client(string? Surname, string? Name, string? MiddleName, DateOnly DateOfBirth)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.DateOfBirth = DateOfBirth;
        }
    }
}
