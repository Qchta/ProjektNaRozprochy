using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    class Box
    {
        public int X;
        public int Y;
        public Rectangle box;

        public Box(BitmapImage sprite)
        {
            this.box = new Rectangle();
            ImageBrush brush = new ImageBrush(sprite);
            this.box.Width = 20;
            this.box.Height = 20;
            this.box.Fill = brush;
            Random rand = new Random();
            this.X = rand.Next(35);
            this.Y = rand.Next(25);
            Canvas.SetTop(box, Y * 20);
            Canvas.SetLeft(box, X * 20);
        }

        public void RandomNewXY()
        {
            Random rand = new Random();
            X = rand.Next(35);
            Y = rand.Next(25);
            Canvas.SetTop(box, Y * 20);
            Canvas.SetLeft(box, X * 20);
        }
    }
}
