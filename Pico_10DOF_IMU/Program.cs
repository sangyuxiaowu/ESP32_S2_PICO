using Iot.Device.Imu;
using Iot.Device.Magnetometer;
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;

namespace Pico_10DOF_IMU
{
    public class Program
    {
        public static void Main()
        {
            // nanoFramework.Hardware.Esp32
            Configuration.SetPinFunction(6, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(7, DeviceFunction.I2C1_CLOCK);
            // nanoFramework.Iot.Device.Mpu9250
            var mpui2CConnectionSettingmpus = new I2cConnectionSettings(1, Mpu9250.DefaultI2cAddress);

            var _i2cDevice = I2cDevice.Create(mpui2CConnectionSettingmpus);
            //i2c.WriteByte(0);

            Mpu9250 mpu9250 = new Mpu9250(_i2cDevice, i2CDeviceAk8963: I2cDevice.Create(new I2cConnectionSettings(1, Ak8963.DefaultI2cAddress)));

            Debug.WriteLine("Running Gyroscope and Accelerometer calibration");
            mpu9250.CalibrateGyroscopeAccelerometer();
            Debug.WriteLine("Calibration results:");
            Debug.WriteLine($"Gyro X bias = {mpu9250.GyroscopeBias.X}");
            Debug.WriteLine($"Gyro Y bias = {mpu9250.GyroscopeBias.Y}");
            Debug.WriteLine($"Gyro Z bias = {mpu9250.GyroscopeBias.Z}");
            Debug.WriteLine($"Acc X bias = {mpu9250.AccelerometerBias.X}");
            Debug.WriteLine($"Acc Y bias = {mpu9250.AccelerometerBias.Y}");
            Debug.WriteLine($"Acc Z bias = {mpu9250.AccelerometerBias.Z}");


        }
    }
}
