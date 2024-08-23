using Microsoft.AspNetCore.Mvc;
using Ferreweb.Models;
using Ferreweb.Conexion;

namespace Ferreweb.Controllers
{
    public class EmployeeController : Controller
    {
        employeeData _employeeData = new employeeData();

        public IActionResult Listar()
        {
            var olista = _employeeData.listar();
            return View(olista);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(employeeModel EmployeeModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _employeeData.Guardar(EmployeeModel);
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
            var products = _employeeData.listar();
            if (products == null)
            {
                products = new List<employeeModel>();
            }
            return View(products);
        }

        public IActionResult Editar(int ID)
        {
            var respuesta = _employeeData.Obtener(ID);
            return View(respuesta);
        }
        [HttpPost]
        public IActionResult Editar(employeeModel EmployeeModel)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _employeeData.Editar(EmployeeModel);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }

        public IActionResult Eliminar(int ID)
        {
            var nRegistro = _employeeData.Obtener(ID);
            return View(nRegistro);
        }
        [HttpPost]
        public IActionResult Eliminar(employeeModel EmployeeModel)
        {
            var respuesta = _employeeData.Eliminar(EmployeeModel.ID);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }
    }
}