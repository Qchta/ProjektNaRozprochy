using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    class Game
    {
        public Rectangle[,] board;
        public int[,] secondBoard;
        public bool runs = false;

        public Game()
        {
            board = new Rectangle[25,35];
            secondBoard = new int[25, 35];

            for (int i = 0; i < 25;i++ )
            {
                for (int j = 0; j < 35; j++)
                {
                    board[i, j] = new Rectangle();
                    secondBoard[i, j] = 0;

                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromArgb(0,0,0,0);

                    board[i, j].Fill = mySolidColorBrush;
                    board[i, j].StrokeThickness = 0;

                    Canvas.SetTop(board[i, j], i*20);
                    Canvas.SetLeft(board[i, j], j*20);

                    board[i, j].Width = 20;
                    board[i, j].Height = 20;
                    
                }
            }
        }

        public int Score(int number)
        {
            int score = 0;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    if (secondBoard[i, j] == number)
                    {
                        SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                        mySolidColorBrush.Color = Color.FromArgb(0, 0, 0, 0);

                        board[i, j].Fill = mySolidColorBrush;
                        secondBoard[i, j] = 0;

                        score++;
                    }
                }
            }

            return score;
        }
    }
}
