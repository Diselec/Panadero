using System;
using Data;
using App;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo_alma = new Data.DataAlmacenCVS();
            var repo_cliente = new Data.DataClienteCVS();
            var repo_historial = new Data.DataHistorialCSV();
            var repo_pendientes = new Data.DataPendientesCSV();
            var view = new Vista();
            var sis_alma = new GestorDeAlmacen(repo_alma);
            var sis_cliente = new GestorDeCliente(repo_cliente);
            var sis_historial = new GestorDeHistorial(repo_historial);
            var sis_pendientes = new GestorDePendientes(repo_pendientes);
            var controlador = new Controlador(view,sis_cliente,sis_alma,sis_historial,sis_pendientes);
            controlador.Run();
        }
    }
}
