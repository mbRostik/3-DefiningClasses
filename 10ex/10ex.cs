using System;
internal class Program
{
    class Engine
    {
        private string name;
        private double power;
        private double volume=0;
        private double potency=0;

        public void SetEngine()
        {
            Console.WriteLine("Vvedit name engina: ");
            name=Console.ReadLine();
            Console.WriteLine("\nVvedit power: ");
            power = Double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Vvedit volume ( vvedit bykvu esli nema): ");
            try
            {
                volume = Double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Volume = n/a");
                Console.WriteLine();
            }

            Console.WriteLine("Vvedit potency ( vvedit bykvu esli nema): ");
            try
            {
                potency = Double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Potency = n/a");
                Console.WriteLine();
            }
        }

        public string GetEngineName()
        {
            return name;
        }

        public void GetEngine()
        {
            Console.WriteLine(" "+name+":");
            Console.WriteLine("  Power: "+power);
            if (volume == 0)
            {
                Console.WriteLine("  Volume: n/a");
            }
            else
            {
                Console.WriteLine("  Volume: " + volume);
            }
            if (potency == 0)
            {
                Console.WriteLine("  Potency: n/a");
            }
            else
            {
                Console.WriteLine("  Potency: " + potency);
            }

        }

    }
    class Car
    {
        private Engine engine;
        private string name;
        private double weight=0;
        private string color = "n/a";

        public void SetCarEngine(Engine engine)
        {
            this.engine = engine;
        }
        public void SetCarName()
        {
            Console.WriteLine("Vvedit name mashunu: ");
            name = Console.ReadLine();
            Console.WriteLine();
        }
        public void SetEvrCar()
        {
            Console.WriteLine("Vvedit weight mashunu ( vvedit bykvu esli nema): ");
            try
            {
                weight = Double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Weight = n/a");
                Console.WriteLine();
            }

            Console.WriteLine("Vvedit color mashunu ( ' - ' esli nety): ");
            color = Console.ReadLine();
            if (color == "-")
            {
                color = "n/a";
            }

        }

        public void GetCar()
        {
            Console.WriteLine(name+": ");
            engine.GetEngine();
            if (weight == 0)
            {
                Console.WriteLine(" Weight: n/a");
            }
            else
            {
                Console.WriteLine(" Weight: " + weight);
            }
            Console.WriteLine(" "+color);
            Console.WriteLine();

        }
    }
    static void Main()
    {
        Console.WriteLine("Vvedit kilkist dvugynov: ");
        int kd = int.Parse(Console.ReadLine());

        Engine[] engine = new Engine[kd];

        for(int i = 0; i != kd; i++)
        {
            Console.WriteLine("["+(i+1)+"] dvugyn: ");
            engine[i] = new Engine();
            engine[i].SetEngine();
        }

        Console.WriteLine("Vvedit kilkist cars: ");
        kd = int.Parse(Console.ReadLine());

        Car[] car=new Car[kd];
        for(int i = 0; i != kd; i++)
        {
            car[i] = new Car();
            Console.WriteLine("["+(i+1)+"] mashuna: ");
            car[i].SetCarName();
            Console.WriteLine("Vvedit dvugyn: ");
            string b = Console.ReadLine();
            int temp = 0;
            for(int y = 0; y != engine.Length; y++)
            {
                if (b == engine[y].GetEngineName())
                {
                    temp++;
                    car[i].SetCarEngine(engine[y]);
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("\nNe znaideno dvugyn, byde vstanovleno pershui po ymol4aniy! \n");
                car[i].SetCarEngine(engine[0]);
            }
            car[i].SetEvrCar();
        }
        Console.WriteLine("\n\n\n");

        for(int i = 0; i != car.Length; i++)
        {
            car[i].GetCar();
        }
    }
}
