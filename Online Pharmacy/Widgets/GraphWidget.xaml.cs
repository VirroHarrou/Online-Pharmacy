using Microsoft.EntityFrameworkCore;
using Online_Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class GraphWidget : Page
    {
        public GraphWidget()
        {
            this.InitializeComponent();

            UpdateData();
            canvas.Tapped += Canvas_Tapped;
        }

        private void Canvas_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            canvasDraw();
        }

        private List<Reciept> reciepts; 

        private void canvasDraw()
        {

            double canvasHeight = 700;
            double canvasWight = 1000;
            double MinHeight = canvasHeight - canvasHeight / 10;

            Line line = new Line();
            
            line.X1 = 0;
            line.Y1 = MinHeight;
            line.X2 = canvasWight;
            line.Y2 = MinHeight;

            line.StrokeThickness = 2;
            line.Stroke = new SolidColorBrush(Color.FromArgb(255,36,36,36));

            canvas.Children.Add(line);

            int max = 3000;
            foreach (Reciept reciept in reciepts)
            {
                
                Rectangle rectangle = new Rectangle();
                rectangle.Height = (max / reciept.Sum) * 15;
                rectangle.Width = 45;
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 36, 36, 36));
                canvas.Children.Add(rectangle);
            }
        }

        private void UpdateData()
        {
            reciepts = new List<Reciept>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var Reciepts = db.Reciepts.ToList();
                foreach(Reciept reciept in Reciepts)
                {
                    if(reciept.Date < DateTime.Now && reciept.Date > DateTime.Now.AddDays(-14))
                    reciepts.Add(reciept);
                }
            }
            canvasDraw();
        }
    }
}
