using Online_Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.IO;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ReportWidget : Windows.UI.Xaml.Controls.Page
    {
        List<Reciept> reciepts;
        float PriceStorage = 0;

        public ReportWidget()
        {
            this.InitializeComponent();

            UpdateData();
            LoadForm();
        }

        private void UpdateData()
        {
            reciepts = new List<Reciept>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var item = db.Reciepts.Where(p => p.Date.Day == DateTime.Now.Day);
                reciepts = item.ToList();

                var item2 = db.Medicaments.ToList();
                foreach(Medicament medicament in item2)
                {
                    PriceStorage += medicament.Price * medicament.Count;
                }
            }
        }

        private void LoadForm()
        {
            int count = 0;
            float sum = 0;
            foreach(Reciept reciept in reciepts)
            {
                sum += reciept.Sum;
                count++;
            }

            block1Description.Text = "Средний чек за сегодня";
            block2Description.Text = "Чеков сегодня";
            block3Description.Text = "Товаров осталось на складе на сумму";

            block1Count.Text = String.Format("{0:c2}", sum / count);
            block2Count.Text = count.ToString();
            block3Count.Text = String.Format("{0:c2}", PriceStorage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListToExcel(reciepts);
        }

        private void ListToExcel(List<Reciept> reciepts)
        {
            Application excelApp = new Application();

            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            _Worksheet workSheet = (_Worksheet)excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Дата";
            workSheet.Cells[1, "B"] = "Сумма";
            workSheet.Cells[1, "C"] = "Количество лекарств";

            string data = File.ReadAllText(@"data.txt", Encoding.Default);

            int datas = Convert.ToInt32(data);
            int row = 1;
            foreach (Reciept c in reciepts)
            {
                row++;
                workSheet.Cells[datas, "A"] = c.Date;
                workSheet.Cells[datas, "B"] = c.Sum;
                workSheet.Cells[datas, "C"] = c.ConstraintList.Count;
            }
        }
    }
}
