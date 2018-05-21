using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class CreateAccount : ContentPage
    {
        Entry txtNombre = null;
        Entry txtApellido = null;
        Entry txtEmail = null;
        Entry txtPass = null;
        Entry txtSemestre = null;
        DatePicker dtpFecha_nacimiento = null;

		public CreateAccount ()
		{

            StackLayout View_Page = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center
            };

            TapGestureRecognizer tapForgot = new TapGestureRecognizer();


            txtNombre = new Entry()
            {                
                Placeholder = "FirstName"           
            };

            txtApellido = new Entry()
            {
                Placeholder = "LastName"
                
            };

            txtEmail = new Entry()
            {
                Placeholder = "Email",
                Keyboard = Keyboard.Email
            };

            txtPass = new Entry()
            {
                
                Placeholder = "Password",
                IsPassword = true

            };

            txtSemestre = new Entry()
            {
                Placeholder = "Semestre"
                
            };

            dtpFecha_nacimiento = new DatePicker()
            {
                Date = DateTime.Now
            };


            Button btnRegister = new Button()
            {
                Text = "Registrar",
                BackgroundColor = Color.FromHex("#60AFFF")
            };

            Button btnViewUsers = new Button()
            {
                Text = "View Users",
                BackgroundColor = Color.FromHex("#B53F9F")
            };
           

            View_Page.Children.Add(txtNombre);
            View_Page.Children.Add(txtApellido);
            View_Page.Children.Add(txtEmail);
            View_Page.Children.Add(txtPass);
            View_Page.Children.Add(txtSemestre);
            View_Page.Children.Add(dtpFecha_nacimiento);
            View_Page.Children.Add(btnRegister);
           


            //buton event
            btnRegister.Clicked += BtnRegister_Clicked;
           

            Content = View_Page;
        }

    

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtApellido.Text)
                && !string.IsNullOrEmpty(txtEmail.Text)
                && !string.IsNullOrEmpty(txtPass.Text)
                && !string.IsNullOrEmpty(txtSemestre.Text)
                && Methods.UserMethods.IsValidEmail(txtEmail.Text))
            {
                Models.User user = new Models.User();
                
                user.Nombres = txtNombre.Text;
                user.Apellidos = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;                
                

                App.listUsers.Add(user);


                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtSemestre.Text = string.Empty;
                

                await DisplayAlert("Register", "Success", "Ok");

                await this.Navigation.PopAsync(true);

                


            }
            else
            {
                await DisplayAlert("Register", "Missing Information", "Ok");
            }
          

        }
    }
}