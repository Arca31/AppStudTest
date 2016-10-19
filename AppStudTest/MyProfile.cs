using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;

namespace AppStudTest
{
    class MyProfile: ContentPage
    {
        
        Image profileimage = new Image
        {
            WidthRequest = 330,
            HeightRequest =307,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Rotation=90
    };
        public MyProfile()
        {
            Title = "My Profile";

            Entry MyEntry = new Entry
            {
                Placeholder = "Full Name",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize=15
            };

            Button Save = new Button { Text = "Save your profile" };

            if (Application.Current.Properties.ContainsKey("username"))
            {
                MyEntry.Text = Application.Current.Properties["username"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("image"))
            {
                
                profileimage.Source =ImageSource.FromFile(Application.Current.Properties["image"].ToString());
                profileimage.BackgroundColor = Color.Transparent;

            }
            if (!Application.Current.Properties.ContainsKey("image"))
            {
                profileimage.BackgroundColor = Color.Silver;
            }



            StackLayout layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing=10
          
            };

            layout.Children.Add(new Label
            {
                Text = "profile",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20

            });

           

            layout.Children.Add(profileimage);

            layout.Children.Add(MyEntry);

            layout.Children.Add(Save);


            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Takepicture;
            profileimage.GestureRecognizers.Add(tapGestureRecognizer);


            Save.Clicked+= async (object sender, EventArgs e) =>
            {

                Application.Current.Properties["username"] = MyEntry.Text;
                await Application.Current.SavePropertiesAsync();
            };

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = layout;

        }

      /*  private async void Uploadpicture(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No Upload", "Picking a photo is not supported.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            profileimage.Source = ImageSource.FromStream(() => file.GetStream());
            

        }*/
        private async void Takepicture(object sender,EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No Camera avaible.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                SaveToAlbum = true,
                Name = "test.jpg"
            });
            if (file == null)
                return;
            profileimage.Source = ImageSource.FromStream(() =>file.GetStream());
            profileimage.BackgroundColor = Color.Transparent;
            Application.Current.Properties["image"] = file.Path;
            await Application.Current.SavePropertiesAsync();

        }

    }
}
