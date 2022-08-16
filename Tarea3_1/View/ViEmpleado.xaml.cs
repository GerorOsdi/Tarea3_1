using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea3_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViEmpleado : ContentPage
    {
        public ViEmpleado()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.LstVWEmpleados());
        }
    }
}