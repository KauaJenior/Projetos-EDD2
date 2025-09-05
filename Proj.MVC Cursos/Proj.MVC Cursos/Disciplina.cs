using System;

namespace Proj.MVC_Cursos
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        private Aluno[] alunos = new Aluno[15];
        private int qtdAlunos = 0;

        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public bool MatricularAluno(Aluno aluno)
        {
            if (qtdAlunos < 15 && aluno.PodeMatricular())
            {
                alunos[qtdAlunos++] = aluno;
                aluno.IncrementarDisciplinas();
                return true;
            }
            return false;
        }

        public bool DesmatricularAluno(int idAluno)
        {
            for (int i = 0; i < qtdAlunos; i++)
            {
                if (alunos[i].Id == idAluno)
                {
                    alunos[i].DecrementarDisciplinas();
                    for (int j = i; j < qtdAlunos - 1; j++)
                        alunos[j] = alunos[j + 1];
                    alunos[--qtdAlunos] = null;
                    return true;
                }
            }
            return false;
        }

        public void ListarAlunos()
        {
            if (qtdAlunos == 0)
            {
                Console.WriteLine("Nenhum aluno matriculado.");
                return;
            }

            for (int i = 0; i < qtdAlunos; i++)
                Console.WriteLine($"  {alunos[i].Id} - {alunos[i].Nome}");
        }

        public int GetQtdAlunos()
        {
            return qtdAlunos;
        }
    }
}
