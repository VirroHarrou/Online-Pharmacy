using Online_Pharmacy.Models;
using Online_Pharmacy.Widgets.SecondWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ListViewWidget : Page
    {
        public ListViewWidget()
        {
            this.InitializeComponent();

            UpdateList();
            UpdateList("");

            ViewList.ItemClick += ViewListItemClick;
        }

        private void ViewListItemClick(object sender, ItemClickEventArgs e)
        {
            Medicament med = sender as Medicament;
            DescriptionWidget description;
            
        }

        private List<Medicament> medicaments;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList(findText.Text);
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
