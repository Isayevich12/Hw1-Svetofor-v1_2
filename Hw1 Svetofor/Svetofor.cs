using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hw1_Svetofor
{
    enum Color
    {
        red = 0,
        yelow,
        green,
    }



    class Svetofor
    {
        private Timer Timer { get; set; }
        public Color CurrentColor { get; set; }
        public int RedPeriod { get; set; }
        public int YellowPeriod { get; set; }
        public int GreenPeriod { get; set; }
        private int counter = 0;
        private int ostalosVremeni { get; set; }
        public event Action ChangStateSvetoforEvent;

        public Svetofor(int redPeriod, int yellowPeriod, int greenPeriod)
        {
            Timer = new Timer(CallbackTimer, CurrentColor, 0, 1000);
            CurrentColor = Color.red;
            this.RedPeriod = redPeriod;
            this.YellowPeriod = yellowPeriod;
            this.GreenPeriod = greenPeriod;
        }

        private void CallbackTimer(object currentColor)
        {
            switch ((Color)CurrentColor)
            {
                case Color.red:
                    {
                        ostalosVremeni = RedPeriod - counter;
                        counter++;
                        if (counter > RedPeriod)
                        {
                            CurrentColor = Color.yelow;
                            counter = 0;
                        }
                        break;
                    }

                case Color.yelow:
                    {
                        ostalosVremeni = YellowPeriod - counter;
                        counter++;
                        if (counter > YellowPeriod)
                        {
                            CurrentColor = Color.green;
                            counter = 0;
                        }
                        break;
                    }

                case Color.green:
                    {
                        ostalosVremeni = GreenPeriod - counter;
                        counter++;
                        if (counter > GreenPeriod)
                        {
                            CurrentColor = Color.red;
                            counter = 0;
                        }
                        break;
                    }

                default:
                    break;
            }

            ChangStateSvetoforEvent?.Invoke();

            if (counter != 0)
            {
                Console.WriteLine($"Цвет светофора->{CurrentColor} -{ostalosVremeni} сек.");// для визуального отображения жизненного цикла светофора. закомментить чтоб скрыть
            }
        }


    }
}
