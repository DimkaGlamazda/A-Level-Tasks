 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestTask1
{
    class Program
    {

        public static int FieldSize = 10;

        public static int CursorTop = 1;
        public static int CursorLeft = 1;
        public static int CursorVal = 0;

        public static int PointTop;
        public static int PointLeft;
        public static int PointVal;

        public static bool NewPoint = true;

        static void Main(string[] args)
        {

            bool play = true;

            Console.WriteLine("Please enter field size");

            bool valid = Int32.TryParse(Console.ReadLine(), out FieldSize);

            if(!valid)
            {
                Console.WriteLine("You entered incorrect value.");
                Console.ReadLine();
                play = false;
            }

            while (play)
            {
                Console.Clear();
               
                CursorTop = CorrectVal(CursorTop);
                CursorLeft = CorrectVal(CursorLeft);

                if (NewPoint)
                {
                    UpdatePoint();
                }
                Console.WriteLine("\n\n");
                DrawField();

                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        CursorTop--;
                        break;
                    case ConsoleKey.DownArrow:
                        CursorTop++;
                        break;
                    case ConsoleKey.LeftArrow:
                        CursorLeft--;
                        break;
                    case ConsoleKey.RightArrow:
                        CursorLeft++;
                        break;
                    default:
                        play = false;
                        break;
                }

            } 
           
        }

        public static void DrawField()
        {

            
            bool added = false;

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {

                    if ( i == 0 || i == FieldSize - 1)
                    {
                        Console.Write("-");
                    }
                    else if(j == 0 || j == FieldSize - 1 )
                    {
                        Console.Write("|");
                    }
                    else if (j == CursorLeft && i == CursorTop)
                    {
                        Console.Write(CursorVal);
                    }
                    else if (j == PointLeft && i == PointTop)
                    {
                        Console.Write(PointVal);
                    }
                    else
                    {
                        if(! (CursorVal > 9 && CursorTop == i && CursorLeft == j + 1))
                        {
                            Console.Write(' ');
                        }
                    }

                    if(CursorLeft == PointLeft && CursorTop == PointTop && !added)
                    {
                        CursorVal += PointVal;
                        added = true;
                        NewPoint = true;
                    }

                }
                Console.Write('\n');
            }
        }

        public static int CorrectVal(int val)
        {
            if (val < 1)
            {
                return FieldSize -2;
            }

            if (val > FieldSize -2)
            {
                return 1;
            }

            return val;
        }

        public static void UpdatePoint()
        {
            Random rnd = new Random();
            PointLeft = rnd.Next(1, FieldSize - 2);
            PointTop = rnd.Next(1, FieldSize - 2); 
            PointVal = rnd.Next(0, 9);
            NewPoint = false;
        }
     
    }
}
