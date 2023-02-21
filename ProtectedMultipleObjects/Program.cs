using System;
using System.ComponentModel.Design;
using System.Reflection;

namespace Inheritance
{
    //Base Class
    class Members
    {
        protected int _Id;
        protected string _FirstName;
        protected string _LastName;
        protected int _Age;

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

        public virtual void addChange()
        {
            Console.Write($"ID=");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName = Console.ReadLine();
            Console.Write("Age=");
            _Age = int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      ID: {_Id}");
            Console.WriteLine($"    Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}");
        }
    }
    class Leader : Members
    {
        protected double _Salary;
        protected string _Location;

        public Leader()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
            _Location = string.Empty;
            _Salary = 0;
        }
        public Leader(int id, string firstname, string lastname, int age, double salary, string location)
        {
            _Id = id;
            _FirstName = firstname;
            _LastName = lastname;
            _Age = age;
            _Salary = salary;
            _Location = location;
        }

        public override void addChange()
        {
            Console.WriteLine("Club Leader Information");
            Console.Write($"ID=");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName = Console.ReadLine();
            Console.Write("Age=");
            _Age = int.Parse(Console.ReadLine());
            Console.Write("Salary=");
            _Salary = double.Parse(Console.ReadLine());
            Console.Write("Location=");
            _Location = Console.ReadLine();
        }
        public override void print()
        {
            Console.WriteLine();
            Console.WriteLine("      Leaders          ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"     ID: {_Id}     Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}   Salary: {_Salary}");
            Console.WriteLine($"     Location: {_Location}");
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
                                    Console.WriteLine("The maximum number of Leaders has been added");

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
                                    Console.WriteLine("The maximum number of Members has been added");
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
                            else
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
