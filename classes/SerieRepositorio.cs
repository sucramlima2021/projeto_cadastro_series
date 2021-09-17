using System;
using System.Collections.Generic;

namespace cadastro_series
{
    public class SerieRepositorio : Irepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();
        public void Atualiza(int id, Serie obj)
        {
           ListaSerie[id] = obj;
        } 

        public void Insere(Serie obj)
        {
            ListaSerie.Add(obj);
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}