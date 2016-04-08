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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint;
        int X = 100;
        int Y = 100; // To leci do poprawy. Potrzebna klasa gracz
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        //to je timer tu się dzieją rzeczy zależne od czasu
        private void dispatcherTimer_Tick(object sender, EventArgs e)
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
        //to był test rysowania na canvasie. zauważcie, że nie rysujemy tylko tworzymy obiekty potomne 
        //a canvas sam sobie je rysuje.
        //moim zdaniem trzeba będzie zrobić tablicę takich kwadratów i tylko zmieniać im kolory 
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
        //elo sterowanie tu jest
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                this.Title = "You pressed F5";
            }
            else if (e.Key == Key.Down)
            {
                this.Title = "You pressed F5";
            }
            else if (e.Key == Key.Right)
            {
                this.Title = "You pressed F5";
            }
            else if (e.Key == Key.Left)
            {
                this.Title = "You pressed F5";
            }
        }



    }
}
