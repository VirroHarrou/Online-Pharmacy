﻿using Online_Pharmacy.Classes;
using Online_Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class RecieptWidget : Page
    {
        private Reciept reciept = new Reciept();

        private List<Medicament> ListMedicament = new List<Medicament>();
        bool procentSale = false;

        public RecieptWidget()
        {
            this.InitializeComponent();

            UpdateList();
            UpdateList("");

            App.recieptSelect.recieptDeleted += RecieptSelect_recieptUpdated;
            ViewList.SelectionChanged += ViewListItemClick;
        }

        private void RecieptSelect_recieptUpdated(Reciept reciept)
        {
            ListMedicament.Clear();
            UpdateList("");
            App.recieptSelect.recieptUpdated -= RecieptSelect_recieptUpdated;
        }

        private void ButtonRubls_Click(object sender, RoutedEventArgs e)
        {
            procentSale = false;
            UpdateRiciept();
        }

        private void ButtonProcent_Click(object sender, RoutedEventArgs e)
        {
            procentSale = true;
            UpdateRiciept();
        }

        private void ViewListItemClick(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            Medicament med = lv.SelectedItem as Medicament;
            if (med != null && findText.Text != "")
                reciept.MedicamentList.Add(med);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList(findText.Text.ToLower());
        }

        private void SaleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Sale.Text == "")
                Sale.Text = "0";
            UpdateRiciept();
        }

        private void UpdateList()
        {
            reciept.MedicamentList = new List<Medicament>();

            using (ApplicationContext db = new ApplicationContext())
            {
                var medicaments = db.Medicaments.ToList();
                foreach (Medicament medicament in medicaments)
                {
                    ListMedicament.Add(medicament);
                }
            }
        }

        private void UpdateList(string select)
        {
            if (select == "")
            {
                UpdateRiciept();
                return;
            }
            ViewList.Items.Clear();
            foreach (Medicament medicament in ListMedicament)
            {
                if (medicament.Name.ToLower().IndexOf(select) != -1)
                {
                    ViewList.Items.Add(medicament);
                }
            }
        }

        private void UpdateRiciept()
        {
            ViewList.Items.Clear();
            reciept.Sum = 0;
            foreach (Medicament medicament in reciept.MedicamentList)
            {
                reciept.Sum += medicament.Price;
                ViewList.Items.Add(medicament);
            }
            if (float.TryParse(Sale.Text, out float sale))
            {
                if (procentSale)
                    sale = reciept.Sum / 100 * sale;

                App.recieptSelect.Sale = sale;
            }
                
            App.recieptSelect.UpdateReciept(reciept);
        }
    }
}
