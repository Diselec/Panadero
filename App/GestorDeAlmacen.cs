using System;
using Data;
using Modelos;
using System.Collections.Generic;
using System.Linq;

namespace App
{

    public class GestorDeAlmacen
    {
        IData<Pan> RepoAlmacen;
        public List<Pan> Panes;

        public GestorDeAlmacen(IData<Pan> repo){
            RepoAlmacen = repo;
            Panes = RepoAlmacen.Leer();
        }

        public void RestarPan(Pan pan, int cantidad)
        {
            foreach(Pan obj in Panes){
                if(obj.tipo.Equals(pan.tipo)){
                    obj.cantidad = obj.cantidad - cantidad;
                }
            }
            RepoAlmacen.Guardar(Panes);
        }

        public void SumarPan(Pan pan, int cantidad)
        {
            foreach(Pan obj in Panes){
                if(obj.tipo.Equals(pan.tipo)){
                    obj.cantidad = obj.cantidad + cantidad;
                }
            }
            RepoAlmacen.Guardar(Panes);

        }

        public void RestaurarPanes(List<Pan> compra){
            foreach(Pan obj in compra){
                SumarPan(obj,obj.cantidad);
            }
        }

        
    }
}