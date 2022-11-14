using Online_Pharmacy.Models;
using System.Collections.Generic;

namespace Online_Pharmacy.Classes
{
    public class RecieptSelect
    {
        public List<Reciept> reciepts { get; set; }
        public Reciept reciept { get; set; }
        public float Sale { get; set; }

        public delegate void RecieptListHandler(List<Reciept> reciepts);
        public event RecieptListHandler recieptListUpdated;

        public delegate void RecieptHandler(Reciept reciept);
        public event RecieptHandler recieptUpdated;
        public event RecieptHandler recieptDeleted;


        public void SelectReciepts(List<Reciept> reciepts)
        {
            this.reciepts = reciepts;
            recieptListUpdated?.Invoke(reciepts);
        }

        public void UpdateReciept(Reciept reciept)
        {
            this.reciept = reciept;
            recieptUpdated?.Invoke(reciept);
        }

        public void DeleteReciept(Reciept reciept)
        {
            this.reciept.ConstraintList.Clear();
            recieptDeleted?.Invoke(reciept);
        }
    }
}
