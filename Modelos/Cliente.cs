using System;
namespace Modelos
{


    public class Cliente
    {
        public string nombre{get; set;}
        public string apellido{get;set;}
        public string idCliente{get;set;}

        public Cliente(string idCliente, string nombre, string apellido)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;  
        }

        public override string ToString(){
            return $"idCliente:{idCliente} nombre:{nombre}";
        }
    }

    

}