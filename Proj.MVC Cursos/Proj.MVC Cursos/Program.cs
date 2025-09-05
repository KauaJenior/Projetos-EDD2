using System;

namespace Proj.MVC_Cursos
{
    class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso (com disciplinas)");
                Console.WriteLine("3. Remover curso (somente se vazio)");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina (com alunos)");
                Console.WriteLine("6. Remover disciplina (somente se sem alunos)");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Id do curso: ");
                        int idCurso = int.Parse(Console.ReadLine());
                        Console.Write("Descrição do curso: ");
                        string descCurso = Console.ReadLine();
                        Curso novoCurso = new Curso(idCurso, descCurso);
                        if (escola.AdicionarCurso(novoCurso))
                            Console.WriteLine("Curso adicionado com sucesso!");
                        else
                            Console.WriteLine("Não foi possível adicionar curso.");
                        break;

                    case 2:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        Curso cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.WriteLine($"Curso {cursoEncontrado.Id} - {cursoEncontrado.Descricao}");
                            Console.WriteLine("Disciplinas:");
                            cursoEncontrado.ListarDisciplinas();
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 3:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        if (escola.RemoverCurso(idCurso))
                            Console.WriteLine("Curso removido!");
                        else
                            Console.WriteLine("Não foi possível remover (curso inexistente ou possui disciplinas).");
                        break;

                    case 4:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            Console.Write("Descrição: ");
                            string descDisc = Console.ReadLine();
                            Disciplina novaDisc = new Disciplina(idDisc, descDisc);
                            if (cursoEncontrado.AdicionarDisciplina(novaDisc))
                                Console.WriteLine("Disciplina adicionada!");
                            else
                                Console.WriteLine("Não foi possível adicionar disciplina.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 5:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            Disciplina disc = cursoEncontrado.PesquisarDisciplina(idDisc);
                            if (disc != null)
                            {
                                Console.WriteLine($"Disciplina {disc.Id} - {disc.Descricao}");
                                disc.ListarAlunos();
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 6:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            if (cursoEncontrado.RemoverDisciplina(idDisc))
                                Console.WriteLine("Disciplina removida!");
                            else
                                Console.WriteLine("Não foi possível remover (disciplina inexistente ou possui alunos).");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 7:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            Disciplina disc = cursoEncontrado.PesquisarDisciplina(idDisc);
                            if (disc != null)
                            {
                                Console.Write("Id do aluno: ");
                                int idAluno = int.Parse(Console.ReadLine());
                                Console.Write("Nome do aluno: ");
                                string nomeAluno = Console.ReadLine();
                                Aluno aluno = new Aluno(idAluno, nomeAluno);

                                if (disc.MatricularAluno(aluno))
                                    Console.WriteLine("Aluno matriculado!");
                                else
                                    Console.WriteLine("Não foi possível matricular.");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 8:
                        Console.Write("Id do curso: ");
                        idCurso = int.Parse(Console.ReadLine());
                        cursoEncontrado = escola.PesquisarCurso(idCurso);
                        if (cursoEncontrado != null)
                        {
                            Console.Write("Id da disciplina: ");
                            int idDisc = int.Parse(Console.ReadLine());
                            Disciplina disc = cursoEncontrado.PesquisarDisciplina(idDisc);
                            if (disc != null)
                            {
                                Console.Write("Id do aluno: ");
                                int idAluno = int.Parse(Console.ReadLine());
                                if (disc.DesmatricularAluno(idAluno))
                                    Console.WriteLine("Aluno removido!");
                                else
                                    Console.WriteLine("Aluno não encontrado na disciplina.");
                            }
                            else
                                Console.WriteLine("Disciplina não encontrada.");
                        }
                        else
                            Console.WriteLine("Curso não encontrado.");
                        break;

                    case 9:
                        Console.Write("Nome do aluno: ");
                        string nomeBusca = Console.ReadLine();
                        escola.PesquisarAluno(nomeBusca);
                        break;
                }
            }
            while (opcao != 0);
        }
    }
}
