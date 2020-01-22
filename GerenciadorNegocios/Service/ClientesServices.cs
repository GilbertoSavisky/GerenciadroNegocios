using GerenciadorNegocios.Data;
using GerenciadorNegocios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorNegocios.Service
{
    public class ClientesServices : Controller
    {
        private GerenciadorNegociosContext _context = new GerenciadorNegociosContext();

        public ClientesServices()
        {
        }

        public ClientesServices(GerenciadorNegociosContext context)
        {
            _context = context;
        }
        public List<Cliente> findall()
        {
            return _context.Clientes.ToList();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

    }
}