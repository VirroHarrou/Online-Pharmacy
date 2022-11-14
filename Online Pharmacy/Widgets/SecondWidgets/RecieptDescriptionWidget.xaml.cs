using Online_Pharmacy.Models;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Online_Pharmacy.Widgets.SecondWidgets
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class RecieptDescriptionWidget : Page
    {
        Reciept reciept = new Reciept();
        float Sale = 0;

        public RecieptDescriptionWidget()
        {
            this.InitializeComponent();

            App.recieptSelect.recieptUpdated += _RecieptUpdated;
        }

        private void _RecieptUpdated(Reciept reciept)
        {
            Sale = 0;
            this.reciept = reciept;
            Sale += App.recieptSelect.Sale;
            UpdateRicept(Sale);
            button.IsEnabled = true;
        }

        private void UpdateRicept(float sale)
        {
            float sum = reciept.Sum - sale;
            if(sum < 0)
                sum = 0;
            PriceText.Text = string.Format("Общая стоимость: {0:c2}\nСкидка: {1:c2}\n\n\nКоличество товаров: {2}\n\n Итого: {3:c2}",
                reciept.Sum, sale, reciept.ConstraintList.Count, sum);
        }

        private void ButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Reciept item = context.Reciepts.FirstOrDefault(p => p.Id == reciept.Id);
                reciept.Sum -= Sale;
                item.Sum = reciept.Sum;
                if (item.Sum < 0)
                    item.Sum = 0;
                item.Date = DateTime.Now;
                context.SaveChanges();
                foreach (Constraint medicament in reciept.ConstraintList)
                {
                    medicament.Medicament.Count -= 1;
                }
                item.ConstraintList = reciept.ConstraintList;
                context.SaveChanges();
                App.recieptSelect.DeleteReciept(reciept);
                button.IsEnabled = false;
            }
        }
    }
}
