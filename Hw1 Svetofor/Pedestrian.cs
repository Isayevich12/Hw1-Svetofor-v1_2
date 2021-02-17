using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hw1_Svetofor
{
    class Pedestrian:  IDisposable
    {
        
        private Person Person { get; set; }    
        public string Name { get; }
        private Svetofor CurrentSvetofor { get; set; }

        public Pedestrian(Person person)
        {
            this.Person = person;
            this.Name = this.Person.Name;
        }

        public void GoToPedestrianCrossing(Svetofor currentSvetofor)
        {
            CurrentSvetofor = currentSvetofor;

            currentSvetofor.ChangStateSvetoforEvent += GoToPedestrianCrossingHandler;
        }


        private void GoToPedestrianCrossingHandler()
        {

            switch (CurrentSvetofor.CurrentColor)
            {
                case Color.red:
                    Console.WriteLine("\t\t\t\t\tСТОЯТЬ!!!");
                    break;
                case Color.yelow:
                    Console.WriteLine("\t\t\t\t\tПРИГОТОВИТЬСЯ!!!");
                    break;
                case Color.green:
                    Console.WriteLine("\t\t\t\t\tВПЕРЕД!!!");
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            this.CurrentSvetofor = null;
        }

        public void OutToPedestrianCrossing(Svetofor currentSvetofor)
        {
            CurrentSvetofor = currentSvetofor;

            CurrentSvetofor.ChangStateSvetoforEvent -= GoToPedestrianCrossingHandler;

            Dispose();
        }



    }
}
