using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString() {
            return $"Gênero: {this.Genero}" + Environment.NewLine +
            $"Título: {this.Titulo}" + Environment.NewLine +
            $"Descrição: {this.Descricao}" + Environment.NewLine +
            $"Ano: {this.Ano}" + Environment.NewLine +
            $"Excluído: {this.Excluido}" + Environment.NewLine;
        }

        public string retornaTitulo() {
            return this.Titulo;
        }
        public int retornaId() {
            return this.Id;
        }

        public bool retornaExcluido() {
            return this.Excluido;
        }

        public void Excluir() {
            this.Excluido = true;
        }
    }
}