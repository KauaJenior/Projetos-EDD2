using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Restaurante
{
    internal class Restaurante
    {
        private int proxPedido;
        private Pedido[] pedidos = new Pedido[50];

       

        public Restaurante() { proxPedido = 0; }

       public bool novoPedido(Pedido pedido)
        {
            if (proxPedido < pedidos.Length)
            {
                pedidos[proxPedido] = pedido;
                proxPedido++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pedido buscarPedido(Pedido pedido)
        {
            for (int i = 0; i < proxPedido; i++)
            {
                if (pedidos[i].Id == pedido.Id)
                {
                    return pedidos[i];
                }
            }
            return null;
        }

        public bool cancelarPedido(Pedido pedido)
        {
            for(int i = 0;i < proxPedido; i++)
            {
                if (pedidos[i].Id == pedido.Id)
                {
                    for (int j = i; j < proxPedido - 1; j++)
                    {
                        pedidos[j] = pedidos[j + 1];
                    }

                    pedidos[proxPedido - 1] = null;
                    proxPedido--;
                    return true;
                }
            }
            return false;
        }

      
        public bool ExistePedido(int idPedido)
        {
            for (int i = 0; i < proxPedido; i++)
            {
                if (pedidos[i].Id == idPedido)
                    return true;
            }
            return false;
        }

        
        public int ProximoNumero()
        {
            return proxPedido + 1; 
        }

    }
}
