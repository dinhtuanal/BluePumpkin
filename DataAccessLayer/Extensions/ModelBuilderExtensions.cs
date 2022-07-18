using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            #region tạo tài khoản và quyền
            //Tao quyen admin
            var roleId = "8D04DCE2-969A-435D-BBA4-DF3F325983DC";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
            });
            var userId = "69BD714F-9576-45BA-B5B7-F00649BE00DE";
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = "dinhtuanal",
                NormalizedUserName = "dinhtuanal",
                BirtthDay = new DateTime(2001, 06, 29),
                Email = "dinhtuanal@gmail.com",
                NormalizedEmail = "dinhtuanal@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                PhoneNumber = "0999686888"
            });
            // gan quyen admin cho user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId,
            });
            #endregion
        }
    }
}
