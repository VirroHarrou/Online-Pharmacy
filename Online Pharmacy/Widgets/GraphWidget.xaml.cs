using Windows.UI.Xaml.Controls;
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
        }

        private void canvasDraw()
        {
            Line line = new Line();
            
            line.X1 = 0;
            line.Y1 = canvas.Height / 10;
            line.X2 = canvas.Width;
            line.Y2 = canvas.Height / 10;

            canvas.Children.Add(line);
        }

        private void Grid_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            canvasDraw();
        }
    }
}
