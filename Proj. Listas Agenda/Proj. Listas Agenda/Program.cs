using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Listas_Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int opcao;

            do
            {
                Console.WriteLine("\n ----- AGENDA -----");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Pesquisar contato");
                Console.WriteLine("3 - Alterar contato");
                Console.WriteLine("4 - Remover contato");
                Console.WriteLine("5 - Listar Contato");
                Console.WriteLine("Escolha uma opção; ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção Incálida");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    case 1:
                        AdicionarContatos();
                        break;
                }
                
            }
            while (opcao !=0);


            static void InicializarContatos(Contatos agenda)
            {
                for (int i = 1; i <= 10; i++)
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

                Console.Write("Data de nascimento (dd/mm/aaaa)");
                string[] data = Console.ReadLine().Split('/');
                Data dt = new Data(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

                Contato contato = new Contato(email, nome, dt);

                Console.Write("Telefone principal: ");
                string numero = Console.ReadLine();

                Console.WriteLine("\n Tipo de telefone: "
                    + "\n Celular: 1"
                    + "\n Fixo: 2"
                    );
                int Ttelefone = int.Parse(Console.ReadLine());

                String TipoTelefone;
                if (Ttelefone == 1)
                {
                    TipoTelefone = "Celular";
                } else if (Ttelefone == 2)
                {
                    TipoTelefone = "Fixo";
                } else { TipoTelefone = "Inválido"; }

                contato.adicionarTelefone(new Telefone(TipoTelefone, numero, true));
               
            }
        }
    }
}
