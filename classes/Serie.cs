using System;
namespace cadastro_series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set;}
        private string Titulo { get; set;}
        private string Descricao { get; set;}
        private int Ano { get; set;}
        private bool Excluido { get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero " + this.Genero + Environment.NewLine;
            retorno += "Título " + this.Titulo + Environment.NewLine;
            retorno += "Descrição " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início " + this.Ano + Environment.NewLine;
            retorno += "Excluido " + this.Excluido;

            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}