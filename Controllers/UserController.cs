using Microsoft.AspNetCore.Mvc;
using Ferreweb.Models;
using Ferreweb.Conexion;

namespace Ferreweb.Controllers
{
    public class UserController : Controller
    {
        userData _userData = new userData();

        public IActionResult Listar()
        {
            var olista = _userData.listar();
            return View(olista);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(userModel oUserModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _userData.Guardar(oUserModel);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Products()
        {
            var products = _userData.listar();
            if (products == null)
            {
                products = new List<userModel>();
            }
            return View(products);
        }

        public IActionResult Editar(int ID)
        {
            var respuesta = _userData.Obtener(ID);
            return View(respuesta);
        }
        [HttpPost]
        public IActionResult Editar(userModel oUserModel)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _userData.Editar(oUserModel);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }

        public IActionResult Eliminar(int ID)
        {
            var nRegistro = _userData.Obtener(ID);
            return View(nRegistro);
        }
        [HttpPost]
        public IActionResult Eliminar(userModel oUserModel)
        {
            var respuesta = _userData.Eliminar(oUserModel.ID);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }
    }
}