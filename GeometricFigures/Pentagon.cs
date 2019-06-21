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
    class Pentagon : IShape
    {
        private double a, b, c, d, e;

        public Pentagon(Point point1, Point point2, Point point3, Point point4, Point point5)
        {
            a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
            c = Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2));
            d = Math.Sqrt(Math.Pow(point5.X - point4.X, 2) + Math.Pow(point5.Y - point4.Y, 2));
            e = Math.Sqrt(Math.Pow(point1.X - point5.X, 2) + Math.Pow(point1.Y - point5.Y, 2));
            MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;
            Polygon polygon = new Polygon();
            main.mainCanvas.Children.Clear();
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
