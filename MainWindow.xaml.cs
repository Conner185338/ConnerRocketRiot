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
using System.Drawing;

namespace rocketRiotv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        Zapper zapper;
        string[] highScores = new string[5];
        string[] highScoreData;
        Button btnStartGame = new Button();
        Button btnHighScores = new Button();

        public MainWindow()
        {
            Rectangle sprite = new Rectangle();
            Rectangle coins = new Rectangle();
            Rectangle background = new Rectangle();
            Rectangle[] rectangles = new Rectangle[10];
            Random rand = new Random();
            ImageBrush spritefill;
            BitmapImage bitmapImage;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            gameTimer.Tick += GameTimer_Tick;
            InitializeComponent();
            background.Height = 600;
            background.Width = 800;
            bitmapImage = new BitmapImage(new Uri("background.png", UriKind.Relative));
            spritefill = new ImageBrush(bitmapImage);
            background.Fill = spritefill;
            canvas.Children.Add(background);

            
            btnStartGame.Click += btnStartGame_Click;
            btnStartGame.Content = "Start Game";
            btnStartGame.FontSize = 50;
            btnStartGame.Background = Brushes.White;
            Canvas.SetLeft(btnStartGame, 265);
            Canvas.SetTop(btnStartGame, 50);
            btnStartGame.BorderThickness = new Thickness(1);
            btnStartGame.BorderBrush = Brushes.Black;
            canvas.Children.Add(btnStartGame);

            btnHighScores.Click += btnHighScores_Click;
            btnHighScores.Content = "High Scores";
            btnHighScores.FontSize = 40;
            btnHighScores.Background = Brushes.White;
            Canvas.SetLeft(btnHighScores, 285);
            Canvas.SetTop(btnHighScores, 125);
            btnHighScores.BorderThickness = new Thickness(1);
            btnHighScores.BorderBrush = Brushes.Black;
            canvas.Children.Add(btnHighScores);

            System.IO.StreamReader readHighScores = new System.IO.StreamReader("HighScores.txt");
            for (int i = 0; i < 5; i++)
            {
                highScores[i] = readHighScores.ReadLine();
            }
            readHighScores.Close();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {

            gameTimer.Start();

            canvas.Children.Remove(btnStartGame);
            canvas.Children.Remove(btnHighScores);

            int temp = 1;
            zapper = new Zapper(temp, canvas);
            zapper.generate();

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            zapper.animate();
            zapper.generate();
        }

        /// <summary>
        /// Who wrote it
        /// purpose of the method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            Label lblHighScores = new Label();
            canvas.Children.Remove(btnStartGame);
            canvas.Children.Remove(btnHighScores);

            
            lblHighScores.FontSize = 15;
            //lblHighScores.Background.Opacity = .5;
            //lblHighScores.Background = Brushes.White;
            lblHighScores.Background = new SolidColorBrush(Color.FromArgb(125, 255, 255, 255));
            lblHighScores.Foreground = Brushes.Black;

            Canvas.SetLeft(lblHighScores, 350 - lblHighScores.ActualWidth);
            Canvas.SetTop(lblHighScores, 120 - lblHighScores.ActualHeight);
            canvas.Children.Add(lblHighScores);
            


            lblHighScores.Content = "";
            for (int i = 0; i < 5; i++)
            {
                highScoreData = highScores[i].Split(new char[] { ',' });
                lblHighScores.Content += i + 1 + ". " + highScoreData[0] + " " + highScoreData[1] + Environment.NewLine;
            }
        }
    }
}

