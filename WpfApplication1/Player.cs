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
    class Player
    {
        public int X;
        public int Y;
        public int deltaX;
        public int deltaY;
        public Rectangle hero;
        public Color color;
        public int points;
        public int number;

        public Player(BitmapImage sprite,Color color, int number)
        {
            this.color = color;
            this.hero = new Rectangle();
            ImageBrush brush = new ImageBrush(sprite);
            this.hero.Width = 20;
            this.hero.Height = 20;
            this.hero.Fill = brush;
            Random rand = new Random();
            this.X = rand.Next(35);
            this.Y = rand.Next(25);
            Canvas.SetTop(hero, Y * 20);
            Canvas.SetLeft(hero, X * 20);
            this.points = 0;
            this.number = number;
        }

        public void GoLeft()
        {
            deltaY = 0;
            deltaX = -1;
            hero.RenderTransform = new RotateTransform(270, hero.Width / 2, hero.Height / 2);
        }

        public void GoRight()
        {
            deltaY = 0;
            deltaX = 1;
            hero.RenderTransform = new RotateTransform(90,hero.Width/2,hero.Height/2);
        }

        public void GoDown()
        {
            deltaY = 1;
            deltaX = 0;
            hero.RenderTransform = new RotateTransform(180, hero.Width / 2, hero.Height / 2);
        }

        public void GoUp()
        {
            deltaY = -1;
            deltaX = 0;
            hero.RenderTransform = new RotateTransform(0, hero.Width / 2, hero.Height / 2);
        }

        public void Move(Game game, Box box)
        {
            if (X > 0 && deltaX < 0) X += deltaX;
            if (X < 34 && deltaX > 0) X += deltaX;
            if (Y > 0 && deltaY < 0) Y += deltaY;
            if (Y < 24 && deltaY > 0) Y += deltaY;
            Canvas.SetTop(hero, Y * 20);
            Canvas.SetLeft(hero, X * 20);
            if (X == box.X && Y == box.Y)
            {
                points += game.Score(number);
                box.RandomNewXY();
            }
        }
        
        public void Stop()
        {
            deltaX = deltaY = 0;
        }
    }
}