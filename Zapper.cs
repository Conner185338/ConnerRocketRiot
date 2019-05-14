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
    class Zapper
    {
        //global variables
        public int quadrant;
        int spriteNum;
        int counter2 = 0;
        BitmapImage bitmapImage;
        ImageBrush ZapperFill;
        public Rectangle zapper = new Rectangle();
        Random h = new Random();
        Canvas canvas = new Canvas();
        int counter = 0;
        string spriteName = "Vertical Sprite 1.png";
        //methods
        public Zapper(int q, Canvas c)
        {
            quadrant = q;
            canvas = c;
            bitmapImage = new BitmapImage(new Uri(spriteName, UriKind.Relative));
            ZapperFill = new ImageBrush(bitmapImage);
            zapper.Fill = ZapperFill;
            zapper.Height = 50;
            zapper.Width = 50;
            canvas.Children.Add(zapper);
            Canvas.SetTop(zapper, 300);
            Canvas.SetLeft(zapper, 300);
        }
        public void generate()
        {
            canvas.Children.Remove(zapper);
            bitmapImage = new BitmapImage(new Uri(spriteName, UriKind.Relative));
            ZapperFill = new ImageBrush(bitmapImage);
            zapper.Fill = ZapperFill;
            zapper.Height = 50;
            zapper.Width = 50;
            Canvas.SetTop(zapper, 300);
            Canvas.SetLeft(zapper, 300);
            RotateTransform rotate = new RotateTransform(counter2 * 50);
            zapper.RenderTransformOrigin = new Point(0.5, 0.5);
            zapper.RenderTransform = rotate;
            canvas.Children.Add(zapper);
        }
        public void animate()
        {
            counter++;
            counter2++;
            //change sprite every 10 counts
            if (counter < 3)
            {
                spriteNum = 1;
            }
            else if (counter > 3)
            {
                spriteNum = 2;

                if (counter == 6)
                {
                    counter = 0;
                }
            }
            spriteName = "Vertical Sprite " + spriteNum + ".png";
        }
    }
}
