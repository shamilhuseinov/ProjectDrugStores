using System;
using Core.Entities;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class DruggistRepository : IDruggistRepository
    {
        public void Create(Druggist druggist)
        {
            DbContent.Druggists.Add(druggist);
        }

        public void Update(Druggist druggist)
        {
            var dbDruggist = DbContent.Druggists.FirstOrDefault(d => d.Id == druggist.Id);
            dbDruggist.Name = druggist.Name;
            dbDruggist.Surname = druggist.Surname;
            dbDruggist.Age = druggist.Age;
            dbDruggist.Experience = druggist.Experience;
            dbDruggist.DrugStore = druggist.DrugStore;
        }

        public void Delete(Druggist druggist)
        {
            DbContent.Druggists.Remove(druggist);
        }

        public Druggist Get(int id)
        {
            return DbContent.Druggists.FirstOrDefault(d => d.Id == id);
        }

        public List<Druggist> GetAll()
        {
            return DbContent.Druggists;
        }
    }
}

