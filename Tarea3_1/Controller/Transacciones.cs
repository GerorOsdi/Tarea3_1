using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using Tarea3_1.Models;
using Tarea3_1.Conexion;
using Firebase.Database.Query;
using Firebase.Storage;
using System.IO;


namespace Tarea3_1.Controller
{
    public class Transacciones
    {
        //ObservableCollection<Mempleado> lista = new ObservableCollection<Mempleado>();
        //List<Mempleado> consulta = new List<Mempleado>();

        string id;
        string rutafoto;

        public async Task<string> SetEmpleado(Mempleado parametros)
        {
            //child agregar o poder utilizar una tabla y PostAsync es para insertat datos a la tabla
            var data = await FireBaseConex.firebase
                  .Child("tbEmpleados")
                  .PostAsync(new Mempleado()
                  {
                      ID = parametros.ID,
                      NOMBRES = parametros.NOMBRES,
                      APELLIDOS = parametros.APELLIDOS,
                      PUESTO = parametros.PUESTO,
                      IMAGE = parametros.IMAGE,
                      EDAD = parametros.EDAD,
                      DIRECCION = parametros.DIRECCION

                  });

            id = data.Key;
            return id;

        }
        List<Mempleado> empleados = new List<Mempleado>();
        public async Task<List<Mempleado>> GetEmpleados()
        {
            var data = await FireBaseConex.firebase
                  .Child("tbEmpleados")
                  .OrderByKey()
                  .OnceAsync<Mempleado>();
            foreach (var rdr in data)
            {
                Mempleado datos = new Mempleado();

                datos.ID = rdr.Key;
                datos.NOMBRES = rdr.Object.NOMBRES;
                datos.APELLIDOS = rdr.Object.APELLIDOS;
                datos.PUESTO = rdr.Object.PUESTO;
                datos.IMAGE = rdr.Object.IMAGE;
                datos.EDAD = rdr.Object.EDAD;
                datos.DIRECCION = rdr.Object.DIRECCION;

                empleados.Add(datos);

            }
            return empleados;
        }

    }
}
