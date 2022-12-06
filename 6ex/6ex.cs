using System;

public class Program
{
    class Person
    {
        private string name;
        private string email;
        private int age;
        private int salary;
        private int department;

        //public Employee(string name, int salary, int department)
        //{
        //    this.name = name;
        //    this.salary = salary;
        //    this.department = department;
        //    age = -1;
        //    email = "n/a";
        //}
        //public Employee(string name, int salary, int department, int age)
        //{
        //    this.name = name;
        //    this.salary = salary;
        //    this.department = department;
        //    this.age = age;
        //    email = "n/a";
        //}
        //public Employee(string name, int salary, int department, int age, string email)
        //{
        //    this.name = name;
        //    this.salary = salary;
        //    this.department = department;
        //    this.age = age;
        //    this.email = email;
        //}


        public void GetPerson()
        {
            Console.WriteLine("Name personu: " + name + ", age personu: " + age + ", Department: " + department + "; Email: " + email + "; Salary: " + salary);
        }
        public void SetPerson()
        {
            Console.WriteLine("Vvedit name: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Vvedit salary: ");
            salary = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Vvedit department: ");
            department = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Vvedit age (esli nety, vvedit bykvu)");
            string v = (Console.ReadLine());
            try
            {
                age = int.Parse(v);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Age = -1");
                age = -1;
                Console.WriteLine();
            }
            Console.WriteLine("Vvedit email (esli nety, vvedit " + "'nety'" + " ):");
            email = Console.ReadLine();
            Console.WriteLine();
            if (email == "nety")
            {
                email = "n/a";
                Console.WriteLine();
            }
        }

        public int GetSalary()
        {
            return salary;
        }

        public int GetDepartment()
        {
            return department;
        }

    }

    class Employee
    {
        Person[] a;

        public Employee(int k)
        {
            a = new Person[k];
        }

        public void SetAllEmployee(ref int koldep)
        {
            for (int i = 0; i != a.Length; i++)
            {
                Console.WriteLine("Vvedit " + "[" + (i + 1) + "] rabotnika: ");

                a[i] = new Person();

                a[i].SetPerson();

                Console.WriteLine();
            }

            for (int i = 0; i != a.Length; i++)
            {
                int h = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (a[i].GetDepartment() == a[j].GetDepartment())
                    {
                        h++;
                    }
                }
                if (h == 0)
                {
                    koldep++;
                }
            }

        }

        public void ZapDep(ref float[,] zapdep)
        {
            int f = 0;
            for (int i = 0; i != a.Length; i++)
            {
                int h = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (a[i].GetDepartment() == a[j].GetDepartment())
                    {
                        h++;
                    }
                }
                if (h == 0)
                {
                    zapdep[0, f] = a[i].GetDepartment();
                    f++;
                }
            }

            for(int i = 0; i != f; i++)
            {
                for(int y = 0; y != a.Length; y++)
                {
                    if (zapdep[0, i] == a[y].GetDepartment())
                    {
                        zapdep[1, i] += a[y].GetSalary();
                    }
                }
            }

            for (int i = 0; i != f; i++)
            {
                int b = 0;
                for (int y = 0; y != a.Length; y++)
                {
                    if (zapdep[0, i] == a[y].GetDepartment())
                    {
                        b++;
                    }
                }
                zapdep[1, i] /= b;
            }

        }

        public void Height(float g)
        {
            for(int i = 0; i != a.Length; i++)
            {
                if (a[i].GetDepartment() == g)
                {
                    a[i].GetPerson();
                    Console.WriteLine();
                }
            }
        }
    }


    public static void Main()
    {
        Console.WriteLine("Vvedit kol rabotnikov: ");
        int k = int.Parse(Console.ReadLine());

        Employee aa = new Employee(k);
        int d = 0;

        aa.SetAllEmployee(ref d);


        Console.WriteLine(d);
        float[,] zapdep = new float[2, d];

        aa.ZapDep(ref zapdep);

        float max = zapdep[1, 0];
        float g = zapdep[0,0];
        for (int i = 0; i != d; i++)
        {
            if (zapdep[1, i] > max)
            {
                max = zapdep[1, i];
                g = zapdep[0, i];
            }
        }

        Console.WriteLine();
        Console.WriteLine();


        Console.WriteLine("Highest department: " + g);
        Console.WriteLine();
        aa.Height(g);


    }
}