using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class ListUsers : ContentPage
	{
		public ListUsers (Models.User user)
		{
            Label header = new Label
            {
                Text = "List of Courses",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Label nameUser = new Label
            {
                Text="Hello "+user.Email
            };

            var indicator = new ActivityIndicator();
            indicator.IsRunning = true;
            System.Threading.Tasks.Task.Delay(2000);
            List<Models.Cursos> list = Services.CursosService.ObtenerCursos();
            indicator.IsRunning = false;


            ListView listView = new ListView
            {
                //Origen de datos
                ItemsSource = list,
                RowHeight=50,

                //Define template for displaying each item.
                //(Argument of dataTemplate contructor is called for)
                // each item; it must return a cell derivative.
                ItemTemplate = new DataTemplate(() =>
                  {
                      //create  views with bindings for displaying each property.
                      Label Titulo = new Label();
                      Titulo.SetBinding(Label.TextProperty, "Titulo");                      

                      Label Calificacion = new Label();
                      Calificacion.SetBinding(Label.TextProperty, "Calificacion");

                      Label cursoId = new Label { IsVisible=false };
                      cursoId.SetBinding(Label.TextProperty, "CursoId");

                      Label lblCalificacion = new Label()
                      {
                          Text= "Qualification :"
                      };




                      //Return an assembled viewcell.
                      return new ViewCell
                      {
                          
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                         
                              Children =
                              {
                                  Titulo,
                                  new StackLayout
                                  {
                                      VerticalOptions=LayoutOptions.Center,
                                      Orientation = StackOrientation.Horizontal,
                                      Spacing=0,
                                      Children=
                                      {                                                 
                                          lblCalificacion,
                                          cursoId,
                                          Calificacion,
                                          
                                      }
                                  }
                              }
                          }
                      };

                  })

            };
    
            listView.ItemTapped += ListView_ItemTappedAsync;

            //Accomodate margin wich platform
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //Build the page.
           
        
            this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                    header,                    
                    nameUser,
                    listView
                    }
                }
            };
		}


        /// <summary>
        /// Navega hacia la lista de clases correspondiente al curso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            var x =(Xamarin.Forms.ListView) sender;
            var curso =(Models.Cursos) x.SelectedItem;
            await Navigation.PushAsync(new Clases(curso.CursoId));
        }
    }
}