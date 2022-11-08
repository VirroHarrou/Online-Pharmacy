using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StorageMenuWidget : Page
    {
        public StorageMenuWidget()
        {
            this.InitializeComponent();
            MainPage mainPage = (MainPage)this.Parent;
            //mainPage.SecondWidget.Navigate(typeof(RecipetDescriptionWidget));
        }
    }
}
