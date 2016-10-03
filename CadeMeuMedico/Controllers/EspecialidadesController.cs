using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD2 db = new EntidadesCadeMeuMedicoBD2();

        public ActionResult Index()
        {
            var especialidades = db.Especialidade.ToList();
            return View(especialidades);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidade.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        public ActionResult Editar(long id)
        {
            Especialidade especialidade = db.Especialidade.Find(id);
            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidade);
        }
    }
}
