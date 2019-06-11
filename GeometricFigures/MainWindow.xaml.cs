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
        List<Point> clicks = new List<Point>();
        enum Info
        {
            
        }

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
            CurrentActiviti.Content = "Choose "+(clicks.Count+1)+" point";

            if(method==-1)
                CurrentActiviti.Content = "Choose shape";
            else if (clicks.Count == 2 && method == 0)
            {
                double r = Math.Sqrt(Math.Pow(clicks[0].X - clicks[1].X, 2) + Math.Pow(clicks[0].Y - clicks[1].Y, 2));
                Circlee circle = new Circlee(clicks[0], r);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Circle Center: " + clicks[0] + " Radius: " + r;
                Shapes.Items.Add(itm);
                CurrentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if(clicks.Count==3 && method ==1)
            {
                Trianglee traingle = new Trianglee(clicks[0], clicks[1], clicks[2]);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Triangle Point A: " + clicks[0] + " Point B: " + clicks[1] + " Point C: " + clicks[2];
                Shapes.Items.Add(itm);
                CurrentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if (clicks.Count == 4 && method == 2)
            {
                Rectanglee rectangle = new Rectanglee(clicks[0], clicks[1], clicks[2], clicks[3]);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Rectangle Point A: " + clicks[0] + " Point B: " + clicks[1]+ " Point B: " + clicks[1]+ " Point B: " + clicks[1];
                Shapes.Items.Add(itm);
                CurrentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }
            else if (clicks.Count == 5 && method == 3)
            {
                Pentagonn pentagon = new Pentagonn(clicks[0], clicks[1], clicks[2], clicks[3], clicks[4]);
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "Pentagon Point A: " + clicks[0] + " Point B: " + clicks[1] + " Point C: " + clicks[2] + " Point D: " + clicks[3] + " Point E: " + clicks[4];
                Shapes.Items.Add(itm);
                CurrentActiviti.Content = "Tadow!";
                method = -1;
                clicks.Clear();
            }

        }

        private void Button_Circle(object sender, RoutedEventArgs e)
        {
            method = 0;
            clicks.Clear();
            CurrentActiviti.Content = "Choose center point";
        }
        
        private void Button_Triangle(object sender, RoutedEventArgs e)
        {
            method = 1;
            clicks.Clear();
            CurrentActiviti.Content = "Choose 1 point";
        }
        private void Button_Rectangle(object sender, RoutedEventArgs e)
        {
            method = 2;
            clicks.Clear();
            CurrentActiviti.Content = "Choose 1 point";  
        }

        private void Button_Pentagon(object sender, RoutedEventArgs e)
        {
            method = 3;
            clicks.Clear();
            CurrentActiviti.Content = "Choose 1 point";
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            //Item not selected CANNOT DO (IF)
            Shapes.Items.Clear();
            mainCanvas.Children.Clear();
            area.Content = "";
            perimeter.Content = "";
        }

        private void ChangeItem(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("asdf");
        }
    }

    public interface IShape 
    {
        double Area();
        double Perimeter();
    }
    public class Circlee : IShape
    {
        private double radius;
        private const double PI = Math.PI;

        MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        
        public Circlee(Point point1, double radius)
        {
            this.radius = radius;

            main.area.Content = "Area: " + Area();
            main.perimeter.Content = "Perimeter: " + Perimeter();

            Ellipse elipse = new Ellipse();
            elipse.Width = radius;
            elipse.Height = radius;
            elipse.SetValue(Canvas.LeftProperty, point1.X);
            elipse.SetValue(Canvas.TopProperty, point1.Y);

            main.mainCanvas.Children.Add(elipse);


            //Additional settings:
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.Colors.SelectedValue).Content.ToString());
            elipse.Fill = brush;
            brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.StrokeColors.SelectedValue).Content.ToString());
            elipse.Stroke = brush;
            string s = ((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString();
            elipse.StrokeThickness = double.Parse(((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString());
        }
        public double Area()
        {
            return PI * Math.Pow(radius, 2);
        }
        public double Perimeter()
        {
            return 2 * PI * radius;
        }
    }
    public class Trianglee : IShape
    {
        private double a, b, c;

        MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Trianglee(Point point1, Point point2, Point point3)
        {
            a = Math.Sqrt(Math.Pow(point2.X - point1.X,2) + Math.Pow(point2.Y-point1.Y,2));
            b = Math.Sqrt(Math.Pow(point2.X - point3.X, 2) + Math.Pow(point2.Y - point3.Y, 2));
            c = Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2));

            main.area.Content = "Area: " + Area();
            main.perimeter.Content = "Perimeter: " + Perimeter();


            Polygon triangle = new Polygon();
            main.mainCanvas.Children.Add(triangle);
            Console.WriteLine(point1.X);

            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(point1);
            polygonPoints.Add(point2);
            polygonPoints.Add(point3);

            triangle.Points = polygonPoints;

            //Additional settings:
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.Colors.SelectedValue).Content.ToString());
            triangle.Fill = brush;
            brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.StrokeColors.SelectedValue).Content.ToString());
            triangle.Stroke = brush;
            string s = ((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString();
            triangle.StrokeThickness = double.Parse(((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString());
        }
        public double Area()
        {
            double s = (a+b+c)/2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public double Perimeter()
        {
            return a + b + c;
        }
    }
    public class Rectanglee : IShape
    {
        private double a,b,c,d;

        MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Rectanglee(Point point1, Point point2, Point point3, Point point4)
        {
            a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
            c = Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2));
            d = Math.Sqrt(Math.Pow(point1.X - point4.X, 2) + Math.Pow(point1.Y - point4.Y, 2));

            System.Windows.Shapes.Polygon rectangle = new System.Windows.Shapes.Polygon();
            
            PointCollection rectaglePoints = new PointCollection();
            rectaglePoints.Add(point1);
            rectaglePoints.Add(point2);
            rectaglePoints.Add(point3);
            rectaglePoints.Add(point4);
            rectangle.Points = rectaglePoints;
            main.mainCanvas.Children.Add(rectangle);

            main.perimeter.Content = "Perimeter: " + Perimeter();
            main.area.Content = "Area " + Area(rectaglePoints);

            //Additional settings:
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.Colors.SelectedValue).Content.ToString());
            rectangle.Fill = brush;
            brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.StrokeColors.SelectedValue).Content.ToString());
            rectangle.Stroke = brush;
            string s = ((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString();
            rectangle.StrokeThickness = double.Parse(((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString());

           
        }
        public double Area()
        {
            return 0;
        }
        public double Area(PointCollection points)
        {
            return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
        }
        public double Perimeter()
        {
            return a + b + c + d;
        }
    }
    public class Pentagonn : IShape
    {
        private double a, b, c, d, e;

        MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        public Pentagonn(Point point1, Point point2, Point point3, Point point4, Point point5)
        {
            a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
            c = Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2));
            d = Math.Sqrt(Math.Pow(point5.X - point4.X, 2) + Math.Pow(point5.Y - point4.Y, 2));
            e = Math.Sqrt(Math.Pow(point1.X - point5.X, 2) + Math.Pow(point1.Y - point5.Y, 2));

            


            Polygon polygon = new Polygon();
            main.mainCanvas.Children.Add(polygon);

            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(point1);
            polygonPoints.Add(point2);
            polygonPoints.Add(point3);
            polygonPoints.Add(point4);
            polygonPoints.Add(point5);
            polygon.Points = polygonPoints;

            main.area.Content = "Area " + Area(polygonPoints);
            main.perimeter.Content = "Perimeter: " + Perimeter();

            //Additional settings:
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.Colors.SelectedValue).Content.ToString());
            polygon.Fill = brush;
            brush = (Brush)bc.ConvertFrom(((ListBoxItem)main.StrokeColors.SelectedValue).Content.ToString());
            polygon.Stroke = brush;
            string s = ((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString();
            polygon.StrokeThickness = double.Parse(((ListBoxItem)main.StrokeSize.SelectedValue).Content.ToString());
        }
        public double Area()
        {
            return 0;
        }
        public double Area(PointCollection points)
        {
            return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
        }
        public double Perimeter()
        {
            return a + b + c + d + e;
        }
    }
}
