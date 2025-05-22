using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_Grupo19.Clases
{
    public class Sucursal
    {
        // Propiedades
        readonly string _id, _nombre, _descrripcion;

        // Constructor
        public Sucursal(string id, string nombre, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descrripcion = descripcion;
        }
    }
}