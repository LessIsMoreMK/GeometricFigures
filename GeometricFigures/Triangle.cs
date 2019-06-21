using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometricFigures
{
    class Triangle : IShape
    {
        public Point point1;
        public Point point2;
        public Point point3;

        public Triangle()
        {

        }
        public void Make()
        {
            MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;
            main.area.Content = "Area: " + Area();
            main.perimeter.Content = "Perimeter: " + Perimeter();

            Polygon triangle = new Polygon();
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(point1);
            polygonPoints.Add(point2);
            polygonPoints.Add(point3);

            main.mainCanvas.Children.Clear();
            triangle.Points = polygonPoints;
            main.mainCanvas.Children.Add(triangle);

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
            double s = (Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)) + Math.Sqrt(Math.Pow(point2.X - point3.X, 2) + Math.Pow(point2.Y - point3.Y, 2)) + Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2))) / 2;
            return Math.Sqrt(s * (s - Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2))) * (s - Math.Sqrt(Math.Pow(point2.X - point3.X, 2) + Math.Pow(point2.Y - point3.Y, 2))) * (s - Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2))));
        }
        public double Perimeter()
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)) + Math.Sqrt(Math.Pow(point2.X - point3.X, 2) + Math.Pow(point2.Y - point3.Y, 2)) + Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2));
        }
    }
}
