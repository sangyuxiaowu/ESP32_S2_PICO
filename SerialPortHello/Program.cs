using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace SerialPortHello
{
    public class Program
    {
        static SerialPort _serialDevice;

        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            // 获取可用串口
            var ports = SerialPort.GetPortNames();

            Debug.WriteLine("Available ports: ");

            foreach (string port in ports)
            {
                Debug.WriteLine($" {port}");
            }

            _serialDevice = new SerialPort("COM1");

            // 设置参数
            _serialDevice.BaudRate = 9600;
            _serialDevice.Parity = Parity.None;
            _serialDevice.StopBits = StopBits.One;
            _serialDevice.Handshake = Handshake.None;
            _serialDevice.DataBits = 8;

            // 设置缓冲区大小
            _serialDevice.ReadBufferSize = 2048;

            // 使用以上设置打开串口
            _serialDevice.Open();

            _serialDevice.WriteTimeout = 500;

            for (; ; )
            {
                _serialDevice.WriteLine(DateTime.UtcNow + " hello from nanoFramework!");
                Thread.Sleep(2000);
            }

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
