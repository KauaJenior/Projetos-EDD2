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
        public Venda[] AsVendas { get => asVendas; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31]; // Índices 0-30 (usar 1-30 para dias)
        }

        public Vendedor()
        {
            this.asVendas = new Venda[31];
        }

        public void registrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 30)
                throw new ArgumentOutOfRangeException(nameof(dia), "Dia deve estar entre 1 e 30.");

            this.asVendas[dia] = venda;
        }

        public double valorVendas()
        {
            double total = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (asVendas[i] != null)
                    total += asVendas[i].valorMedia();
            }
            return total;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100);
        }

        // Método auxiliar para verificar se tem vendas
        public bool temVendas()
        {
            for (int i = 1; i <= 30; i++)
            {
                if (asVendas[i] != null)
                    return true;
            }
            return false;
        }

        // Método auxiliar para calcular valor médio das vendas diárias
        public double valorMedioVendasDiarias()
        {
            int diasComVenda = 0;
            double total = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (asVendas[i] != null)
                {
                    diasComVenda++;
                    total += asVendas[i].valorMedia();
                }
            }

            return diasComVenda > 0 ? total / diasComVenda : 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vendedor outro)
                return this.id == outro.id;
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}