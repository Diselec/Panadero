using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


using Modelos;
namespace Data
{
    public interface IData<T>
    {
       
        void Guardar(List<T> elem );
        List<T> Leer();
    }

}