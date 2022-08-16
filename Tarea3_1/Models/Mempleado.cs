using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tarea3_1.Models
{
    public class Mempleado
    {
        [PrimaryKey, AutoIncrement]
        public string ID { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string EDAD { get; set; }
        public string DIRECCION { get; set; }
        public string PUESTO { get; set; }
        public string IMAGE { get; set; }

    }
}
