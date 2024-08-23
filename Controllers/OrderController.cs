using Ferreweb.Conexion;
using Ferreweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferreweb.Controllers
{
    public class OrderController : Controller
    {
        orderData _orderData = new orderData();

        public IActionResult Listar()
        {
            var olista = _orderData.listar();
            return View(olista);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(orderModel OrderModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _orderData.Guardar(OrderModel);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
