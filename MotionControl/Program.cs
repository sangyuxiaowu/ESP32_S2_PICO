using Iot.Device.ServoMotor;
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.Gpio;
using System.Device.Pwm;
using System.Diagnostics;
using System.Threading;

namespace MotionControl
{
    public class Program
    {
        private static GpioPin _a1;
        private static GpioPin _a2;

        public static void Main()
        {
            var gpioController = new GpioController();
            // GP2 电机驱动 A1
            _a1 = gpioController.OpenPin(2, PinMode.Output);
            // GP3 电机驱动 A2
            _a2 = gpioController.OpenPin(3, PinMode.Output);

            /*
            // 电机测试
            // 正转
            _a1.Write(PinValue.High);
            _a2.Write(PinValue.Low);
            Thread.Sleep(2000);
            // 反转
            _a1.Write(PinValue.Low);
            _a2.Write(PinValue.High);
            Thread.Sleep(2000);
            // 停止
            _a1.Write(PinValue.Low);
            _a2.Write(PinValue.Low);
            */
            // 舵机测试

            // 舵机控制信号 GP8 配置为 PWM
            Configuration.SetPinFunction(2, DeviceFunction.PWM1);

            // 从 GP8 创建 PWM 通道
            PwmChannel pwmChannel = PwmChannel.CreateFromPin(2, 5000);
            // 使用 PwmChannel 创建 ServoMotor
            ServoMotor servoMotor = new ServoMotor(pwmChannel);
            // 启动 控制
            servoMotor.Start();


            servoMotor.WritePulseWidth(0);
            Thread.Sleep(2000);
            servoMotor.WritePulseWidth(90);
            Thread.Sleep(2000);
            servoMotor.WritePulseWidth(180);
            Thread.Sleep(Timeout.Infinite);

        }
    }
}
