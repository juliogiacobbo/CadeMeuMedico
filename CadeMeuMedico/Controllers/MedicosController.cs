using System.Data.Entity;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;
using System;
using System.Net;
using System.Linq;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private EntidadesCadeMeuMedicoBD2 db = new EntidadesCadeMeuMedicoBD2();

        public ActionResult Index()
        {
            var medicos = db.Medico.Include(m => m.Cidade).Include(m => m.Especialidade);
            return View(medicos);
        }

        //Inserção

        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade,
            "IDEspecialidade",
            "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        //Edição

        public ActionResult Editar(long id)
        {
            Medico medico = db.Medico.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }
        [HttpPost]
        public ActionResult Editar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        //Exclusão

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                BadRequest);
            }
            Medico medico = db.Medico.Where(p => p.IDMedico == id).First();
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        [HttpPost]
        public ActionResult Excluir(long id)
        {
            try
            {
                Medico medico = db.Medico.Find(id);
                db.Medico.Remove(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}