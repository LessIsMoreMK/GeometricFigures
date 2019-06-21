using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace GeometricFigures
{
    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow;
        private int method = -1;
        private int number = 0;
        private List<Point> clicks = new List<Point>();
        private List<IShape> shapes = new List<IShape>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetMousePosition()
        {
            Point pointToWindow = Mouse.GetPosition(mainCanvas);
            clicks.Add(pointToWindow);
        }
        private void Clicks(object sender, MouseButtonEventArgs e)
        {
            GetMousePosition();
            currentActiviti.Content = "Choose "+(clicks.Count+1)+" point";
            
            if(method==-1)
                currentActiviti.Content = "Choose shape";
            else if (clicks.Count == 2 && method == 0)
            {
                double r = Math.Sqrt(Math.Pow(clicks[0].X - clicks[1].X, 2) + Math.Pow(clicks[0].Y - clicks[1].Y, 2));
                Circle circle = new Circle(clicks[0], r);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Circle Center: " + clicks[0] + " Radius: " + r;
                Shapes.Items.Add(itm);
                currentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if(clicks.Count==3 && method ==1)
            {
                Triangle traingle = new Triangle();
                traingle.point1 = clicks[0];
                traingle.point2 = clicks[1];
                traingle.point3 = clicks[2];
                traingle.Make();
                shapes.Add(traingle);
                
                ListBoxItem itm = new ListBoxItem();
                itm.Content = number+" Triangle Point A: " + clicks[0] + " Point B: " + clicks[1] + " Point C: " + clicks[2];
                number++;
                Shapes.Items.Add(itm);

                currentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if (clicks.Count == 4 && method == 2)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.point1 = clicks[0];
                rectangle.point2 = clicks[1];
                rectangle.point3 = clicks[2];
                rectangle.point4 = clicks[3];
                rectangle.Make();
                shapes.Add(rectangle);

                ListBoxItem itm = new ListBoxItem();
                itm.Content = number + " Rectangle Point A: " + clicks[0] + " Point B: " + clicks[1]+ " Point B: " + clicks[1]+ " Point B: " + clicks[1];
                number++;
                Shapes.Items.Add(itm);

                currentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if (clicks.Count == 5 && method == 3)
            {
                Pentagon pentagon = new Pentagon(clicks[0], clicks[1], clicks[2], clicks[3], clicks[4]);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Pentagon Point A: " + clicks[0] + " Point B: " + clicks[1] + " Point C: " + clicks[2] + " Point D: " + clicks[3] + " Point E: " + clicks[4];
                Shapes.Items.Add(itm);
                currentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }

        }

        private void Button_Circle(object sender, RoutedEventArgs e)
        {
            method = 0;
            clicks.Clear();
            currentActiviti.Content = "Choose center point";
        }
        
        private void Button_Triangle(object sender, RoutedEventArgs e)
        {
            method = 1;
            clicks.Clear();
            currentActiviti.Content = "Choose 1 point";
        }
        private void Button_Rectangle(object sender, RoutedEventArgs e)
        {
            method = 2;
            clicks.Clear();
            currentActiviti.Content = "Choose 1 point";  
        }

        private void Button_Pentagon(object sender, RoutedEventArgs e)
        {
            method = 3;
            clicks.Clear();
            currentActiviti.Content = "Choose 1 point";
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            mainCanvas.Children.Clear();
            area.Content = "";
            perimeter.Content = "";

            Object obj = Shapes.SelectedItem;
            Shapes.Items.Remove(obj);
        }

        private void Change(object sender, SelectionChangedEventArgs e)
        {
            Object obj = Shapes.SelectedItem;
            
            Triangle traingle = new Triangle();
            traingle.Make();
            Console.WriteLine(obj);
            area.Content = "1";
        }
    }
}
