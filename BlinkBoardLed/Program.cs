
using System.Threading;
using BlinkBoardLed.WS2812;

namespace BlinkBoardLed
{
    public class Program
    {


        public static void Main()
        {
            // ESP32 WS2812 Driver
            // https://github.com/nanoframework/nf-Community-Contributions/tree/master/drivers/ESP32-WS2812

            // 微雪的 ESP32-S2-Pico 只有一个灯珠

            // 生成多少种颜色
            uint ledCount = 25;

            PixelController controller = new PixelController(9, ledCount);

            
            // 简单测试颜色
            controller.SetColor(0,255,0,0);//红
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 0, 255, 0);//绿
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 0, 0, 255);//蓝
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 255, 255, 255);//白
            controller.UpdatePixels();
            Thread.Sleep(1000);

            // 呼吸灯效果
            var ts = 0;
            for (; ; )
            {
                var add = true;
                var v = 0f;
                for (; ; )
                {
                    controller.SetHSVColor(0, 240, 50, v);
                    controller.UpdatePixels();
                    if (add)
                    {
                        v += 0.05f;
                    }
                    else
                    {
                        v -= 0.05f;
                    }
                    
                    if (v >= 1) add = false;
                    if (v <= 0) break;
                    Thread.Sleep(50);
                }
                if (ts > 5) break;
                ts++;
            }




            // 添加开始时设置的 ledCount 种颜色
            int step = (int)(360 / ledCount);
            var hue = 0;
            for (uint i = 0; i < ledCount; i++)
            {
                // HSV
                // 色调H 取值范围为0°～360°
                // 饱和度S 取值范围为0%～100%，值越大，颜色越饱和
                // 明度V 表示颜色明亮的程度,通常取值范围为0%（黑）到100%（白）
                // V 这个取值挺好的，设置为1 差点亮瞎
                controller.SetHSVColor((short)i, (short)hue, 1, 0.05f);
                hue = hue + step;
                controller.UpdatePixels();
            }

            // 循环变换颜色
            for (; ; )
            {
                controller.MovePixelsByStep(1);
                controller.UpdatePixels();
                Thread.Sleep(500);
            }
        }
    }
}
