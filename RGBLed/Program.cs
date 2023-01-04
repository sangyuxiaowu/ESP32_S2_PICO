using nanoFramework.Hardware.Esp32;
using System;
using System.Device.Pwm;
using System.Threading;

namespace RGBLed
{
    public class Program
    {

        /// <summary>
        /// 定义 RBG 的 PWM 通道
        /// </summary>
        private static PwmChannel R_Pin, B_Pin, G_Pin;

        /// <summary>
        /// 初始化 配置PWM 信息
        /// </summary>
        public static void Init() {
            // 先设置引脚 , RBG 分别接的 GP2-4
            Configuration.SetPinFunction(2, DeviceFunction.PWM2);
            Configuration.SetPinFunction(3, DeviceFunction.PWM3);
            Configuration.SetPinFunction(4, DeviceFunction.PWM4);

            // 从三个引脚创建 PWM 通道
            R_Pin = PwmChannel.CreateFromPin(2, 40000, 0);
            B_Pin = PwmChannel.CreateFromPin(3, 40000, 0);
            G_Pin = PwmChannel.CreateFromPin(4, 40000, 0);

            // 启动 PWM
            R_Pin.Start();
            B_Pin.Start();
            G_Pin.Start();
        }

        public static void Main()
        {
            Init();

            Random random = new Random();
            
            while (true)
            {
                R_Pin.DutyCycle = random.Next(255) / 255.0;
                B_Pin.DutyCycle = random.Next(255) / 255.0;
                G_Pin.DutyCycle = random.Next(255) / 255.0;
                Thread.Sleep(500);
            }

        }
    }
}
