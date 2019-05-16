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
    enum GameState { MainScreen, HighScores, Instructions, PauseMenu, GameON, InGame, GameOver}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameState gameState;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        Zapper zapper;
        string[] highScores = new string[5];
        string[] highScoreData;
        Button btnStartGame = new Button();
        Button btnHighScores = new Button();
        Button btnInstructions = new Button();

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
            gameState = GameState.MainScreen;

            //int temp = 1;
            //zapper = new Zapper(temp, canvas);
            //zapper.generate();
            //zapper.animate();

            Label lblTitle = new Label();
            lblTitle.Foreground = Brushes.Gold;
            lblTitle.Background = Brushes.Transparent;
            lblTitle.FontSize = 100;
            lblTitle.FontFamily = new FontFamily("Impact");
            lblTitle.Content = "Rocket Riot";
            Canvas.SetLeft(lblTitle, 150);
            Canvas.SetTop(lblTitle, 95);
            canvas.Children.Add(lblTitle);

            btnStartGame.Click += btnStartGame_Click;
            btnStartGame.Content = "Start Game";
            btnStartGame.FontSize = 50;
            btnStartGame.Background = Brushes.RoyalBlue;
            btnStartGame.Foreground = Brushes.Gold;
            btnStartGame.FontFamily = new FontFamily("Impact");
            Canvas.SetLeft(btnStartGame, 280);
            Canvas.SetTop(btnStartGame, 218);
            btnStartGame.BorderThickness = new Thickness(2);
            btnStartGame.BorderBrush = Brushes.Black;
            canvas.Children.Add(btnStartGame);
            gameState = GameState.GameON;

            btnHighScores.Click += btnHighScores_Click;
            btnHighScores.Content = "High Scores";
            btnHighScores.FontSize = 40;
            btnHighScores.Background = Brushes.RoyalBlue;
            btnHighScores.Foreground = Brushes.Gold;
            btnHighScores.FontFamily = new FontFamily("Impact");
            Canvas.SetLeft(btnHighScores, 295);
            Canvas.SetTop(btnHighScores, 290);
            btnHighScores.BorderThickness = new Thickness(2);
            btnHighScores.BorderBrush = Brushes.Black;
            canvas.Children.Add(btnHighScores);
            gameState = GameState.HighScores;

            btnInstructions.Click += btnInstructions_Click;
            btnInstructions.Content = "Instructions";
            btnInstructions.FontSize = 40;
            btnInstructions.Background = Brushes.RoyalBlue;
            btnInstructions.Foreground = Brushes.Gold;
            btnInstructions.FontFamily = new FontFamily("Impact");
            btnInstructions.BorderThickness = new Thickness(2);
            Canvas.SetLeft(btnInstructions, 292);
            Canvas.SetTop(btnInstructions, 350);
            btnInstructions.BorderBrush = Brushes.Black;
            canvas.Children.Add(btnInstructions);
            gameState = GameState.Instructions;

            System.IO.StreamReader readHighScores = new System.IO.StreamReader("HighScores.txt");
            for (int i = 0; i < 5; i++)
            {
                highScores[i] = readHighScores.ReadLine();
            }
            readHighScores.Close();
            /*int temp = 1;
            zapper = new Zapper(temp, canvas);
            zapper.generate();
            zapper.animate();
            Canvas.SetLeft(zapper, 50);*/
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (gameState == GameState.MainScreen)
            {
                this.Title = "Rocket Riot";
            }
            gameTimer.Start();
            gameState = GameState.InGame;

            canvas.Children.Remove(btnStartGame);
            canvas.Children.Remove(btnHighScores);
            canvas.Children.Remove(btnInstructions);

            int temp = 1;
            zapper = new Zapper(temp, canvas);
            zapper.generate();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == GameState.MainScreen)
            {
                this.Title = "Rocket Riot";
            }
            zapper.animate();
            zapper.generate();
            gameState = GameState.GameON;
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
            canvas.Children.Remove(btnInstructions);


            lblHighScores.FontSize = 15;
            //lblHighScores.Background.Opacity = .5;
            //lblHighScores.Background = Brushes.White;
            lblHighScores.Background = Brushes.RoyalBlue;
            lblHighScores.Foreground = Brushes.Gold;
            lblHighScores.FontFamily = new FontFamily("Impact");

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

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInstructions_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Remove(btnInstructions);
            canvas.Children.Remove(btnHighScores);
            canvas.Children.Remove(btnStartGame);

            Label lblInstructions = new Label();

            lblInstructions.Background = Brushes.RoyalBlue;
            lblInstructions.FontSize = 40;
            lblInstructions.Foreground = Brushes.Gold;
            lblInstructions.FontFamily = new FontFamily("Impact");
            lblInstructions.Content = "-Use up arrow key to turn on jetpack" + Environment.NewLine + "-Avoid the zappers to stay alive" + Environment.NewLine + "-Get coins to Win!";
            Canvas.SetLeft(lblInstructions, 102 - lblInstructions.ActualWidth);
            Canvas.SetTop(lblInstructions, 120 - lblInstructions.ActualHeight);
            
            canvas.Children.Add(lblInstructions);

        }
    }
}

