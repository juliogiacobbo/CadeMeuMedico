using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

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
    }
}