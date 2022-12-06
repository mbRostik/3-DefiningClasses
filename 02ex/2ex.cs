using System;
internal class Program
{
    class Person
    {
        private string name;
        private int age;

        public Person()
        {
            name = "Noname";
            age = 0;
        }
        public Person(int age)
        {
            name = "Noname";
            this.age = age;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void GetPerson()
        {
            Console.WriteLine("Name personu: " + name + ", age personu: " + age);
        }
        public void SetPerson()
        {
            Console.WriteLine("Vvedit name: ");
            name = Console.ReadLine();
            Console.WriteLine("Vvedit age: ");
            age = int.Parse(Console.ReadLine());
        }

    }
    static void Main()
    {
        Person tu=new Person("fghj",18);
        tu.GetPerson();
    }
}
