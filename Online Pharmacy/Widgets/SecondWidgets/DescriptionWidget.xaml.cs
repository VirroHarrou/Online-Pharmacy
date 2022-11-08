using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
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
            //MedicamentSelect select = new MedicamentSelect();
            //select.MedicamentChanged += MedicamentSelect_MedicamentChanged;
        }

        public void MedicamentSelect_MedicamentChanged(Medicament medicament)
        {
            UpdateDescription(medicament);
        }

        public void UpdateDescription(Medicament medicament)
        {
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            //bitmapImage.UriSource = new Uri(img.BaseUri, medicament.Name);
            img.Source = bitmapImage;

            image = img;

            description.Text = medicament.Description;
            sale.Text = medicament.Price.ToString();
        }
    }
}
