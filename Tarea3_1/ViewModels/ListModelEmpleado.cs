using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Tarea3_1.Models;
using Tarea3_1.Controller;


namespace Tarea3_1.ViewModels
{
    public class ListModelEmpleado : BaseViewModelsEmpleado
    {
        private ObservableCollection<Mempleado> lstEmpleados = new ObservableCollection<Mempleado>();
        private Mempleado insEmpleado;

        public ObservableCollection<Mempleado> GetEmplList
        {
            get { return lstEmpleados; }
            set { lstEmpleados = value; OnPropertyChange(); }
        }

        public Mempleado GetEmpleado
        {
            get { return insEmpleado; }
            set { insEmpleado = value; OnPropertyChange(); }
        }

        public ICommand empleDet { set; get; }

        public INavigation Navigation { set; get; }

        public ListModelEmpleado(INavigation navigation)
        {  
            Navigation = navigation;

            empleDet = new Command<Type>(async (pageType) => await detalle(pageType));
            GetEmplList = new ObservableCollection<Mempleado>();

            SetEmpleados();
        }

         async void SetEmpleados()
        {
            Transacciones consulta = new Transacciones();

            var lista = await consulta.GetEmpleados();
            foreach (var rst in lista)
            {
                GetEmplList.Add(rst);
            }

           
        }


        async Task detalle(Type pageType)
        {

            if (GetEmpleado != null)
            {
                var pagina = (Page)Activator.CreateInstance(pageType);

                pagina.BindingContext = new EmpleadoVWModels()
                {
                    id = GetEmpleado.ID,
                    nombres = GetEmpleado.NOMBRES,
                    apellidos = GetEmpleado.APELLIDOS,
                    edad = GetEmpleado.EDAD,
                    puesto = GetEmpleado.PUESTO,
                    direccion = GetEmpleado.DIRECCION,
                    imagen = GetEmpleado.IMAGE
                };

                await Navigation.PushAsync(pagina);
            }
        }
    }
}
