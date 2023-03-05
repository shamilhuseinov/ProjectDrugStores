using System;
using Core.Entities;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class DrugRepository : IDrugRepository
    {
        public void Create(Drug drug)
        {
            DbContent.Drugs.Add(drug);
        }

        public void Update(Drug drug)
        {
            var dbDrug = DbContent.Drugs.FirstOrDefault(d => d.Id == drug.Id);
            dbDrug.Name = drug.Name;
            dbDrug.Price = drug.Price;
            dbDrug.Count = drug.Count;
            dbDrug.DrugStore = drug.DrugStore;
        }

        public void Delete(Drug drug)
        {
            DbContent.Drugs.Remove(drug);
        }

        public Drug Get(int id)
        {
            return DbContent.Drugs.FirstOrDefault(d => d.Id == id);
        }

        public List<Drug> GetAll()
        {
            return DbContent.Drugs;
        }
    }
}

