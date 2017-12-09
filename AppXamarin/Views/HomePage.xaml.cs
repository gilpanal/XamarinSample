using System;

using Xamarin.Forms;

namespace AppXamarin
{
    public partial class HomePage : ContentPage
    {
        public HomePage() => InitializeComponent();

        async void Handle_Clicked(object sender, EventArgs e){
            var buttonClicked = sender as Button;
            await Navigation.PushAsync(new ItemsPage(buttonClicked.Text));
        }

    }
}
