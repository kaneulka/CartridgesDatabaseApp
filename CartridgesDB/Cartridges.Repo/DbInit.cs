using Cartridges.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartridges.Repo
{
    public class DbInit
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationContext context)
        {
            if (!context.Bill.Any())
            {
                context.Bill.AddRange(
                    new Bill
                    {
                        Name = "Забаланс",
                        BillNumber = 102,
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Bill
                    {
                        Name = "Баланс",
                        BillNumber = 105,
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
            if (!context.Building.Any())
            {
                context.Building.AddRange(
                    new Building
                    {
                        Name = "101",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Building
                    {
                        Name = "102",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Building
                    {
                        Name = "СЗ",
                        OtherNames = "АЗ, служебное здание, служебного здания",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Building
                    {
                        Name = "АТЗ",
                        OtherNames = "105, административно-техническое здание",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
            if (!context.Department.Any())
            {
                context.Department.AddRange(
                    new Department
                    {
                        Name = "1",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "2",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "3",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "4",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "5",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "6",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "7",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "8",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Department
                    {
                        Name = "9",
                        OtherNames = "",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
