using GerenciadorNegocios.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorNegocios.Models
{
    public class Negocio
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
        public Etapas Etapas { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public double Valor { get; set; }


        public Negocio()
        {
        }

        public Negocio(int id, Etapas etapas, Cliente cliente, int clienteId, Produto produto, int produtoId, double valor)
        {
            Id = id;
            Etapas = etapas;
            Cliente = cliente;
            Produto = produto;
            Valor = valor;
        }
    }

}