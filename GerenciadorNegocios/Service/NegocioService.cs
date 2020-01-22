using GerenciadorNegocios.Data;
using GerenciadorNegocios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace GerenciadorNegocios.Services
{
    
    public class NegocioService : Controller
    {
        private GerenciadorNegociosContext _context = new GerenciadorNegociosContext();

        public List<Negocio> findAll()
        {
            return _context.Negocios.ToList();
        }
        public void Insert(Negocio negocio)
        {
            _context.Negocios.Add(negocio);
            _context.SaveChanges();
        }

        public void Delete(Negocio negocio)
        {
            _context.Negocios.Remove(negocio);
            _context.SaveChanges();
        }
        public List<Negocio> buscaPorDescricao(Negocio negocio)
        {
            List<Negocio> negocios = _context.Negocios.ToList();
            return negocios;
        }
        public ActionResult detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = _context.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);

        }
        public IEnumerable<Negocio> Pesquisar(String campo)
        {
            IEnumerable < Negocio > negocios = _context.Negocios.ToList().Where(x => x.Descricao.Contains(campo));
            return negocios;
        }
    }
}