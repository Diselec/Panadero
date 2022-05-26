using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;

using Modelos;

namespace Data{
    public class DataClienteCVS : IData<Cliente>
    {
       string _file = "../../Cliente.csv";

       public void Guardar(List<Cliente> clientes){
           List<string> data = new(){ };
           clientes.ForEach(Cliente =>
           {
               var str = $"{Cliente.idCliente},{Cliente.nombre},{Cliente.apellido}";
               data.Add(str);
           });
           File.WriteAllLines(_file, data);
        
       }

       public List<Cliente> Leer()
        {
            List<Cliente> clientes = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var cliente = new Cliente
                (
                    idCliente:campos[0],
                    nombre:campos[1],
                    apellido:campos[2]
                );
                clientes.Add(cliente);
            });
            return clientes;
        }




    }
}