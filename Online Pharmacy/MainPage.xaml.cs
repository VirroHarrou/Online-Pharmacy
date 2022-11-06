using Online_Pharmacy.Widgets;
using Online_Pharmacy.Widgets.SecondWidgets;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Online_Pharmacy
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MainWidget.Navigate(typeof(GraphWidget));
            SecondWidget.Navigate(typeof(ReportWidget));
        }

        private void HomeTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MainWidget.Navigate(typeof(GraphWidget));
            SecondWidget.Navigate(typeof(ReportWidget));
        }

        private void CatalogTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MainWidget.Navigate(typeof(ListViewWidget));
            SecondWidget.Navigate(typeof(DescriptionWidget));
        }

        private void RecieptTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MainWidget.Navigate(typeof(RecieptWidget));
            SecondWidget.Navigate(typeof(RecipetDescriptionWidget));
        }
    }
}
