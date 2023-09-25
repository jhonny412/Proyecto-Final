using GestionHotelero.Entities.Helper.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GestionHotelero.DataAccess
{
    public static class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            //Repositorio de usuario
            var userManager = service.GetRequiredService<UserManager<GestionHoteleroIdentityUser>>();
            //Repositorio de Roles
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            //Creando Roles
            var adminRol = new IdentityRole(Constantes.RolAdmin);
            var customerRol = new IdentityRole(Constantes.RolCustomer);

            if (!await roleManager.RoleExistsAsync(Constantes.RolAdmin))
            {
                await roleManager.CreateAsync(adminRol);
            }

            if (!await roleManager.RoleExistsAsync(Constantes.RolCustomer))
            {
                await roleManager.CreateAsync(customerRol);
            }

            //Creamor el usuario administrador
            var adminUser = new GestionHoteleroIdentityUser
            {
                Nombre = "admin",
                Apellido = "admin",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin12345*");

            if (result.Succeeded)
            {
                //Con esto nos aseguramos que el usuatio fue creado correctamente
                adminUser = await userManager.FindByEmailAsync(adminUser.Email);

                if (adminUser is not null)
                {
                    await userManager.AddToRoleAsync(adminUser, Constantes.RolAdmin);
                }
            }
        }
    }
}