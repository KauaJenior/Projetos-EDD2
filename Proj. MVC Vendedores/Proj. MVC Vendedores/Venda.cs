using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    public class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }


        public Venda(int qtde, double valor) 
        { 
          this.qtde = qtde;
            this.valor = valor;
        }

        public double valorMedia()
        {
         return valor * qtde;  

        }








    }
}
