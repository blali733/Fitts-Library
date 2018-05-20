using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SharedTypes
{
    public class Helpers
    {
        public static IEnumerable<float> FloatRange(float min, float max, float step)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                float value = min + step * i;
                if (value > max)
                {
                    break;
                }

                yield return value;
            }
        }

        public static float Distance2D(float x1, float y1, float x2, float y2)
        {
            return (float) Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
