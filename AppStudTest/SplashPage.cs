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
    class SplashPage : ContentPage
    {
        public SplashPage()
        {
            Grid layout = new Grid {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1,GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star) },
                }
            };

            Label header = new Label
            {
                Text = "Splash Screen",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            layout.Children.Add(header,0,1,0,1);

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = layout;
        
       
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(TimeSpan.FromSeconds(3));

            RootObject Contacts = new RootObject();
            Task<string> GET = Task<string>.Factory.StartNew(() =>

            {
                using (var client = new HttpClient())
                {
                    var result = client.GetStringAsync("http://54.72.181.8/yolo/contacts.json");
                    return result.Result;
                }
            }
            );
            GET.Wait();
            Contacts = JsonConvert.DeserializeObject<RootObject>(GET.Result);
            TabbedPage Tab = new TabbedPage();
            Tab.Children.Add(new customHome(Contacts));
            Tab.Children.Add(new customBookmarks(Contacts));
            Tab.Children.Add(new MyProfile());
            App.Current.MainPage = new NavigationPage(Tab);
            /*App.Current.MainPage = new Home(Contacts);
            TabbedPage Tab = new TabbedPage();
            Tab.Children.Add(new MainPage(Contacts));
            Tab.Children.Add(new Menu(Contacts));
            Tab.Children.Add(new MyProfile());
            App.Current.MainPage = new NavigationPage(Tab);*/
        }
    }
}