using System;
using System.Text;
using Proj._MVC_Restaurante;

internal class Program
{
    static void Main(string[] args)
    {
        Restaurante restaurante = new Restaurante();
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Criar novo pedido");
            Console.WriteLine("2. Adicionar item ao pedido");
            Console.WriteLine("3. Remover item do pedido");
            Console.WriteLine("4. Consultar pedido");
            Console.WriteLine("5. Cancelar pedido");
            Console.WriteLine("6. Listar todos os pedidos");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    sair = true;
                    break;

                case "1":
                    Console.WriteLine($"Próximo número de pedido disponível: {restaurante.ProximoNumero()}");
                    Console.Write("Digite o número do pedido: ");
                    int idPedido = int.Parse(Console.ReadLine());

                    // Verifica se já existe um pedido com esse número
                    if (restaurante.ExistePedido(idPedido))
                    {
                        Console.WriteLine("Já existe um pedido com esse número! Tente outro.");
                        break;
                    }

                    Console.Write("Digite o nome do cliente: ");
                    string cliente = Console.ReadLine();
                    Pedido novo = new Pedido(idPedido, cliente);
                    if (restaurante.novoPedido(novo))
                        Console.WriteLine("Pedido criado com sucesso!");
                    else
                        Console.WriteLine("Não foi possível criar o pedido (limite atingido).");
                    break;


                case "2":
                    Console.Write("Digite o número do pedido: ");
                    int idAdd = int.Parse(Console.ReadLine());
                    Pedido pedidoAdd = restaurante.buscarPedido(new Pedido(idAdd, ""));
                    if (pedidoAdd == null)
                    {
                        Console.WriteLine("Pedido não encontrado!");
                        break;
                    }
                    Console.Write("Digite o ID do item: ");
                    int itemId = int.Parse(Console.ReadLine());
                    Console.Write("Descrição do item: ");
                    string desc = Console.ReadLine();
                    Console.Write("Preço do item: ");
                    double preco = double.Parse(Console.ReadLine());
                    Item item = new Item(itemId, desc, preco);
                    if (pedidoAdd.adicionarItem(item))
                        Console.WriteLine("Item adicionado com sucesso!");
                    else
                        Console.WriteLine("Não foi possível adicionar o item (limite atingido).");
                    break;

                case "3":
                    Console.Write("Digite o número do pedido: ");
                    int idRem = int.Parse(Console.ReadLine());
                    Pedido pedidoRem = restaurante.buscarPedido(new Pedido(idRem, ""));
                    if (pedidoRem == null)
                    {
                        Console.WriteLine("Pedido não encontrado!");
                        break;
                    }
                    Console.Write("Digite o ID do item que deseja remover: ");
                    int remId = int.Parse(Console.ReadLine());
                    Item itemRem = new Item(remId, "", 0);
                    if (pedidoRem.removerItem(itemRem))
                        Console.WriteLine("Item removido com sucesso!");
                    else
                        Console.WriteLine("Item não encontrado no pedido.");
                    break;

                case "4":
                    Console.Write("Digite o número do pedido: ");
                    int idConsulta = int.Parse(Console.ReadLine());
                    Pedido pedidoConsulta = restaurante.buscarPedido(new Pedido(idConsulta, ""));
                    if (pedidoConsulta == null)
                        Console.WriteLine("Pedido não encontrado!");
                    else
                        Console.WriteLine(pedidoConsulta.dadosDoPedido());
                    break;

                case "5":
                    Console.Write("Digite o número do pedido: ");
                    int idCancel = int.Parse(Console.ReadLine());
                    Pedido pedidoCancel = restaurante.buscarPedido(new Pedido(idCancel, ""));
                    if (pedidoCancel == null)
                        Console.WriteLine("Pedido não encontrado!");
                    else if (restaurante.cancelarPedido(pedidoCancel))
                        Console.WriteLine("Pedido cancelado com sucesso!");
                    else
                        Console.WriteLine("Erro ao cancelar pedido.");
                    break;

                case "6":
                    double somaGeral = 0;
                    Console.WriteLine("\n===== TODOS OS PEDIDOS =====");
                    for (int i = 0; i < 50; i++)
                    {
                        Pedido p = restaurante.buscarPedido(new Pedido(i + 1, ""));
                        if (p != null)
                        {
                            Console.WriteLine($"Pedido Nº {p.Id} | Cliente: {p.Cliente} | Total: {p.calcularTotal():C}");
                            somaGeral += p.calcularTotal();
                        }
                    }
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Soma geral do dia: {somaGeral:C}");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        Console.WriteLine("Programa finalizado!");
    }
}
