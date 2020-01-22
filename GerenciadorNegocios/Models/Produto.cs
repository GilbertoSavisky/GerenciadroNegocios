using System;

namespace GerenciadorNegocios.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public double Valor { get; set; }

        public Produto()
        {
        }

        public Produto(int id, string descricao, double valor)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
