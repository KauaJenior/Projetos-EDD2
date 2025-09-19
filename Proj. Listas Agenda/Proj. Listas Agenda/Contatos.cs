using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Listas_Agenda
{
    internal class Contatos
    {
        private List<Contato> agenda_;

        public List<Contato> Agenda { get => agenda_; }


        public Contatos()
        {
            agenda_ = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            foreach (Contato contatoNaLista in agenda_)
            {
                if (contatoNaLista.Equals(c))
                {
                    return false;
                }
            }
            agenda_.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            foreach (Contato pessoa in agenda_)
            {
                if (pessoa.Equals(c))
                {
                    return pessoa;
                }
            }
            return null;
        }

        public bool alterar(Contato c)
        {
            for (int i = 0; i < agenda_.Count; i++)
            {
                if (agenda_[i].Equals(c))
                {
                    agenda_[i] = c;
                    return true;
                }
            }
            return false;
        }

        public bool remover(Contato c)
        {
            foreach (Contato pessoa in agenda_)
            {
                if (pessoa.Equals(c))
                {
                    agenda_.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
}