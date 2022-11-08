using Online_Pharmacy.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Online_Pharmacy.Classes
{
    public class MedicamentSelect
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private float Price { get; set; }

        public delegate void MedicamentHandler(Medicament medicament);
        public event MedicamentHandler MedicamentChanged;

        public void Select(Medicament medicament)
        {
            Id = medicament.Id;
            Name = medicament.Name; 
            Description = medicament.Description;
            Price = medicament.Price;
            MedicamentChanged?.Invoke(medicament);
        }
        public string GetName() => Name;
        public string GetDescription() => Description;
        public float GetSale() => Price;
        public int GetId() => Id;
    }
}
