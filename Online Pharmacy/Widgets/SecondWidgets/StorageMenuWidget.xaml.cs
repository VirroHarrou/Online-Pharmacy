using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StorageMenuWidget : Page
    {
        MedicamentSelect ms = StorageWidget.medicamentSelect;
        public StorageMenuWidget()
        {
            this.InitializeComponent();

            ms.MedicamentChanged += MedicamentSelectMedicamentChanged;
        }

        private void MedicamentSelectMedicamentChanged(Medicament medicament)
        {
            
            description.Text = medicament.Description;
            characteristics.Text = "Наименование: " + medicament.Name + "\n Стоимость: " + medicament.Price;
        }

        private void ButtonCreateClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Medicament medicament = new Medicament();
            medicament.Name = "Бронхо-мунал";
            medicament.Price = 584.00f;
            medicament.Description = "Назначение: " + "лечение острых респираторных инфекций верхних дыхательных путей";
            ApplicationContext application = new ApplicationContext();
            application.Add(medicament);
            application.SaveChanges();
        }

        private void ButtonUpdateClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}
