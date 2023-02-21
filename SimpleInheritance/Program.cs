using System;

namespace Inheritance
{

    // base Class A
    class Animal
    {
        public string name;
        public string type;
        public string color;

        // constructor
        public Animal()
        {
            name = "";
            type = "";
            color = "";
        }
        //parameterized constructor
        public Animal(string name, string type, string color)
        {
            this.name = name;
            this.type = type;
            this.color = color;
        }

        public void display()
        {
            Console.WriteLine("I am an animal");
        }

    }

    // derived class of Animal Class B
    class Cat : Animal
    {
        public double age;
        public double weight;

        // constructor
        public Cat()
            : base()  // calls the Animal class constructor
        {
            age = 0;
            weight = 0;
        }
        //parameterized constructor
        public Cat(string name, string type, string color, double age, double weight)
            : base(name, type, color)
        {
            this.age = age;
            this.weight = weight;
        }
        public void getName()
        {
            Console.WriteLine($"My name is {name}");
        }
        public void sound()
        {
            Console.WriteLine($"I like to meow");
        }
        public void getAge()
        {
            Console.WriteLine($"I am {age} years old");
        }
        public void getWeight()
        {
            Console.WriteLine($"I weigh {weight} pounds");
        }
    }
    class Bird : Animal
    {
        public double age;
        public double weight;

        // constructor
        public Bird()
            : base()  // calls the Animal class constructor
        {
            age = 0;
            weight = 0;
        }
        //parameterized constructor
        public Bird(string name, string type, string color, double age, double weight)
            : base(name, type, color)
        {
            this.age = age;
            this.weight = weight;
        }
        public void getName()
        {
            Console.WriteLine($"My name is {name}");
        }
        public void sound()
        {
            Console.WriteLine($"I like to tweet");
        }
        public void getAge()
        {
            Console.WriteLine($"I am {age} years old");
        }
        public void getWeight()
        {
            Console.WriteLine($"I weigh {weight} pounds");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat kitten = new Cat();

            kitten.name = "Angel";
            kitten.type = "Cat";
            kitten.color = "White";
            kitten.display();

            kitten.age = 0.5;
            kitten.weight = 2.0;
            kitten.getName();
            kitten.sound();
            kitten.getAge();
            kitten.getWeight();
            Console.WriteLine("______________________________________");

            Cat Whiskers = new Cat("Whiskers", "Cat", "Black", 4.5, 30);
            Whiskers.getName();
            Whiskers.sound();
            Whiskers.getAge();
            Whiskers.getWeight();
            Console.WriteLine("______________________________________");

            Bird parrot = new Bird();

            parrot.name = "Tweety";
            parrot.type = "Parrot";
            parrot.color = "Blue";

            parrot.age = 1.0;
            parrot.weight = 1.0;
            parrot.getName();
            parrot.sound();
            parrot.getAge();
            parrot.getWeight();
            Console.WriteLine("______________________________________");

            Bird Daffy = new Bird("Daffy", "Duck", "Black", 84, 4.5);
            Daffy.getName();
            Daffy.sound();
            Daffy.getAge();
            Daffy.getWeight();
            Console.WriteLine("______________________________________");
            Console.ReadLine(); // pauses end of program display
        }

    }
}