using System;
using Core.Entities;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class DrugStoreRepository : IDrugStoreRepository
    {
        public void Create(DrugStore drugStore)
        {
            DbContent.DrugStores.Add(drugStore);
        }

        public void Update(DrugStore drugStore)
        {
            var dbDrugStore = DbContent.DrugStores.FirstOrDefault(d => d.Id == drugStore.Id);

                dbDrugStore.Name = drugStore.Name;
                dbDrugStore.Address = drugStore.Address;
                dbDrugStore.ContactNumber = drugStore.ContactNumber;
                dbDrugStore.Email = drugStore.Email;
                dbDrugStore.Druggists = drugStore.Druggists;
                dbDrugStore.Drugs = drugStore.Drugs;
                dbDrugStore.Owner = drugStore.Owner;
        }

        public void Delete(DrugStore drugStore)
        {
            DbContent.DrugStores.Remove(drugStore);
        }

        public DrugStore Get(int id)
        {
            return DbContent.DrugStores.FirstOrDefault(s => s.Id == id);
        }

        public List<DrugStore> GetAll()
        {
            return DbContent.DrugStores;
        }

        public bool IsDublicateEmail(string email)
        {
            return DbContent.DrugStores.Any(s => s.Email == email);
        }
    }
}

