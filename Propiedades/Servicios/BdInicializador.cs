using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Propiedades.Data;

namespace Propiedades.Servicios
{
    public class BdInicializador : IBdInicializador
    {
        private readonly ApplicationDbContext _bd;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BdInicializador(ApplicationDbContext bd, UserManager<IdentityUser> userManager, RoleManager<IdentityRole>roleManager)
        {
            _bd= bd;
            _userManager= userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {
            try
            {
                if(_bd.Database.GetPendingMigrations().Count() > 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (_bd.Roles.Any(x => x.Name == Configuraciones.Rol_Administrador)) return;
            _roleManager.CreateAsync(new IdentityRole(Configuraciones.Rol_Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Configuraciones.Rol_Publicador)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser()
            {
                UserName = "luis@yopmail.com",
                Email = "luis@yopmail.com",
                EmailConfirmed = true,
            }, "Talleres2306*").GetAwaiter().GetResult();
            IdentityUser user = _bd.Users.FirstOrDefault(u => u.Email == "luis@yopmail.com");
            _userManager.AddToRoleAsync(user,Configuraciones.Rol_Administrador).GetAwaiter().GetResult(); ;
        }
    }
}
