using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public int Max { get => max; }
        public int Qtde { get => qtde; }
        public Vendedor[] OsVendedores { get => osVendedores; }

        public Vendedores(int max = 10)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }

        public bool addVendedor(Vendedor v)
        {
            if (v == null || qtde >= max)
                return false;

            // Verificar se já existe vendedor com mesmo ID
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Equals(v))
                    return false;
            }

            osVendedores[qtde] = v;
            qtde++;
            return true;
        }

        public bool delVendedor(Vendedor v)
        {
            if (v == null)
                return false;

            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Equals(v))
                {
                    // Verificar se vendedor tem vendas (não pode excluir)
                    if (osVendedores[i].temVendas())
                        return false;

                    // Remover vendedor (shift dos elementos)
                    for (int j = i; j < qtde - 1; j++)
                    {
                        osVendedores[j] = osVendedores[j + 1];
                    }
                    osVendedores[qtde - 1] = null;
                    qtde--;
                    return true;
                }
            }
            return false;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            if (v == null)
                return null;

            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Equals(v))
                    return osVendedores[i];
            }
            return null;
        }

        // Buscar vendedor por ID (método auxiliar)
        public Vendedor searchVendedorPorId(int id)
        {
            var vendedorTemp = new Vendedor { Id = id };
            return searchVendedor(vendedorTemp);
        }

        public double valorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorVendas();
            }
            return total;
        }

        public double valorComissao()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorComissao();
            }
            return total;
        }
    }
}
