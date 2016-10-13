using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTask
{
    public class Person
    {
        private string lastname;
        private DateTime dateofbirth;
        private uint height;
        public Person(string LastName,uint Height, DateTime DateOfBirth)
        {
            this.dateofbirth = DateOfBirth;
            this.lastname = LastName;
            this.height = Height;
        }
        public string LastName {
            get { return lastname; }
            set { lastname = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }
        public uint Height
        {
            get { return height; }
            set { height = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
