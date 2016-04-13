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
using System.IO;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Polecam programować po angielsku. Ja już kilka polskich nazw natrzaskałem ale poprawię to
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Player hero;
        Player secondHero;
        Box box;
        Game game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 70); //co ile milisekund mamy ruch 
            dispatcherTimer.Start();
            var uriSource = new Uri(@"Textures/Postac.png", UriKind.Relative);//Tekstury wrzucać do folderu debug
            BitmapImage heroSprite = new BitmapImage(uriSource);
            hero = new Player(heroSprite, Color.FromArgb(255, 0, 200, 50), 1);
            Thread.Sleep(10);
            var uriSecondSource = new Uri(@"Textures/DrugaPostac.png", UriKind.Relative);//Tekstury wrzucać do folderu debug
            BitmapImage heroSecondSprite = new BitmapImage(uriSecondSource);
            secondHero = new Player(heroSecondSprite, Color.FromArgb(255, 50, 0, 200), 2);
            Thread.Sleep(10);
            var uriBoxSource = new Uri(@"Textures/Skrzynka.png", UriKind.Relative);//Tekstury wrzucać do folderu debug
            BitmapImage boxSprite = new BitmapImage(uriBoxSource);
            box = new Box(boxSprite);
            game = new Game();
            foreach (Rectangle el in game.board)
                PoleGry.Children.Add(el);
            PoleGry.Children.Add(hero.hero);
            PoleGry.Children.Add(secondHero.hero);
            PoleGry.Children.Add(box.box);
        }
        //to je timer tu się dzieją rzeczy zależne od czasu
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            hero.Move(game, box);
            game.board[hero.Y, hero.X].Fill = new SolidColorBrush(hero.color);
            game.secondBoard[hero.Y, hero.X] = 1;
            SingePlayerButton.Content = "Zielony " + hero.points + " punktow";
            secondHero.Move(game, box);
            game.board[secondHero.Y, secondHero.X].Fill = new SolidColorBrush(secondHero.color);
            game.secondBoard[secondHero.Y, secondHero.X] = 2;
            SecondPlayerButton.Content = "Niebieski " + secondHero.points + " punktow";
        }

        private void SingePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            //PoleGry.Children.RemoveRange(0, 100);
        }
        
        //elo sterowanie tu jest
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                hero.GoUp();
            else if (e.Key == Key.Down)
                hero.GoDown();
            else if (e.Key == Key.Right)
                hero.GoRight();
            else if (e.Key == Key.Left)
                hero.GoLeft();

            if (e.Key == Key.W)
                secondHero.GoUp();
            else if (e.Key == Key.S)
                secondHero.GoDown();
            else if (e.Key == Key.D)
                secondHero.GoRight();
            else if (e.Key == Key.A)
                secondHero.GoLeft();
        }
    }
}