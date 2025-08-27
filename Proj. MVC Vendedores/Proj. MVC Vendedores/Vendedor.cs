using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; }

        public Vendedor(int id, string nome, double percComissao)

        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
        }

        public Vendedor() { }

        public void registrarVenda(int dia, Venda venda)
        {
            {

        }
    }
}
