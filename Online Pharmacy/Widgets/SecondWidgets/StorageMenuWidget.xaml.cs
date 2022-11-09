using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
using System.Linq;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StorageMenuWidget : Page
    {
        MedicamentSelect ms = App.medicamentSelect;
        public StorageMenuWidget()
        {
            this.InitializeComponent();

            ms.MedicamentChanged += MedicamentSelectMedicamentChanged;
        }

        private int? Id = null;

        private void MedicamentSelectMedicamentChanged(Medicament medicament)
        {
            Name.Text = medicament.Name;
            Description.Text = medicament.Description;
            Price.Text = medicament.Price.ToString();
            Id = medicament.Id;
        }

        private void ButtonCreateClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Medicament medicament = new Medicament();
            ApplicationContext application = new ApplicationContext();

            if (Id != null)
                medicament = application.Medicaments.Where(p => p.Id == Id) as Medicament;

            medicament.Name = Name.Text;
            medicament.Description = "Назначение: " + Description.Text;

            if (float.TryParse(Price.Text, out var number))
                medicament.Price = float.Parse(Price.Text);

            if (Id == null)
                application.Add(medicament);
            application.SaveChanges();
        }
    }
}
