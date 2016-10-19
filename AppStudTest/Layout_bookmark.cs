using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStudTest
{
    class Layout_bookmark:Grid
    {
        public Layout_bookmark(RootObject Contacts,int i)
        {
            VerticalOptions = LayoutOptions.FillAndExpand;

            RowDefinition row = new RowDefinition { Height = GridLength.Auto };

            ColumnDefinition column = new ColumnDefinition { Width = GridLength.Auto };

            RowDefinitions.Add(row);

            ColumnDefinitions.Add(column);

            Image image=new Image()
            {
                Source = ImageSource.FromUri(new Uri("http://54.72.181.8/yolo/" + Contacts.contacts[i].hisface)),
                WidthRequest=65,
                HeightRequest=65
            };


            Label Name=new Label()
            {
                Text = Contacts.contacts[i].fullname(),
                FontSize = 25,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            Label Description= new Label()
            {
                Text = Contacts.contacts[i].status,
                FontSize = 17,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            Button Button=new Button()
            {
                Text = "-",
                WidthRequest = 40,
                HeightRequest = 40,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Button.Clicked += async (object sender, EventArgs e) =>
             {
                 Application.Current.Properties.Remove(i.ToString());
                 await Application.Current.SavePropertiesAsync();
                 TabbedPage Tab = new TabbedPage();
                 Tab.Children.Add(new customHome(Contacts));
                 Tab.Children.Add(new customBookmarks(Contacts));
                 Tab.Children.Add(new MyProfile());
                 App.Current.MainPage = new NavigationPage(Tab);
                 Tab.CurrentPage = Tab.Children[1];

             };
            Children.Add(image,0,1,0,2);
            Children.Add(Name,1,5,0,1);
            Children.Add(Description,1,5,1,2);
            Children.Add(Button,5,6,0,2);
        }
    }
}
