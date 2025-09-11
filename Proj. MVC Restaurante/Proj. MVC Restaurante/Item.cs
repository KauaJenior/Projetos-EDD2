using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Restaurante
{
    internal class Item
    {
        private int id;
        private string descricao;
        private double preco;


        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public double Preco { get => preco; set => preco = value; }


        public Item(int id, string descricao, double preco)
        {
            this.id = id;
            this.descricao = descricao;
            this.preco = preco;
        }

        public override string ToString()
        {
            return this.id.ToString() + " - " + this.descricao + "preco: " + this.preco;
        }
    }
}
