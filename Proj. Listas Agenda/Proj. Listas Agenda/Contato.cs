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
        private List<Telefone> telefones = new List<Telefone>();

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public Data DtNasc { get => dtNasc;}
        public List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public Contato(string email, string nome)
        {
            this.email = email;
            this.nome = nome;
            
        }

        public int getDate()
        {
             string data = this.DtNasc.ToString();
            return int.Parse(data);
        }

        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone telefone in telefones)
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
            foreach (Telefone t in telefones)
            {
                if (t.Principal)
                {
                    return "------------------" + '\n' 
                        + "Nome:" + this.nome + '\n'
                        + "Email: " + this.nome + '\n'
                        + "Telefone principal: " + getTelefonePrincipal().ToString();
                }
            } return "Contato não encontrado ou sem número principal";
        }

        public override bool Equals(object obj)
        {
            return (this.email == ((Contato)obj).Email);
        }
    }
}
