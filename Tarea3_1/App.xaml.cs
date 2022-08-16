using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Tarea3_1.Controller;

namespace Tarea3_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.LstVWEmpleados());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
