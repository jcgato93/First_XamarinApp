using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class Login : ContentPage
    {
        #region Variables
        Entry User = null;
        Entry Pass = null;
        #endregion

        #region UI
        public Login()
        {
            StackLayout View_Page = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center
            };

            TapGestureRecognizer tapForgot = new TapGestureRecognizer();

            User = new Entry()
            {
                
                Placeholder = "User",
                Keyboard = Keyboard.Email,
            };

            Pass = new Entry()
            {
                
                Placeholder = "Password",
                IsPassword = true

            };

            Button ButtonLogin = new Button
            {
                BackgroundColor = Color.LightBlue,
                TextColor = Color.White,
                Text = "Iniciar"
            };

            Label label = new Label
            {
                Margin = new Thickness(10),
                TextColor = Color.Blue,
                Text = "Obtener Password"
            };

            Button btnRegister = new Button()
            {
                Text = "Register",
                BackgroundColor = Color.MediumOrchid
            };

            //generar evento de tap gesture
            tapForgot.Tapped += TapForgot_Tapped;

            View_Page.Children.Add(User);
            View_Page.Children.Add(Pass);
            View_Page.Children.Add(ButtonLogin);
            View_Page.Children.Add(btnRegister);
            View_Page.Children.Add(label);

            //asignar evento a un control
            label.GestureRecognizers.Add(tapForgot);

            //buton event
            ButtonLogin.Clicked += ButtonLogin_Clicked;
            btnRegister.Clicked += BtnRegister_Clicked;


            Content = View_Page;
        }
        #endregion

        #region Events
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(User.Text) &&
                    !string.IsNullOrEmpty(Pass.Text) && 
                    User.Text.Contains("@"))
                {
                    var x = (from i in App.listUsers
                             where i.Email == User.Text && i.Password == Pass.Text
                             select i).FirstOrDefault();

                    if (x!=null)
                    {
                        Models.User user = new Models.User();
                        user.Email = User.Text;
                        user.Password = Pass.Text;


                        await Navigation.PushAsync(new ListUsers());
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Wrong Credentials, You have to sign up", "Cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "The fields are empty", "Cancel");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
           
        }

        private async void TapForgot_Tapped(object sender, EventArgs e)
        {
            //  var x=await DisplayAlert("Alert", 
            //                        "tap from label",
            //                        "Accept",
            //                        "Cancel");

            await Navigation.PushAsync(new ForgotAccount());


            /*
             para cerrar la pagina actual , en otras palabras removerlo de la 
             pila de navegacion

            Navigation.RemovePage(this);
             */

        }
        #endregion


    }
}