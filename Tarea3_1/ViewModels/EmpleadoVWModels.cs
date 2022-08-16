using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Tarea3_1.Controller;
using Tarea3_1.Models;

namespace Tarea3_1.ViewModels
{
    public class EmpleadoVWModels : BaseViewModelsEmpleado
    {
        private string _id;
        private string _Nombres;
        private string _Apellidos;
        private string _Edad;
        private string _Direccion;
        private string _Puesto;
        private string _img;

        private string idEmple;
        public string id
        {
            get { return _id; }
            set { this._id = value; OnPropertyChange(); }
        }

        public string nombres
        {
            get { return _Nombres; }
            set { this._Nombres = value; OnPropertyChange(); }
        }
        public string apellidos
        {
            get { return _Apellidos; }
            set { this._Apellidos = value; OnPropertyChange(); }
        }
        public string edad
        {
            get { return _Edad; }
            set { this._Edad = value; OnPropertyChange(); }
        }
        public string direccion
        {
            get { return _Direccion; }
            set { this._Direccion = value; OnPropertyChange(); }
        }
        public string puesto
        {
            get { return _Puesto; }
            set { this._Puesto = value; OnPropertyChange(); }
        }

        public string imagen
        {
            get { return _img; }
            set { this._img = value; OnPropertyChange(); }
        }


        public ICommand LimpiarCommand { get; set; }
        public ICommand SaveCommand { get; set; }


        void limpiar()
        {
            id = String.Empty;
            nombres = String.Empty;
            apellidos = String.Empty;
            edad = String.Empty;
            direccion = String.Empty;
            puesto = String.Empty;
            imagen = String.Empty; 
        }

        async void SaveEmple()
        {
            Transacciones consulta = new Transacciones();
            Mempleado datos = new Mempleado();
            datos.NOMBRES = nombres;
            datos.APELLIDOS = apellidos;
            datos.PUESTO = puesto;
            datos.DIRECCION = direccion;
            datos.EDAD = edad;
            datos.IMAGE = "-";

            idEmple = await consulta.SetEmpleado(datos);
        }

        public EmpleadoVWModels()
        {
            LimpiarCommand = new Command(() => limpiar());
            SaveCommand = new Command(() => SaveEmple());
        }
    }
}
