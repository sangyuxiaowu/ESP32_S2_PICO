
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.Pwm;
using System.Threading;

namespace BlinkBoardLed
{
    public class Program
    {


        public static void Main()
        {
            // ÏÈÉèÖÃ LED 
            Configuration.SetPinFunction(9, DeviceFunction.PWM1);
            PwmChannel led = PwmChannel.CreateFromPin(9, 40000, 0);
            led.Start();

            bool goingUp = true;
            float dutyCycle = .00f;

            while (true)
            {
                if (goingUp)
                {
                    // slowly increase light intensity
                    dutyCycle += 0.05f;

                    // change direction if reaching maximum duty cycle (100%)
                    if (dutyCycle > .95)
                        goingUp = !goingUp;
                }
                else
                {
                    // slowly decrease light intensity
                    dutyCycle -= 0.05f;

                    // change direction if reaching minimum duty cycle (0%)
                    if (dutyCycle < 0.10)
                        goingUp = !goingUp;
                }

                // update duty cycle
                led.DutyCycle = dutyCycle;

                Thread.Sleep(50);
            }
        }
    }
}
