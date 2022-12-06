using System;
internal class Program
{
    static string FindDrive(string a)
    {
        string b = "";

        for (int i = 0; i != a.Length; i++)
        {
            if (a[i] != ' ')
            {
                b += a[i];
            }
            else
            {
                break;
            }
        }
        return b;
    }

    static void FindModel(string b, Car[] a, ref int h)
    {
        h = -1;
        string temp = "";
        for (int i = 0; i != b.Length; i++)
        {
            if (b[i] == ' ')
            {
                for (int y = i + 1; y != a.Length; y++)
                {
                    if (b[y] != ' ')
                    {
                        temp += b[y];
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }
        }
        for (int i = 0; i != a.Length; i++)
        {
            if (temp == a[i].GetName())
            {
                h = i;
            }
        }
    }

    static void FindDistance(string b, ref double dis)
    {
        string h = "";
        for(int i = b.Length-1; i != -1; i--)
        {
            if(b[i] != ' ')
            {
                h += b[i];
            }
            else
            {
                break;
            }
        }
        string temp="";
        for(int i = h.Length-1; i != -1; i--)
        {
            temp += h[i];
        }
        dis = double.Parse(temp);

    }
    class Car
    {
        private string name = "Noname";
        private double famount = 0;
        private double fcons = 1;


        private string message = "";

        private double distance = 0;

        public void SetCar()
        {
            Console.WriteLine("Vvedit model (ne porno): ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Vvedit kilkist paluva: ");
            string v = (Console.ReadLine());
            try
            {
                famount = double.Parse(v);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Nepravulnui zapus, kilkist = 20");
                famount = 20;
                Console.WriteLine();
            }

            Console.WriteLine("Vvedit vutratu na 1 km paluva: ");
            string vv = (Console.ReadLine());
            try
            {
                fcons = double.Parse(vv);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Nepravulnui zapus, vutratu = 0.5");
                famount = 20;
                Console.WriteLine();
            }
        }

        public void GetCar()
        {
            Console.WriteLine("Model: " + name + "; Fuel amount: " + famount + "; Fuel consumption: " + fcons + ";");
            Console.WriteLine();
        }

        public string GetName()
        {
            return name;
        }

        public void Drive(double dis)
        {
            if((dis* fcons) > famount)
            {
                message += name +" - Insufficient fuel for the drive, "+famount+" - litrov\n";
            }
            else
            {
                distance += dis;
                famount -= dis * fcons;
                message += name + " - " + famount + " litrov, "+distance+"km \n";
            }
        }

        public void GetMessage()
        {
            Console.WriteLine(message);
        }
    }
    static void Main()
    {
        Console.WriteLine("Vvedit kilkist avtomobilei: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Car[] a = new Car[k];

        for (int i = 0; i != k; i++)
        {
            a[i] = new Car();

            a[i].SetCar();
        }

        Console.WriteLine("\n( 'Drive (nazva modeli) (kilkist km)' 'End' ) - komandu; \n");

        while (true)
        {
            string kom = Console.ReadLine();
            if ("Drive" == FindDrive(kom) || "drive" == FindDrive(kom))
            {



                int j = 0;
                FindModel(kom, a, ref j);
                if (j == -1)
                {
                    Console.WriteLine("\n Ne znaideno model");
                }
                else
                {
                    double dist=0;
                    FindDistance(kom, ref dist);
                    a[j].Drive(dist);
                }




            }
            else if (kom == "end" || kom == "End")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ne znaideno komandy");
            }
        }
        Console.WriteLine("\n\n\n\n");
        for(int i = 0; i != a.Length; i++)
        {
            Console.Write(i+1+") ");
            a[i].GetMessage();
        }
    }
}