using System;

namespace AnimalInheritance
{
    // base Class 
    class Animal
    {
        private string name; // only accessible within this class
        protected string type; //accessible from derived classes
        public string color;  // accessible from any class

        public void setName(string name)
        {
            this.name = name;
        }
        public virtual string getName()
        {
            return this.name;
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public virtual string getType()
        {
            return this.type;
        }
    }

    // derived class 
    class Cat : Animal
    {
        public string breed;  // accessible from any class
        protected int age;  //accessible from derived classes

        public void setAge(int age)
        {
            this.age = age;
        }
        public virtual int getAge()
        {
            return age;
        }

        // access name through base because it is private
        public override string getName()
        {
            return base.getName();
        }

        // access type directly because it is protected and this is a derived class
        public override string getType()
        {
            return type;
        }

        public virtual string sound()
        {
            return "meow a lot";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            // object of the base class Animal
            Animal critter = new Animal();
            critter.setName("Daffy");
            critter.setType("duck");
            // color is a public field and can be accessed anywhere
            critter.color = "black";

            Console.WriteLine("Animal Information...");
            Console.WriteLine($"My name is {critter.getName()}");
            Console.WriteLine($"I am a {critter.getType()}");
            Console.WriteLine($"I am a lovely {critter.color} color");
            Console.WriteLine();

            // object of derived class Cat
            Cat kitten = new Cat();
            kitten.setName("Oreo");
            kitten.setType("cat");
            // color is a public field and can be accessed anywhere
            kitten.color = "black and white";
            // breed is a public field
            kitten.breed = "Siamese";
            // age is a protected field
            kitten.setAge(1);

            Console.WriteLine("Cat Information...");
            Console.WriteLine($"My name is {kitten.getName()}");
            Console.WriteLine($"I am a {kitten.breed} {kitten.getType()}");
            Console.WriteLine($"I am a lovely {kitten.color} color");
            Console.WriteLine($"I am {kitten.getAge()} years old");
            Console.WriteLine($"I like to {kitten.sound()}");

            Console.ReadLine(); // pauses end of program display
        }

    }
}