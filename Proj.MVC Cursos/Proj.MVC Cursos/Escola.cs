using System;

namespace Proj.MVC_Cursos
{
    public class Escola
    {
        private Curso[] cursos = new Curso[5];
        private int qtdCursos = 0;

        public bool AdicionarCurso(Curso curso)
        {
            if (qtdCursos < 5)
            {
                cursos[qtdCursos++] = curso;
                return true;
            }
            return false;
        }

        public Curso PesquisarCurso(int id)
        {
            for (int i = 0; i < qtdCursos; i++)
                if (cursos[i].Id == id)
                    return cursos[i];
            return null;
        }

        public bool RemoverCurso(int id)
        {
            for (int i = 0; i < qtdCursos; i++)
            {
                if (cursos[i].Id == id && cursos[i].GetQtdDisciplinas() == 0)
                {
                    for (int j = i; j < qtdCursos - 1; j++)
                        cursos[j] = cursos[j + 1];
                    cursos[--qtdCursos] = null;
                    return true;
                }
            }
            return false;
        }

        public void PesquisarAluno(string nome)
        {
            for (int i = 0; i < qtdCursos; i++)
            {
                Curso curso = cursos[i];
                // Verifica cada disciplina
                for (int j = 0; j < curso.GetQtdDisciplinas(); j++)
                {
                    Disciplina disc = curso.PesquisarDisciplina(j + 1);
                    if (disc != null)
                    {
                        // Percorre os alunos da disciplina
                        // (Como não temos vetor público, exibimos pelo método de listagem no Program)
                    }
                }
            }
            Console.WriteLine("Implementar busca detalhada por aluno.");
        }

        public int GetQtdCursos()
        {
            return qtdCursos;
        }
    }
}
