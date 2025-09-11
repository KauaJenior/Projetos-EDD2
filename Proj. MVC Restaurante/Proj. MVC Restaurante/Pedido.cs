using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Restaurante
{
    internal class Pedido
    {
        private int id;
        private string cliente;
        private Item[] items = new Item[10];
        private int qtdItem = 0;

        public int Id { get => id; set => id = value; }
        public string Cliente { get => cliente; set => cliente = value; }

        public Pedido(int id, string cliente)
        {
          this.Id = id;
            this.Cliente = cliente;
        }

        public bool adicionarItem(Item item)
        {
            if (qtdItem < 10)
            {
                items[qtdItem++] = item;
                return true;
            }
            return false;
        }
        public bool removerItem(Item item)
        {
            for (int i = 0; i < qtdItem; i++)
            {

                if (item.Id == items[i].Id)
                {
                    for (int j = i; j < qtdItem - 1; j++)
                    {
                        items[j] = items[j + 1];
                        items[--qtdItem] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public string dadosDoPedido()
        {
            if (qtdItem == 0)
            {
                return $"Pedido Nº {Id}\nCliente: {Cliente}\n\nNenhum item inserido no pedido";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pedido Nº {Id}");
            sb.AppendLine($"Cliente: {Cliente}");
            sb.AppendLine("Itens do pedido:");
            sb.AppendLine("---------------------------------");

            for (int i = 0; i < qtdItem; i++)
            {
                sb.AppendLine($"{items[i].Id} - {items[i].Descricao} - Preço: {items[i].Preco:C}");
            }

            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Total do Pedido: {calcularTotal():C}");

            return sb.ToString();
        }


        public double calcularTotal()
        {
            double total = 0;

            for (int i = 0; i < qtdItem; i++)
            {
                total += items[i].Preco;
            }
            return total;
        }
    } 
}
