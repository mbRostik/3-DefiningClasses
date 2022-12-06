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

        public int GetAge()
        {
            return age;
        }

    }

    class Family
    {
        Person[] a;

        public Family(int k)
        {
            a = new Person[k];
        } 

        public void SetFamily ()
        {
            for(int i = 0; i != a.Length; i++)
            {
                Console.WriteLine();
                Person temp = new Person();
                Console.WriteLine("["+(i+1)+"] 4len family;");
                temp.SetPerson();
                a[i] = temp;
            }
        }

        public void FindOldest()
        {
            Console.WriteLine();
            Person temp = a[0];
            for(int i = 0; i != a.Length; i++)
            {
                if (temp.GetAge() < a[i].GetAge())
                {
                    temp = a[i];
                }
            }
            Console.WriteLine("Stareishui: ");
            temp.GetPerson();
        }

    }
    static void Main()
    {
        Console.WriteLine("Vvedit kilkist 4lenov family: ");
        Family family = new Family(int.Parse(Console.ReadLine()));

        family.SetFamily();

        family.FindOldest();
    }
}
