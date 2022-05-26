using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;
using Modelos;
using System.Globalization;

namespace Data
{

    public class DataHistorialCSV:IData<Compra>
    {
        string _file = "../../Historial.csv";

        public void Guardar(List<Compra> compras){
            List<string> data = new(){ };
            compras.ForEach(Compra =>
            {
                foreach(Pan obj in Compra.ListaCompra){
                    var str = $"{Compra.idCompra},{Compra.idCliente},{Compra.fecha_compra},{Compra.precio.ToString(CultureInfo.InvariantCulture)},{Compra.pagado},{obj.tipo},{obj.precio.ToString(CultureInfo.InvariantCulture)},{obj.cantidad}";
                    data.Add(str);
                }
            });
            File.WriteAllLines(_file, data);
            
        }
        
        public List<Compra> Leer()
        {
            Pan pan_recuperado;
            Compra compra = null;
            List<Compra> compras = new();
            var data = File.ReadAllLines(_file).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    
                    if(compra != null && compra.idCompra.Equals(campos[0])){
                        pan_recuperado = new Pan((Tipo)Enum.Parse(typeof(Tipo),campos[5]),Decimal.Parse(campos[6],CultureInfo.InvariantCulture),Int32.Parse(campos[7]));
                        compra.ListaCompra.Add(pan_recuperado);
                    }else{
                        pan_recuperado = new Pan((Tipo)Enum.Parse(typeof(Tipo),campos[5]),Decimal.Parse(campos[6],CultureInfo.InvariantCulture),Int32.Parse(campos[7]));
                        compra = new Compra(
                            id_compra: campos[0],
                            id: campos[1],
                            fecha: DateTime.Parse(campos[2]),
                            precio: Decimal.Parse(campos[3],CultureInfo.InvariantCulture),
                            pagado: bool.Parse(campos[4])
                        );
                        compra.ListaCompra.Add(pan_recuperado);
                    }
                    compras.Add(compra);
                });
                return compras;
        }

    }
}