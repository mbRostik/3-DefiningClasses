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
        temp = b;
    }
    class Rectangle
    {
        public string id;
        public int width;
        public int height;
        public int[] coords=new int[2];

        public void SetRectangle()
        {
            Console.WriteLine("Name: ");
            id = Console.ReadLine();
            Console.WriteLine("Width: ");
            width = int.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            height = int.Parse(Console.ReadLine());

            Console.WriteLine("X koord:");
            coords[0]=int.Parse(Console.ReadLine());
            Console.WriteLine("Y koord:");
            coords[1] = int.Parse(Console.ReadLine());

        }

        public bool Compare(Rectangle a)
        {
            int[,] coords1 = new int[2, 2];
            int[,] coords2 = new int[2, 2];

            coords1[0, 0] = coords[0]-width;
            coords1[0, 1] = coords[0]+width;

            coords1[1, 0] = coords[1] - height;
            coords1[1, 1] = coords[1] + height;
            coords2[0, 0] = a.coords[0] - a.width;
            coords2[0, 1] = a.coords[0] + a.width;

            coords2[1, 0] = a.coords[1] - a.height;
            coords2[1, 1] = a.coords[1] + a.height;




            if ( (coords1[0,0] >= coords2[0,0] && coords1[0,0]<=coords2[0, 1]) || (coords1[0, 1] >= coords2[0, 0] && coords1[0, 1] <= coords2[0, 1]) || (coords2[0, 0] >= coords1[0, 0] && coords2[0, 0] <= coords1[0, 1]) || (coords2[0, 1] >= coords1[0, 0] && coords2[0, 1] <= coords1[0, 1]))
            {
                if ((coords1[1,0] >= coords2[1,0] && coords1[1, 0] <= coords2[1,1]) || (coords1[1, 1] >= coords2[1, 0] && coords1[1, 1] <= coords2[1, 1]) || (coords2[1, 0] >= coords1[1, 0] && coords2[1, 0] <= coords1[1, 1]) || (coords2[1, 1] >= coords1[1, 0] && coords2[1, 1] <= coords1[1, 1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetId()
        {
            return id;
        }
    }
    static void Main()
    {
        Console.WriteLine("Vvedit kilkit priamokytnikov: ");
        int k = int.Parse(Console.ReadLine());
        Rectangle[] a=new Rectangle[k];
        for(int i = 0; i != k; i++)
        {
            a[i] = new Rectangle();
            Console.WriteLine("["+(i+1)+"] Priamokytnuk: \n");
            a[i].SetRectangle();
        }
        Console.WriteLine("Vvedit kilkit porivnian: ");
        k = int.Parse(Console.ReadLine());

        for(int i = 0; i != k; i++)
        {
            Console.WriteLine("Vvedit 2 ikyba dlia porivnianna ( A B ): ");
            string tempall=Console.ReadLine();
            string temp1="", temp2="";
            FindWord(ref tempall, ref temp1);
            FindWord(ref tempall, ref temp2);
            int p1=-1, p2=-1;
            for(int y = 0; y != a.Length; y++)
            {
                if (temp1 == a[y].GetId())
                {
                    p1 = y;
                }
                if(temp2 == a[y].GetId())
                {
                    p2 = y;
                }
            }
            if(p1==-1 || p2 == -1)
            {
                Console.WriteLine("Oshibka (ne pravulno zapusano id)");
                i--;
                Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine(a[p1].Compare(a[p2]));
                Console.WriteLine();
            }
        }
    }
}
