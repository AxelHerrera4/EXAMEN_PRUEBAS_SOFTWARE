using Microsoft.AspNetCore.Mvc;
using TEST_MVC2.Data;
using TEST_MVC2.Models;

namespace TEST_MVC2.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();

        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.GetClientes().ToList();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objClienteDAL.InsertCliente(cliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el cliente: " + ex.Message);
                }
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Cliente cliente = objClienteDAL.GetClientes().FirstOrDefault(c => c.Codigo == id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al cargar cliente: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objClienteDAL.UpdateCliente(cliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el cliente: " + ex.Message);
                }
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                objClienteDAL.DeleteCliente(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el cliente: " + ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
