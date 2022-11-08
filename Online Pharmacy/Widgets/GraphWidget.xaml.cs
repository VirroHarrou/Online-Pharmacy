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
        }

        private List<Reciept> reciepts; 

        private void canvasDraw()
        {

            double canvasHeight = canvas.Height;
            double canvasWight = canvas.Width;

            Line line = new Line();
            
            line.X1 = 0;
            line.Y1 = canvasHeight / 10;
            line.X2 = canvas.Width;
            line.Y2 = canvasWight / 10;

            line.StrokeThickness = 2;

            canvas.Children.Add(line);
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
            foreach (Reciept reciept in reciepts)
            {
                Console.WriteLine(reciept);
            }
        }

        private void Grid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            canvasDraw();
        }
    }
}
