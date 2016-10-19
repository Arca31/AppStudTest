using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace AppStudTest
{
    public class App : Application
    {
        public App()
        {
            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
           
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
