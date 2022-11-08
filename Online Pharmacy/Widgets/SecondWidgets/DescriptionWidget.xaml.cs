using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DescriptionWidget : Page
    {
        public DescriptionWidget()
        {
            this.InitializeComponent();
        }

        public static string ImageSource;
        public static string Description;
        public static string Sale;

        public void UpdateDescription()
        {
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(img.BaseUri, ImageSource);
            img.Source = bitmapImage;

            image = img;

            description.Text = Description;
            sale.Text = Sale;
        }
    }
}
