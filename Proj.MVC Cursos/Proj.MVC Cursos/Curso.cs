using System;

namespace Proj.MVC_Cursos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        private Disciplina[] disciplinas = new Disciplina[12];
        private int qtdDisciplinas = 0;

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (qtdDisciplinas < 12)
            {
                disciplinas[qtdDisciplinas++] = disciplina;
                return true;
            }
            return false;
        }

        public Disciplina PesquisarDisciplina(int id)
        {
            for (int i = 0; i < qtdDisciplinas; i++)
                if (disciplinas[i].Id == id)
                    return disciplinas[i];
            return null;
        }

        public bool RemoverDisciplina(int id)
        {
            for (int i = 0; i < qtdDisciplinas; i++)
            {
                if (disciplinas[i].Id == id && disciplinas[i].GetQtdAlunos() == 0)
                {
                    for (int j = i; j < qtdDisciplinas - 1; j++)
                        disciplinas[j] = disciplinas[j + 1];
                    disciplinas[--qtdDisciplinas] = null;
                    return true;
                }
            }
            return false;
        }

        public void ListarDisciplinas()
        {
            if (qtdDisciplinas == 0)
            {
                Console.WriteLine("Nenhuma disciplina cadastrada.");
                return;
            }

            for (int i = 0; i < qtdDisciplinas; i++)
                Console.WriteLine($"  {disciplinas[i].Id} - {disciplinas[i].Descricao}");
        }

        public int GetQtdDisciplinas()
        {
            return qtdDisciplinas;
        }
    }
}
