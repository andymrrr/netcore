using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using SistemaVenta.Models;
using System.Threading;

namespace SistemaVenta.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IServiceProvider serviceProvider)
        {
            //EjecutarTareaAsync();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //creo metodo crear Roles
        public async Task CreateRoles(IServiceProvider serviceProvider)
        {
            String Mensaje;
            try
            {
                //Manager de roles y llamos los servicios pertinente
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //Manager de Usuario
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                //declaro los nombre de roles que se va a agregar
                String[] rolesName = { "Admin", "User" };
                foreach (var item in rolesName)
                {
                    //declaro si existe el Rol utiliza metodo asyncrono y pasame el oobjeto
                    var roleExist = await roleManager.RoleExistsAsync(item);
                    // si el el rol no existe Creamelo
                    if (!roleExist)
                    {
                        //el manager de roles recorre el foresch  si condicion es verdadera creamelo
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                    //var user = await userManager.FindByIdAsync("d1fbe0da-808e-41ad-9e5d-14609a394fb9");
                    //await userManager.AddToRoleAsync(user, "Administracion");
                }
            }
            catch (Exception Ex)
            {
                Mensaje = Ex.Message;
            }
        }
        //private async Task EjecutarTareaAsync()
        //{
        //    var Data = await Tareas();
        //    string tarea = "vvvvvvvvvvvvvv";
        //}
        //public async Task<String> Tareas ()
        //{
        //    Thread.Sleep( 20*1000);
        //    String tarea = "Tarea Finalizada";
        //    return tarea;
        //}
    }
}
