using System;
using Data;
using Modelos;
using System.Collections.Generic;

namespace App
{

        public class GestorDeCliente
        {
            IData<Cliente> RepoCliente;
            public List<Cliente> Clientes;
            public GestorDeCliente(IData<Cliente> repo){
                RepoCliente = repo;
                Clientes = RepoCliente.Leer();
            }

            public void NuevoCliente(Cliente nuevo){
                Clientes.Add(nuevo);
                RepoCliente.Guardar(Clientes);
            }
            public void EliminarCliente(Cliente elimi){
                Clientes.Remove(elimi);
                RepoCliente.Guardar(Clientes);
            }

            public Cliente DevolverCliente(string id)
            {
                Cliente cliente_devuelto = null;
                foreach(Cliente obj in Clientes)
                {
                    if(obj.idCliente.Equals(id))
                        cliente_devuelto = obj;
                }

                return cliente_devuelto;
            }

            public bool BuscarCliente(string id)
            {
                bool res = false;
                foreach(Cliente obj in Clientes)
                {
                    if(obj.idCliente.Equals(id))
                        res = true;
                }

                return res;
            }
        }
}