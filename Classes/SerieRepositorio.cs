using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            this.listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            this.listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return this.listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}