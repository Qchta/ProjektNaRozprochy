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
            var uriSource = new Uri("pack://application:,,,/WpfApplication1;component/Textures/Postac.png");
            BitmapImage heroSprite = new BitmapImage(uriSource);
            hero = new Player(heroSprite, Color.FromArgb(255, 0, 200, 50), 1);
            Thread.Sleep(10);
            var uriSecondSource = new Uri("pack://application:,,,/WpfApplication1;component/Textures/DrugaPostac.png");
            BitmapImage heroSecondSprite = new BitmapImage(uriSecondSource);
            secondHero = new Player(heroSecondSprite, Color.FromArgb(255, 50, 0, 200), 2);
            Thread.Sleep(10);
            var uriBoxSource = new Uri("pack://application:,,,/WpfApplication1;component/Textures/Skrzynka.png");
            BitmapImage boxSprite = new BitmapImage(uriBoxSource);
            box = new Box(boxSprite);
            game = new Game();
            foreach (Rectangle el in game.board)
                PoleGry.Children.Add(el);
        }
        //to je timer tu się dzieją rzeczy zależne od czasu
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(game.runs)
            {
                hero.Move(game, box);
                game.board[hero.Y, hero.X].Fill = new SolidColorBrush(hero.color);
                game.secondBoard[hero.Y, hero.X] = 1;
                firststPlayerPoints.Content = hero.points;
                secondHero.Move(game, box);
                game.board[secondHero.Y, secondHero.X].Fill = new SolidColorBrush(secondHero.color);
                game.secondBoard[secondHero.Y, secondHero.X] = 2;
                secondPlayerPoints.Content = secondHero.points;
            }
            if(hero.points > 1000)
            {
                TitleLabel.Content = "1. Wins!";
                game.runs = false;
                QuitButton.Visibility = Visibility.Visible;
                StartGameButton.Visibility = Visibility.Visible;
                TitleLabel.Visibility = Visibility.Visible;
                PoleGry.Children.Remove(hero.hero);
                PoleGry.Children.Remove(secondHero.hero);
                PoleGry.Children.Remove(box.box);
                game.Score(1);
                game.Score(2);
            }
            else if (secondHero.points > 1000)
            {
                TitleLabel.Content = "2. Wins!";
                game.runs = false;
                QuitButton.Visibility = Visibility.Visible;
                StartGameButton.Visibility = Visibility.Visible;
                TitleLabel.Visibility = Visibility.Visible;
                PoleGry.Children.Remove(hero.hero);
                PoleGry.Children.Remove(secondHero.hero);
                PoleGry.Children.Remove(box.box);
                game.Score(1);
                game.Score(2);
            }
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

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            game.runs = true;
            QuitButton.Visibility = Visibility.Collapsed;
            StartGameButton.Visibility = Visibility.Collapsed;
            TitleLabel.Visibility = Visibility.Collapsed;
            PoleGry.Children.Add(hero.hero);
            PoleGry.Children.Add(secondHero.hero);
            PoleGry.Children.Add(box.box);
        }
    }
}