using System;
using System.Collections.Generic;


namespace Modelos
{

   public class Compra
    {
        public string idCompra{get;set;}
        public string idCliente{get;set;}
        public string lista;
        public List<Pan> ListaCompra;
        public Decimal precio{get;set;}
        public DateTime fecha_compra;
        public bool pagado{get;set;}

        public Compra(String id, List<Pan> compra, bool pagado){
            this.idCliente = id;
            this.ListaCompra = compra;
            this.pagado = pagado;
            this.fecha_compra = DateTime.Now;
            this.idCompra = generarCodigo();
            listar();
            calculoPrecio();
        }

        public Compra(String id_compra, String id, DateTime fecha, Decimal precio, bool pagado){
            this.idCompra = id_compra;
            this.idCliente = id;
            this.fecha_compra = fecha;
            this.precio = precio;
            this.pagado = pagado;
            this.ListaCompra = new List<Pan>();
        }

        public Compra(String id_compra, String id, DateTime fecha, Decimal precio, bool pagado, List<Pan> lista){
            this.idCompra = id_compra;
            this.idCliente = id;
            this.fecha_compra = fecha;
            this.precio = precio;
            this.pagado = pagado;
            this.ListaCompra = lista;
        }
        



        public string generarCodigo(){
            return Guid.NewGuid().ToString();
        }
        public void listar(){
            foreach(Pan obj in ListaCompra){
                lista = lista + $"{obj.tipo}:{obj.cantidad} ";
            }
        }

        public void calculoPrecio(){
        foreach(Pan obj in ListaCompra){
                precio = precio + obj.precio*obj.cantidad;
            } 
        }

        public string listarcompra(){
            string m="";

            foreach(Pan obj in ListaCompra){
                m = m +" "+obj.cantidad +" "+ obj.tipo;
            }

            return m;
        }

        public string topendiente(){
            return $"El precio de {listarcompra()} es de {precio}€";
        }
       
        public override string ToString()
        {
            return $"idCompra:{idCompra} idCliente:{idCliente} Lista:{lista}";
        }


    }
}