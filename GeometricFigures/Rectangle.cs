using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GeometricFigures
{
    class Rectangle : IShape
    {
        public Point point1;
        public Point point2;
        public Point point3;
        public Point point4;

        public Rectangle()
        {
            
        }
        public void Make()
        {
            MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;
            System.Windows.Shapes.Polygon rectangle = new System.Windows.Shapes.Polygon();

            PointCollection rectaglePoints = new PointCollection();
            rectaglePoints.Add(point1);
            rectaglePoints.Add(point2);
            rectaglePoints.Add(point3);
            rectaglePoints.Add(point4);
            rectangle.Points = rectaglePoints;
            main.mainCanvas.Children.Clear();
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
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)) + Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2)) + Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2)) + Math.Sqrt(Math.Pow(point1.X - point4.X, 2) + Math.Pow(point1.Y - point4.Y, 2));
        }
    }
}
