using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace BlinkBoardLed
{
    public class Program
    {

        private static GpioController s_GpioController;
        public static void Main()
        {
            s_GpioController = new GpioController();

            GpioPin led = s_GpioController.OpenPin(25, PinMode.Output);

            led.Write(PinValue.Low);

            while (true)
            {
                led.Toggle();
                Thread.Sleep(125);
                led.Toggle();
                Thread.Sleep(125);
                led.Toggle();
                Thread.Sleep(125);
                led.Toggle();
                Thread.Sleep(525);
            }
        }
    }
}
