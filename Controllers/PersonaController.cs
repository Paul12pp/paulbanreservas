using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using paulbanreservas.Models;
namespace paulbanreservas.Controllers
{
    public class PersonaController : Controller
    {
        PersonaDataAccessLayer objpersona = new PersonaDataAccessLayer();
        public IActionResult Index()
        {
            List<Persona> lstpersona = new List<Persona>();
            lstpersona = objpersona.GetAllPersonas().ToList();
            return View(lstpersona);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Persona persona)
        {
            if (ModelState.IsValid)
            {
                objpersona.AddPersona(persona);
                return RedirectToAction("Index");
            }
            return View(persona);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            Persona persona = objpersona.GetPersonaData(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Persona persona)
        {
            if (id != persona.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objpersona.UpdatePersona(persona);
                return RedirectToAction("Index");
            }
            return View(persona);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) { return NotFound(); }
            Persona persona = objpersona.GetPersonaData(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            Persona persona = objpersona.GetPersonaData(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objpersona.DeletePersona(id);
            return RedirectToAction("Index");
        }

    }
}
