using System;
using Core.Entities;

namespace Data.Repository.Abstract
{
	public interface IRepository<T>where T:BaseEntity
	{
		void Create(T item);

		void Update(T item);

		void Delete(T item);

		List<T> GetAll();
	}
}

