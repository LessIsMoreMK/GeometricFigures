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
    class Circle : IShape
    {
        private double radius;
        private const double PI = Math.PI;

        public Circle(Point point1, double radius)
        {
            this.radius = radius;
            MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;
            main.area.Content = "Area: " + Area();
            main.perimeter.Content = "Perimeter: " + Perimeter();

            Ellipse elipse = new Ellipse();
            elipse.Width = radius * 2;
            elipse.Height = radius * 2;
            elipse.SetValue(Canvas.LeftProperty, point1.X);
            elipse.SetValue(Canvas.TopProperty, point1.Y);
            Canvas.SetTop(elipse, point1.Y - (elipse.Height / 2));
            Canvas.SetLeft(elipse, point1.X - (elipse.Width / 2));

            main.mainCanvas.Children.Clear();
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
}



