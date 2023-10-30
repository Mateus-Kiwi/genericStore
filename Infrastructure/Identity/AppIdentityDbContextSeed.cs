using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = " Bob",
                    Email = "bob@sesi.com",
                    UserName = "bob_",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Rust",
                        Street = "Rua do Bob",
                        City = "Florianópolis",
                        State = "SC",
                        ZipCode = "04958590789"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}