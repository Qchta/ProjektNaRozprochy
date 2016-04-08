using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LiczPunkty()
        {
            
        }

        private void SingePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PoleGry_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void PoleGry_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Rectangle point = new Rectangle();

                SolidColorBrush mySolidColorBrush = new SolidColorBrush();

                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                point.Fill = mySolidColorBrush;
                point.StrokeThickness = 0;

                Canvas.SetTop(point, currentPoint.Y - currentPoint.Y%20);
                Canvas.SetLeft(point, currentPoint.X - currentPoint.X % 20);

                point.Width = 20;
                point.Height = 20;

                PoleGry.Children.Add(point);

                currentPoint = e.GetPosition(this);
            }
        }
    }
}
