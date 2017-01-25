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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleFloatingActionButton
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //Button 3개 만들어주기
            Button FirstButton = new Button();
            FirstButton.HorizontalAlignment = HorizontalAlignment.Right;
            FirstButton.VerticalAlignment = VerticalAlignment.Bottom;
            FirstButton.Margin = new Thickness(0, 0, 15, 15);
            FirstButton.Width = 50;
            FirstButton.Height = 50;
            FirstButton.Background = Brushes.Orange;
            FirstButton.FocusVisualStyle = null;
            Panel.SetZIndex(FirstButton, -1);

            Button SecondButton = new Button();
            SecondButton.HorizontalAlignment = HorizontalAlignment.Right;
            SecondButton.VerticalAlignment = VerticalAlignment.Bottom;
            SecondButton.Margin = new Thickness(0, 0, 15, 15);
            SecondButton.Width = 50;
            SecondButton.Height = 50;
            SecondButton.Background = Brushes.LemonChiffon;
            SecondButton.FocusVisualStyle = null;
            Panel.SetZIndex(SecondButton, -1);

            Button ThirdButton = new Button();
            ThirdButton.HorizontalAlignment = HorizontalAlignment.Right;
            ThirdButton.VerticalAlignment = VerticalAlignment.Bottom;
            ThirdButton.Margin = new Thickness(0, 0, 15, 15);
            ThirdButton.Width = 50;
            ThirdButton.Height = 50;
            ThirdButton.Background = Brushes.Magenta;
            ThirdButton.FocusVisualStyle = null;
            Panel.SetZIndex(ThirdButton, -1);


            Screen.Children.Add(FirstButton);
            Screen.Children.Add(SecondButton);
            Screen.Children.Add(ThirdButton);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoveAnim(Screen.Children[2], VisualTreeHelper.GetOffset(Screen.Children[2]).X, 310);
            MoveAnim(Screen.Children[3], VisualTreeHelper.GetOffset(Screen.Children[3]).X, 380);
            MoveAnim(Screen.Children[4], VisualTreeHelper.GetOffset(Screen.Children[4]).X, 450);
        }

        public void MoveAnim(UIElement target, double newX, double newY)
        {
            Vector offset = VisualTreeHelper.GetOffset(target);

            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, newY - top, TimeSpan.FromSeconds(0.8));
            DoubleAnimation anim2 = new DoubleAnimation(0, newX - left, TimeSpan.FromSeconds(0.8));

            ElasticEase easingFunction = new ElasticEase();
            easingFunction.EasingMode = EasingMode.EaseOut;
            easingFunction.Oscillations = 0;

            anim1.EasingFunction = easingFunction;
            anim2.EasingFunction = easingFunction;

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }
    }
}
