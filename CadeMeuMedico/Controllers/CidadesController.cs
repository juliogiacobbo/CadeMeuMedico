﻿using System.Data.Entity;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;
using System;
using System.Linq;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD2 db = new EntidadesCadeMeuMedicoBD2();

        public ActionResult Index()
        {
            var cidades = db.Cidade.ToList();
            return View(cidades);
        }
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        public ActionResult Editar(long id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Cidade cidade = db.Cidade.Find(id);
                db.Cidade.Remove(cidade);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}
