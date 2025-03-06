using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using System.Collections.Generic;

namespace TDDTestingMVC1.Controllers
{
    public class OpinionClienteController : Controller
    {
        private readonly OpinionClienteDataAccessLayer _opinionDAL = new OpinionClienteDataAccessLayer();

        public IActionResult Index()
        {
            List<OpinionCliente> opiniones = _opinionDAL.GetOpiniones();
            return View(opiniones);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(OpinionCliente opinion)
        {
            if (ModelState.IsValid)
            {
                _opinionDAL.AddOpinion(opinion);
                return RedirectToAction("Index");
            }
            return View(opinion);
        }

        public IActionResult Edit(int id)
        {
            var opinion = _opinionDAL.GetOpiniones().FirstOrDefault(o => o.OpinionID == id);
            if (opinion == null)
            {
                return NotFound();
            }
            return View(opinion);
        }

        [HttpPost]
        public IActionResult Edit(OpinionCliente opinion)
        {
            if (ModelState.IsValid)
            {
                _opinionDAL.UpdateOpinion(opinion);
                return RedirectToAction("Index");
            }
            return View(opinion);
        }

        public IActionResult Delete(int id)
        {
            var opinion = _opinionDAL.GetOpiniones().FirstOrDefault(o => o.OpinionID == id);
            if (opinion == null)
            {
                return NotFound();
            }
            return View(opinion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _opinionDAL.DeleteOpinion(id);
            return RedirectToAction("Index");
        }
    }
}