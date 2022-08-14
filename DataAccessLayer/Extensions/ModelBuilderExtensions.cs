using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) {
            #region add account and role
            //Role admin
            var roleId = "8D04DCE2-969A-435D-BBA4-DF3F325983DC";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
            });

            var roleStaffId = "1E0B4271-BDC6-4DFD-8190-9F992926EE72";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleStaffId,
                Name = "staff",
                NormalizedName = "staff",
            });

            // Seed data admin 1
            var userId = "69BD714F-9576-45BA-B5B7-F00649BE00DE";
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = "dinhtuanal",
                NormalizedUserName = "dinhtuanal",
                FirstName = "Le Dinh",
                LastName =  "Tuan",
                Gender = Gender.Male,
                Country = "Quang Tri, Viet Nam",
                BirtthDay = new DateTime(2001, 06, 29),
                Email = "dinhtuanal@gmail.com",
                NormalizedEmail = "dinhtuanal@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                PhoneNumber = "0999686888"
            });
            // assign role admin for user 1
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId,
            });

            // Seed data admin 1
            var userId2 = "47ACE1B1-5476-41AA-A41D-0CE223F5A45C";
            var hasher2 = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId2,
                UserName = "hoangvanviet",
                NormalizedUserName = "hoangvanviet",
                FirstName = "Hoang Van",
                LastName = "Viet",
                Gender = Gender.Male,
                Country = "Dak Lak, Viet Nam",
                BirtthDay = new DateTime(1991, 01, 01),
                Email = "hoangvanviet@gmail.com",
                NormalizedEmail = "hoangvanviet@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher2.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                PhoneNumber = "0888444777"
            });
            // assign role admin for user 1
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId2,
            });


            #endregion
        }
    }
}
