using System;
internal class Program
{

    static void FindWord(ref string v, ref string temp)
    {
        string b = "";
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == ' ')
            {
                v = v.Remove(i, 1);
                break;
            }
            else
            {
                b += v[i];
                v = v.Remove(i, 1);
                i--;
            }
        }
        temp= b;
    }
    class Engine
    {
        private double speed;
        private double power;

        public void SetEngine(double speed, double power)
        {
            this.speed = speed;
            this.power = power;
        }

        public void GetEngine()
        {
            Console.Write(speed +" "+power+" ");
        }
        public double GetPower()
        {
            return power;
        }
    }   
    class Cargo
    {
        private string CargoType;
        private double CargoWeight;
        public void SetCargo(string CargoType, double CargoWeight)
        {
            this.CargoType = CargoType;
            this.CargoWeight = CargoWeight;
        }
        public void GetCargo()
        {
            Console.Write(CargoType+" "+CargoWeight+" ");
        }

        public string GetType()
        {
            return CargoType;
        }
    }
    class Tire
    {
        private double[] TireAge=new double[4];
        private double[] TirePressure=new double[4];

        private double avarage;

        public void SetTire(int k, double age, double pressure)
        {
            TireAge[k] = age;
            TirePressure[k] = pressure;
        }
        public void GetTire()
        {
            for(int i = 0; i != 4; i++)
            {
                Console.Write(TireAge[i]+" " + TirePressure[i]+" ");
            }
        }

        public double GetAvarageTire()
        {
            for(int i = 0; i != 4; i++)
            {
                avarage+=TirePressure[i];
            }
            avarage /= 4.00;
            return avarage;
        }
    }
    class Car
    {
        private string name;

        Engine engine=new Engine();
        Cargo cargo = new Cargo();
        Tire tire = new Tire();

        public void SetCar(string a) {
            string temp = "";
            
            FindWord(ref a, ref temp);

            name = temp;

            FindWord(ref a, ref temp);
            double sp = double.Parse(temp);

            FindWord(ref a, ref temp);
            double pw= double.Parse(temp);

            engine.SetEngine(sp, pw);

            FindWord(ref a, ref temp);
            double t2 = double.Parse(temp);
            FindWord(ref a, ref temp);
            string t1 = temp;

            cargo.SetCargo(t1,t2);

            for(int i = 0; i != 4; i++)
            {
                double age;
                double pressure;
                FindWord(ref a, ref temp);
                pressure = double.Parse(temp);
                FindWord(ref a, ref temp);
                age = double.Parse(temp);
                tire.SetTire(i, age, pressure);

            }


        }
        public void GetCar()
        {
            Console.Write(name+" ");
            engine.GetEngine();
            cargo.GetCargo();
            tire.GetTire();
        }
        
        public void GetName()
        {
            Console.WriteLine(name);
        }
        public string GetCargoType()
        {
            return cargo.GetType();
        }

        public double GetAvTire()
        {
            return tire.GetAvarageTire();
        }

        public double GetPw()
        {
            return engine.GetPower();
        }
    }
    static void Main()
    {
        Console.WriteLine("Vvedit kilkist avtomobilei: ");
        int k = int.Parse(Console.ReadLine());
        Car[] a = new Car[k];
        Console.WriteLine();

        for (int i = 0; i != k; i++)
        {
            Console.Write("Vvedit ["+(i+1)+"] mashuny: ");
            a[i] = new Car();
            string b = Console.ReadLine();

            a[i].SetCar(b);
            Console.WriteLine();
        }
        string cr = Console.ReadLine();

        for (int i = 0; i != k; i++)
        {
            if (cr == "Fragile" || cr == "fragile")
            {
                if (cr == a[i].GetCargoType() && a[i].GetAvTire() < 1)
                {
                    a[i].GetName();
                    Console.WriteLine();
                }
            }
            else if (cr == "Flamable" || cr == "flamable")
            {
                if (cr == a[i].GetCargoType() && a[i].GetPw() > 250)
                {
                    a[i].GetName();
                    Console.WriteLine();
                }
            }
        }

    }
}
