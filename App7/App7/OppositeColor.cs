using System;
using Xamarin.Forms;

namespace App7
{
    class OppositeColor
    {
        public string hex { private set; get; }

        public Color Color { private set; get; }

        public string RgbDisplay { private set; get; }
        int Oppositron(int a)
        {
            if (Math.Abs(a - 128) < 1) a = 130;
            return 255 - a + Math.Max(0, 50 - Math.Abs(128 - a)) * (128 - a) / Math.Abs(128 - a);
        }
        public OppositeColor(Color color)
        {
            Color = Color.FromRgba(
                Oppositron((int)(color.R * 255)),
                Oppositron((int)(color.G * 255)),
                Oppositron((int)(color.B * 255)),
                255);
        }
    }
}
