using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
using Online_Pharmacy.Widgets.SecondWidgets;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Online_Pharmacy.Widgets
{
    public sealed partial class ListViewWidget : Page
    {
        private List<Medicament> medicaments;

        DescriptionWidget description;

        public ListViewWidget()
        {
            this.InitializeComponent();

            UpdateList();
            UpdateList("");

            ViewList.SelectionChanged += ViewListItemClick;
        }

        private void ViewListItemClick(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            Medicament med = lv.SelectedItem as Medicament;
            MedicamentSelect medicamentSelect = new MedicamentSelect();
            description.MedicamentSelect_MedicamentChanged(med);
            medicamentSelect.Select(med);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList(findText.Text.ToLower());
        }

        private void UpdateList()
        {
            medicaments = new List<Medicament>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var medicaments = db.Medicaments.ToList();
                foreach(Medicament medicament in medicaments)
                {
                    this.medicaments.Add(medicament);
                }
            }
        }

        private void UpdateList(string select)
        {
            ViewList.Items.Clear();
            foreach(Medicament medicament in medicaments)
            {
                if(medicament.Name.ToLower().IndexOf(select) != -1)
                {
                    ViewList.Items.Add(medicament);
                }
            }
        }
    }
}
