using System;
using System.ComponentModel.Design;
using System.Reflection;

namespace Inheritance
{
    //Base Class
    class Members
    {
        private int _Id;
        private string _FirstName;
        private string _LastName;
        private int _Age;

        // default constructor
        public Members()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
        }
        //parameterized constructor
        public Members(int id, string firstName, string lastName, int age)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
        }
        // Get and Set Methods
        public int getID() { return _Id; }
        public string getFirstName() { return _FirstName; }
        public string getLastName() { return _LastName; }
        public int getAge() { return _Age; }
        public void setID(int id) { _Id = id; }
        public void setFirstName(string firstName) { _FirstName = firstName; }
        public void setLastName(string lastName) { _LastName = lastName; }
        public void setAge(int age) { _Age = age; }

        public virtual void addChange()
        {
            Console.Write("ID=");
            setID(int.Parse(Console.ReadLine()));
            Console.Write("First Name=");
            setFirstName(Console.ReadLine());
            Console.Write("Last Name=");
            setLastName(Console.ReadLine());
            Console.Write("Age=");
            setAge(int.Parse(Console.ReadLine()));
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      ID: {getID()}");
            Console.WriteLine($"    Name: {getFirstName()} {getLastName()}");
            Console.WriteLine($"     Age: {getAge()}");
        }
    }
    class Leader : Members
    {
        private double _Salary;
        private string _Location;

        public Leader()
            : base()
        {
            _Location = string.Empty;
            _Salary = 0;
        }
        public Leader(int id, string firstname, string lastname, int age, double salary, string location)
            : base(id, firstname, lastname, age)
        {
            _Salary = salary;
            _Location = location;
        }
        public void setSalary(double salary) { _Salary = salary; }
        public void setLocation(string location) { _Location = location; }
        public double getSalary() { return _Salary; }
        public string getLocation() { return _Location; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Salary=");
            setSalary(double.Parse(Console.ReadLine()));
            Console.Write("Location=");
            setLocation(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Salary: {getSalary()}");
            Console.WriteLine($"Location: {getLocation()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many members do you want to enter?");
            int maxEmps;
            while (!int.TryParse(Console.ReadLine(), out maxEmps))
                Console.WriteLine("Please enter a whole number");
            // array of Employee objects
            Members[] emps = new Members[maxEmps];
            Console.WriteLine("How many leaders do you want to enter?");
            int maxMgr;
            while (!int.TryParse(Console.ReadLine(), out maxMgr))
                Console.WriteLine("Please enter a whole number");
            // array of Manager objects
            Members[] mgr = new Members[maxMgr];

            int choice, rec, type;
            int empCounter = 0, mgrCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Leader or 2 for Member");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Leader or 2 for Member");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //Manager
                            {
                                if (mgrCounter <= maxMgr)
                                {
                                    mgr[mgrCounter] = new Leader(); // places an object in the array instead of null
                                    mgr[mgrCounter].addChange();
                                    mgrCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of leaders has been added");

                            }
                            else //Employee
                            {
                                if (empCounter <= maxEmps)
                                {
                                    emps[empCounter] = new Members(); // places an object in the array instead of null
                                    emps[empCounter].addChange();
                                    empCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of leaders has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //Manager
                            {
                                while (rec > mgrCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mgr[rec].addChange();
                            }
                            else // Employee
                            {
                                while (rec > empCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                emps[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //Manager
                            {
                                for (int i = 0; i < mgrCounter; i++)
                                    mgr[i].print();
                            }
                            else // Employee
                            {
                                for (int i = 0; i < empCounter; i++)
                                    emps[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}