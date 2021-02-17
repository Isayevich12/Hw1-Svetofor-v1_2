using System;

namespace Hw1_Svetofor
{
    class Program
    {
        static void Main(string[] args)
        {         

            Console.WriteLine("жизненный цикл светофора\t\t\tнажми f чтоб подойти к светофору; d чтоб отойти от Светофора! ");

            Svetofor svetofor = new Svetofor(10, 3, 10);
            Person pers = new Person("dima");
            Pedestrian isai = new Pedestrian(pers);

            while (true)// для имитации подхода/отхода от светофора
            {
                ConsoleKeyInfo podoiti = Console.ReadKey();
                if (podoiti.KeyChar == 'f')
                {
                    isai.GoToPedestrianCrossing(svetofor);
                }
                else if (podoiti.KeyChar == 'd')
                {
                    isai.OutToPedestrianCrossing(svetofor);
                }
                else
                {
                    return;
                }

            }

        }
    }
}
