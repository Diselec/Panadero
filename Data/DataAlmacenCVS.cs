using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using Modelos;
using System.Globalization;

namespace Data
{

    public class DataAlmacenCVS:IData<Pan>
    {
    string _file = "../../Almacen.csv";

    public void Guardar(List<Pan> panes){
        List<string> data = new(){ };
        panes.ForEach (Pan =>
            {
            var str = $"{Pan.tipo},{Pan.precio.ToString(CultureInfo.InvariantCulture)},{Pan.cantidad}";
            data.Add(str);
            });
        File.WriteAllLines(_file, data);
    } 

    public List<Pan> Leer()
            {
                List<Pan> panes = new();
                var data = File.ReadAllLines(_file).ToList();
                data.ForEach(row =>
                {
                    var campos = row.Split(",");
                    var pan = new Pan
                    (   
                        tipo : (Tipo)Enum.Parse((typeof(Tipo)),campos[0]),
                        precio : Decimal.Parse(campos[1],CultureInfo.InvariantCulture),
                        cantidad : Int32.Parse(campos[2])
                    );
                    panes.Add(pan);
                });
                return panes;
            }
    }
}