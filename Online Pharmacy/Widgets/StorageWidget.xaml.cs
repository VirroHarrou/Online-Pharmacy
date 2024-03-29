﻿using Online_Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Online_Pharmacy.Widgets
{
    public sealed partial class StorageWidget : Page
    {
        private List<Medicament> medicaments;

        public StorageWidget()
        {
            this.InitializeComponent();

            UpdateList();
            UpdateList("");

            ViewList.SelectionChanged += ViewListItemClick;
        }

        private void findTextTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList(findText.Text.ToLower());
        }

        private void ViewListItemClick(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            Medicament med = lv.SelectedItem as Medicament;
            if (med != null)
                App.medicamentSelect.Select(med);
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
                    ViewList.Items.Add(medicament);
                }
            }
        }
    }
}
