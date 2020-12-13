using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAlexeev90321.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.RadioComponentGroups.Any())
            {
                context.RadioComponentGroups.AddRange(
                new List<RadioComponentGroup>
                {
                new RadioComponentGroup {GroupName="Резисторы"},
                new RadioComponentGroup {GroupName="Диоды"},
                new RadioComponentGroup {GroupName="Шнуры"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.RadioComponents.Any())
            {
                context.RadioComponents.AddRange(
                new List<RadioComponent>
                {
                    new RadioComponent {RadioComponentName="Диод быстропереключающий BAV199", Description = "0.14А, 85В, SOT-23", Price=2500,RadioComponentGroupId=2, Image="diod.jpg"},
                    new RadioComponent {RadioComponentName="Диод DGPE30-E3/54",Description = "3А, 1400В, DO-201", Price=2500,RadioComponentGroupId=2, Image="diod2.jpg"},
                    new RadioComponent {RadioComponentName="Шнур STA-201A ",Description = "штекер HDMI на штекер HDMI 1м", Price=180,RadioComponentGroupId=3, Image="hdmi.jpg"},
                    new RadioComponent {RadioComponentName="Резистор выводной 39R ", Description = " 5W ±5% / RX27-1 (SQP)", Price=120,RadioComponentGroupId=1, Image="rez.jpg"},
                    new RadioComponent {RadioComponentName="Шнур MicroUSB M USB-A M 1.8m ",Description = "/ штекер USB A на штекер micro USB B 1.8м", RadioComponentGroupId=3, Price=340, Image="usb.jpg"},
                    new RadioComponent {RadioComponentName="Шнур CAB-C-3/1",Description = "3в1, micro USB, Lightning, Type C", RadioComponentGroupId=3, Price=66, Image="usb2.jpg"}
                });
                await context.SaveChangesAsync();
            }


        }
    }
}
