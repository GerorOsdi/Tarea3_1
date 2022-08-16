using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3_1.ViewModels;
using Tarea3_1.Controller;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea3_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LstVWEmpleados : ContentPage
    {
        public LstVWEmpleados()
        {
            InitializeComponent();
            BindingContext = new ListModelEmpleado(Navigation);
            //llenar();
        }


        private async Task llenar()
        {
            Transacciones consulta = new Transacciones();
            lsyEmpleados.ItemsSource = await consulta.GetEmpleados();
        }
    }
}