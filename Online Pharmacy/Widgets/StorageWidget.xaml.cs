using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Online_Pharmacy.Widgets
{
    public sealed partial class StorageWidget : Page
    {
        private List<Medicament> medicaments;
        public static MedicamentSelect medicamentSelect;

        public StorageWidget()
        {
            this.InitializeComponent();

            UpdateList();
            UpdateList("");

            medicamentSelect = new MedicamentSelect();
            medicamentSelect.Select(new Medicament());
        }

        private void findTextTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList(findText.Text.ToLower());
        }

        private void ViewListItemClick(object sender, ItemClickEventArgs e)
        {
            Medicament med = sender as Medicament;
            
            medicamentSelect.Select(med);
        }

        private void UpdateList()
        {
            medicaments = new List<Medicament>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var medicaments = db.Medicaments.ToList();
                foreach (Medicament medicament in medicaments)
                {
                    this.medicaments.Add(medicament);
                }
            }
        }

        private void UpdateList(string select)
        {
            ViewList.Items.Clear();
            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Name.ToLower().IndexOf(select) != -1)
                {
                    ViewList.Items.Add(Name = medicament.Name);
                }
            }
        }
    }
}
