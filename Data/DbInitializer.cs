using System;
using Core.Entities;
using Core.Helpers;
using Data.Contents;

namespace Data
{
    public class DbInitializer
    {
        static int id;
        public static void SeedAdmins()
        {
            var admins = new List<Admin>
            {
                new Admin
                {
                    Id=++id,
                    username="admin1",
                    password = PasswordHasher.Encyrpt("12345671"),
                },

                new Admin
                {
                    Id=++id,
                    username="admin2",
                    password = PasswordHasher.Encyrpt("12345672"),
                },

                new Admin
                {
                    Id=++id,
                    username="admin3",
                    password = PasswordHasher.Encyrpt("12345673"),
                }
            };

            DbContent.Admins.AddRange(admins);
        }
    }
}

