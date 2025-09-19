using System;

namespace Proj.Listas_Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int opcao;

            // Inicializa contatos de teste
            InicializarContatos(agenda);

            do
            {
                Console.WriteLine("\n ----- AGENDA -----");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Pesquisar contato");
                Console.WriteLine("3 - Alterar contato");
                Console.WriteLine("4 - Remover contato");
                Console.WriteLine("5 - Listar Contatos");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    case 1:
                        AdicionarContato(agenda);
                        break;
                    case 2:
                        PesquisarContato(agenda);
                        break;
                    case 3:
                        AlterarContato(agenda);
                        break;
                    case 4:
                        RemoverContato(agenda);
                        break;
                    case 5:
                        ListarContatos(agenda);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }

        // ------------------- MÉTODOS -------------------

        static void InicializarContatos(Contatos agenda)
        {
            for (int i = 1; i <= 5; i++) // só 5 para teste
            {
                Data dt = new Data();
                Contato contato = new Contato($"email{i}@teste.com", $"Contato {i}", dt);
                contato.adicionarTelefone(new Telefone("Celular", $"1199999{i:0000}", true));
                agenda.adicionar(contato);
            }
        }

        static void AdicionarContato(Contatos agenda)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de nascimento (dd/mm/aaaa): ");
            string[] data = Console.ReadLine().Split('/');
            Data dt = new Data(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

            Contato contato = new Contato(email, nome, dt);

            Console.Write("Telefone principal: ");
            string numero = Console.ReadLine();

            Console.WriteLine("\n Tipo de telefone: "
                + "\n 1 - Celular"
                + "\n 2 - Fixo"
            );
            if (!int.TryParse(Console.ReadLine(), out int Ttelefone))
            {
                Console.WriteLine("Tipo inválido, contato não adicionado.");
                return;
            }

            string TipoTelefone;
            if (Ttelefone == 1)
                TipoTelefone = "Celular";
            else if (Ttelefone == 2)
                TipoTelefone = "Fixo";
            else
            {
                Console.WriteLine("Tipo inválido, contato não adicionado.");
                return;
            }

            contato.adicionarTelefone(new Telefone(TipoTelefone, numero, true));
            agenda.adicionar(contato);

            Console.WriteLine("Contato adicionado com sucesso!");
        }

        static void PesquisarContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato: ");
            string email = Console.ReadLine();
            Contato temporario = new Contato { Email = email };

            Contato encontrado = agenda.pesquisar(temporario);

            if (encontrado != null)
                Console.WriteLine(encontrado);
            else
                Console.WriteLine("Contato não encontrado.");
        }

        static void AlterarContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato que deseja alterar: ");
            string email = Console.ReadLine();
            Contato temp = new Contato { Email = email };

            Contato encontrado = agenda.pesquisar(temp);
            if (encontrado == null)
            {
                Console.WriteLine("Contato não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            encontrado.Nome = Console.ReadLine();

            Console.Write("Nova data de nascimento (dd/mm/aaaa): ");
            string[] data = Console.ReadLine().Split('/');
            encontrado.DtNasc = new Data(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

            agenda.alterar(encontrado);
            Console.WriteLine("Contato alterado com sucesso!");
        }

        static void RemoverContato(Contatos agenda)
        {
            Console.Write("Digite o email do contato que deseja remover: ");
            string email = Console.ReadLine();
            Contato temp = new Contato { Email = email };

            if (agenda.remover(temp))
                Console.WriteLine("Contato removido com sucesso!");
            else
                Console.WriteLine("Contato não encontrado.");
        }

        static void ListarContatos(Contatos agenda)
        {
            foreach (Contato c in agenda.Agenda)
            {
                Console.WriteLine("\n----------------");
                Console.WriteLine(c);
            }
        }
    }
}
