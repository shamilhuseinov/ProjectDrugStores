using System;
using Data.Repository.Abstract;
using Core.Entities;
using Data.Contents;

namespace Data.Repository.Concrete
{
	public class OwnerRepository:IOwnerRepository
	{
		public void Create(Owner owner)
		{
			DbContent.Owners.Add(owner);
		}

		public void Update(Owner owner)
		{
			var dbOwner = DbContent.Owners.FirstOrDefault(o => o.Id == owner.Id);
			if (dbOwner != null)
			{
				dbOwner.Name = owner.Name;
				dbOwner.Surname = owner.Surname;
				dbOwner.Drugstores = owner.Drugstores;
			}
		}

		public void Delete(Owner owner)
		{
			DbContent.Owners.Remove(owner);
		}

		public Owner Get(int id)
		{
			return DbContent.Owners.FirstOrDefault(o => o.Id == id);
		}

        public List<Owner> GetAll()
        {
            return DbContent.Owners;
        }
    }
}

