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
            
        public void GetPerson()
        {
            Console.WriteLine("Name personu: "+name+", age personu: "+age);
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
        Person rost = new Person();
        rost.SetPerson();
        rost.GetPerson();
    }
}
