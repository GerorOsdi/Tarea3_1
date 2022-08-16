using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Tarea3_1.Conexion
{
    public class FireBaseConex
    {
        public static FirebaseClient firebase = new FirebaseClient("https://dbempleado-8e4ba-default-rtdb.firebaseio.com/");
    }
}
