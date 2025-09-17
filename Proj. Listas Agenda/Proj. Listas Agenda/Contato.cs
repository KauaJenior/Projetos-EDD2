using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Listas_Agenda
{
    public class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones_;

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Data DtNasc { get => dtNasc;}
        internal List<Telefone> Telefones { get => telefones_;}

        public Contato(string email, string nome, Data dtNasc)
        {
            this.email = email;
            this.nome = nome;
            this.dtNasc = dtNasc;
            this.telefones_ = new List<Telefone>();
            
        }

        public int getIdade()
        {
            return DtNasc.Ano - DateTime.Now.Year;
        }

        public void adicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone telefone in Telefones)
            {
                if (telefone.Principal)
                {
                    return telefone.Numero;
                }
            }
            return "Telefone principal nao encontrado!";
        }

        public override string ToString()
        {
            foreach (Telefone t in telefones_)
            {
                if (t.Principal)
                {
                    return "------------------" + '\n'
                        + "Nome:" + this.nome + '\n'
                        + "Email: " + this.nome + '\n'
                        + "Telefone principal: " + getTelefonePrincipal().ToString() + "\n"
                        + "Data de nascimento:" + dtNasc.ToString()
                        + "Idade: " + getIdade().ToString() + "\n";
                }
            } return "Contato não encontrado ou sem número principal";
        }

        public override bool Equals(object obj)
        {
            return (this.email == ((Contato)obj).Email);
        }
    }
}
