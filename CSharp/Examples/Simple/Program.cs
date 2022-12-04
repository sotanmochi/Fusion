using System;
using System.IO;

namespace ImuFusion.Examples
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"////////////////////////////////////////");
            Console.WriteLine($"      Simple Example for ImuFusion      ");
            Console.WriteLine($"////////////////////////////////////////");

            var filePath = @"sensor_data.csv";

            using var ahrs = new Ahrs();
            using var reader = new StreamReader(filePath, System.Text.Encoding.GetEncoding("UTF-8"));

            var columnTitles = reader.ReadLine();
            while (reader.Peek() >= 0)
            {
                var values = reader.ReadLine().Split(',');

                if (values.Length != 10)
                {
                    continue;
                }

                float.TryParse(values[0], out var v0);
                float.TryParse(values[1], out var v1);
                float.TryParse(values[2], out var v2);
                float.TryParse(values[3], out var v3);
                float.TryParse(values[4], out var v4);
                float.TryParse(values[5], out var v5);
                float.TryParse(values[6], out var v6);
                float.TryParse(values[7], out var v7);
                float.TryParse(values[8], out var v8);
                float.TryParse(values[9], out var v9);

                var time          = v0;
                var gyroscope     = new Vector(v1, v2, v3);
                var accelerometer = new Vector(v4, v5, v6);
                var magnetometer  = new Vector(v7, v8, v9);

                Console.WriteLine($"");
                Console.WriteLine($"----------");
                Console.WriteLine($"Time: {time}");
                Console.WriteLine($"---");
                Console.WriteLine($"Gyroscope: ({gyroscope.X}, {gyroscope.Y}, {gyroscope.Z})");
                Console.WriteLine($"Accelerometer: ({accelerometer.X}, {accelerometer.Y}, {accelerometer.Z})");
                // Console.WriteLine($"Magnetometer: ({magnetometer.X}, {magnetometer.Y}, {magnetometer.Z})");

                ahrs.UpdateNoMagnetometer(gyroscope, accelerometer, 0.01f);

                var q = ahrs.Quaternion;
                var euler = Math.QuaternionToEuler(q);

                Console.WriteLine($"---");
                Console.WriteLine($"Quaternion: ({q.W}, {q.X}, {q.Y}, {q.Z})");
                Console.WriteLine($"Euler: ({euler.Roll}, {euler.Pitch}, {euler.Yaw})");
                Console.WriteLine($"---");
                Console.WriteLine($"");

                Console.Write($"Press any key to process the next data ('q' to quit) > ");
                if (Console.ReadLine() == "q") break;
            }
        }
    }
}