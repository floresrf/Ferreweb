using Microsoft.AspNetCore.Mvc;
using Ferreweb.Models;
using Ferreweb.Conexion;
using Microsoft.Win32;

namespace Ferreweb.Controllers
{
    public class ProductController : Controller
    {
        productData _productData = new productData();

        public IActionResult Listar()
        {
            var olista = _productData.listar();
            return View(olista);
        }

        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(productModel oProductModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _productData.Guardar(oProductModel);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int ID)
        {
            var nRegistro = _productData.Obtener(ID);
            return View(nRegistro);
        }
        [HttpPost]
        public IActionResult Eliminar(productModel oproductModel)
        {
            var respuesta = _productData.Eliminar(oproductModel.ID);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }
    
        public IActionResult Products()
        {
            var products = _productData.listar();
            if (products == null)
            {
                products = new List<productModel>();
            }
            return View(products);
        }        

        public IActionResult Editar(int ID)
        {
            var respuesta = _productData.Obtener(ID);
            return View(respuesta);
        }
        [HttpPost]
        public IActionResult Editar(productModel oproductModel)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _productData.Editar(oproductModel);
            if (respuesta)
                return RedirectToAction("Listar");

            else return View();
        }
    }
}
