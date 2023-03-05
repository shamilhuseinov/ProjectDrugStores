using System;
using Core.Entities;
using Core.Helpers;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetByUserNameAndPassword(string username, string password)
        {
            return DbContent.Admins.FirstOrDefault(s => s.username.ToLower() == username.ToLower() && PasswordHasher.Decyrpt(s.password) == password);
        }
    }
}

