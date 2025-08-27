using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10); // Máximo 10 vendedores
            int opcao;

            do
            {
                // Exibir Menu
                Console.Clear();
                Console.WriteLine("\n" + new string('=', 50));
                Console.WriteLine("SISTEMA DE VENDEDORES");
                Console.WriteLine(new string('=', 50));
                Console.WriteLine("OPÇÕES:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor (*)");
                Console.WriteLine("2. Consultar vendedor (**)");
                Console.WriteLine("3. Excluir vendedor (***)");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores (****)");
                Console.WriteLine(new string('=', 50));
                Console.Write("Escolha uma opção: ");

                // Ler opção
                try
                {
                    opcao = int.Parse(Console.ReadLine() ?? "0");
                }
                catch
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Sistema finalizado!");
                        break;

                    case 1: // Cadastrar vendedor
                        Console.WriteLine("\n=== CADASTRAR VENDEDOR ===");

                        if (vendedores.Qtde >= vendedores.Max)
                        {
                            Console.WriteLine("ERRO: Limite máximo de 10 vendedores atingido!");
                            break;
                        }

                        Console.Write("Informe o ID do vendedor: ");
                        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                        {
                            Console.WriteLine("ID inválido!");
                            break;
                        }

                        if (vendedores.searchVendedorPorId(id) != null)
                        {
                            Console.WriteLine("ERRO: Vendedor com este ID já existe!");
                            break;
                        }

                        Console.Write("Informe o nome do vendedor: ");
                        string nome = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(nome))
                        {
                            Console.WriteLine("Nome não pode ser vazio!");
                            break;
                        }

                        Console.Write("Informe o percentual de comissão (%): ");
                        if (!double.TryParse(Console.ReadLine(), out double percComissao) ||
                            percComissao < 0 || percComissao > 100)
                        {
                            Console.WriteLine("Percentual deve estar entre 0 e 100!");
                            break;
                        }

                        try
                        {
                            var vendedor = new Vendedor(id, nome, percComissao);
                            if (vendedores.addVendedor(vendedor))
                            {
                                Console.WriteLine("Vendedor cadastrado com sucesso!");
                                Console.WriteLine($"Vendedores cadastrados: {vendedores.Qtde}/{vendedores.Max}");
                            }
                            else
                            {
                                Console.WriteLine("Erro ao cadastrar vendedor!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case 2: // Consultar vendedor
                        Console.WriteLine("\n=== CONSULTAR VENDEDOR ===");

                        Console.Write("Informe o ID do vendedor: ");
                        if (!int.TryParse(Console.ReadLine(), out int idConsulta))
                        {
                            Console.WriteLine("ID inválido!");
                            break;
                        }

                        var vendedorConsulta = vendedores.searchVendedorPorId(idConsulta);
                        if (vendedorConsulta == null)
                        {
                            Console.WriteLine("Vendedor não encontrado!");
                            break;
                        }

                        Console.WriteLine("\n" + new string('-', 60));
                        Console.WriteLine("DADOS DO VENDEDOR");
                        Console.WriteLine(new string('-', 60));
                        Console.WriteLine($"ID: {vendedorConsulta.Id}");
                        Console.WriteLine($"Nome: {vendedorConsulta.Nome}");
                        Console.WriteLine($"Percentual de Comissão: {vendedorConsulta.PercComissao:F2}%");
                        Console.WriteLine($"Valor Total das Vendas: R$ {vendedorConsulta.valorVendas():F2}");
                        Console.WriteLine($"Valor da Comissão Devida: R$ {vendedorConsulta.valorComissao():F2}");
                        Console.WriteLine($"Valor Médio das Vendas Diárias: R$ {vendedorConsulta.valorMedioVendasDiarias():F2}");

                        bool temVendas = false;
                        Console.WriteLine("\nVENDAS REGISTRADAS:");
                        for (int i = 1; i <= 30; i++)
                        {
                            if (vendedorConsulta.AsVendas[i] != null)
                            {
                                temVendas = true;
                                var venda = vendedorConsulta.AsVendas[i];
                                Console.WriteLine($"  Dia {i:D2}: Qtd: {venda.Qtde}, " +
                                                $"Valor Unit.: R$ {venda.Valor:F2}, " +
                                                $"Total: R$ {venda.valorMedia():F2}");
                            }
                        }

                        if (!temVendas)
                        {
                            Console.WriteLine("  Nenhuma venda registrada.");
                        }

                        Console.WriteLine(new string('-', 60));
                        break;

                    case 3: // Excluir vendedor
                        Console.WriteLine("\n=== EXCLUIR VENDEDOR ===");

                        Console.Write("Informe o ID do vendedor: ");
                        if (!int.TryParse(Console.ReadLine(), out int idExcluir))
                        {
                            Console.WriteLine("ID inválido!");
                            break;
                        }

                        var vendedorExcluir = vendedores.searchVendedorPorId(idExcluir);
                        if (vendedorExcluir == null)
                        {
                            Console.WriteLine("Vendedor não encontrado!");
                            break;
                        }

                        if (vendedorExcluir.temVendas())
                        {
                            Console.WriteLine("ERRO: Não é possível excluir vendedor com vendas registradas!");
                            break;
                        }

                        if (vendedores.delVendedor(vendedorExcluir))
                        {
                            Console.WriteLine($"Vendedor '{vendedorExcluir.Nome}' excluído com sucesso!");
                            Console.WriteLine($"Vendedores restantes: {vendedores.Qtde}/{vendedores.Max}");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao excluir vendedor!");
                        }
                        break;

                    case 4: // Registrar venda
                        Console.WriteLine("\n=== REGISTRAR VENDA ===");

                        Console.Write("Informe o ID do vendedor: ");
                        if (!int.TryParse(Console.ReadLine(), out int idVenda))
                        {
                            Console.WriteLine("ID inválido!");
                            break;
                        }

                        var vendedorVenda = vendedores.searchVendedorPorId(idVenda);
                        if (vendedorVenda == null)
                        {
                            Console.WriteLine("ERRO: Vendedor não encontrado! Cadastre o vendedor primeiro.");
                            break;
                        }

                        Console.Write("Informe o dia da venda (1-30): ");
                        if (!int.TryParse(Console.ReadLine(), out int dia) || dia < 1 || dia > 30)
                        {
                            Console.WriteLine("Dia deve estar entre 1 e 30!");
                            break;
                        }

                        if (vendedorVenda.AsVendas[dia] != null)
                        {
                            Console.WriteLine($"Já existe uma venda registrada para o dia {dia}!");
                            break;
                        }

                        Console.Write("Informe a quantidade vendida: ");
                        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                        {
                            Console.WriteLine("Quantidade deve ser maior que zero!");
                            break;
                        }

                        Console.Write("Informe o valor unitário: R$ ");
                        if (!double.TryParse(Console.ReadLine(), out double valorUnitario) || valorUnitario <= 0)
                        {
                            Console.WriteLine("Valor unitário deve ser maior que zero!");
                            break;
                        }

                        try
                        {
                            var venda = new Venda(quantidade, valorUnitario);
                            vendedorVenda.registrarVenda(dia, venda);

                            Console.WriteLine("Venda registrada com sucesso!");
                            Console.WriteLine($"Total da venda: R$ {venda.valorMedia():F2}");
                            Console.WriteLine($"Comissão: R$ {(venda.valorMedia() * vendedorVenda.PercComissao / 100):F2}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case 5: // Listar vendedores
                        Console.WriteLine("\n=== LISTAR VENDEDORES ===");

                        if (vendedores.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor cadastrado!");
                            break;
                        }

                        Console.WriteLine(new string('=', 100));
                        Console.WriteLine($"{"ID",-5} {"NOME",-20} {"TOTAL VENDAS",-15} {"COMISSÃO",-15} {"% COMISSÃO",-12}");
                        Console.WriteLine(new string('=', 100));

                        for (int i = 0; i < vendedores.Qtde; i++)
                        {
                            var v = vendedores.OsVendedores[i];
                            Console.WriteLine($"{v.Id,-5} {v.Nome,-20} " +
                                            $"R$ {v.valorVendas(),-12:F2} " +
                                            $"R$ {v.valorComissao(),-12:F2} " +
                                            $"{v.PercComissao,-10:F2}%");
                        }

                        Console.WriteLine(new string('=', 100));
                        Console.WriteLine("TOTAIS GERAIS:");
                        Console.WriteLine($"Total de Vendas: R$ {vendedores.valorVendas():F2}");
                        Console.WriteLine($"Total de Comissões: R$ {vendedores.valorComissao():F2}");
                        Console.WriteLine($"Vendedores Cadastrados: {vendedores.Qtde}/{vendedores.Max}");
                        Console.WriteLine(new string('=', 100));
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }
    }
}


        