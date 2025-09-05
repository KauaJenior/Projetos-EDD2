using System;

namespace Proj.MVC_Cursos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        private int qtdDisciplinas = 0;

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Verifica se aluno ainda pode se matricular
        public bool PodeMatricular()
        {
            return qtdDisciplinas < 6;
        }

        public void IncrementarDisciplinas()
        {
            qtdDisciplinas++;
        }

        public void DecrementarDisciplinas()
        {
            if (qtdDisciplinas > 0)
                qtdDisciplinas--;
        }
    }
}
