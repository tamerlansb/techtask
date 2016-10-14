using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTask
{
    [Serializable]
    public class Person 
    {
        private string lastname;
        private DateTime dateofbirth;
        private uint height;
        public Person(string LastName, DateTime DateOfBirth, uint Height)
        {
            this.dateofbirth = DateOfBirth;
            this.lastname = LastName;
            this.height = Height;
        }
        public Person(Person p)
        {
            this.dateofbirth = p.DateOfBirth;
            this.lastname = p.LastName;
            this.height = p.Height;
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
        public override string ToString()
        {
            return lastname + "\n   birthday:"+ dateofbirth.ToShortDateString() +"   height:" + height.ToString() ;
        }

    }
    class Program
    {
        static void Main(string[] argumnets)
        {
            DoubledLinkedList<Person> list = new DoubledLinkedList<Person>();
            string buff = Console.ReadLine();
            string[] args = buff.Split(' ');
            while (args[0] != "exit") {
                try {
                    if (args.Length < 1)
                    {

                    }
                    else if (args[0] == "print")
                    {
                        list.Print();
                    }
                    else if (args[0] == "reverseprint")
                    {
                        list.ReversePrint();
                    }
                    else if (args[0] == "deleteall")
                    {
                        list.ClearList();
                        Console.WriteLine("List cleared");
                    }
                    else if (args[0] == "sortbylastname")
                    {
                        list.SortByPred((Person x, Person y) => { return x.LastName.CompareTo(y.LastName); });
                    }
                    else if (args[0] == "deletefromback")
                    {
                        list.Pop();
                    }
                    else if (args[0] == "deletefromfront")
                    {
                        list.PopFront();
                    }
                    else if (args[0] == "isempty") {
                        Console.WriteLine("   {0}", list.isempty());
                    }
                    else if (args.Length > 1)
                    {
                        if (args[0] == "deletebyindex" && int.Parse(args[1]) >= 0)
                        {
                            list.RemoveByIndex(uint.Parse(args[1]));
                        }
                        else if (args[0] == "deleteallwithlastname")
                        {
                            list.RemoveByPredicate((Person x) => { return x.LastName == args[1]; });
                        }
                        else if (args[0] == "savetofile")
                        {
                            if (list.Save(args[1]))
                                Console.WriteLine("   Saved");
                            else Console.WriteLine("   Error");

                        }
                        else if (args[0] == "loadfromfile")
                        {
                            if (DoubledLinkedList<Person>.Load(args[1], ref list))
                                Console.WriteLine("   Loaded");
                            else Console.WriteLine("   Error");
                        }
                        else if (args[0] == "addback" && args.Length == 4)
                        {
                            list.Add(new Person(args[1], DateTime.Parse(args[2]), uint.Parse(args[3])));
                            Console.WriteLine("add sucsesful");
                        } else  if (args[0] == "addfront" && args.Length == 4)
                        {
                            list.AddFront(new Person(args[1], DateTime.Parse(args[2]), uint.Parse(args[3])));
                            Console.WriteLine("add sucsesful");
                        }
                        else if (args[0] == "addbyindex" && args.Length == 5)
                        {
                            list.AddByIndex(new Person(args[2], DateTime.Parse(args[3]), uint.Parse(args[4])), uint.Parse(args[1]));
                            Console.WriteLine("add sucsesful");
                        }
                        else
                        {
                            Console.WriteLine("InvalidCommand");
                        }
                    }
                    else
                    {
                        Console.WriteLine("InvalidCommand");
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                buff = Console.ReadLine();
                args = buff.Split(' ');
            } 
        }
    }
}
