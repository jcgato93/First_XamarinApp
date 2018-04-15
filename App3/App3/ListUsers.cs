using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class ListUsers : ContentPage
	{
		public ListUsers ()
		{
            Label header = new Label
            {
                Text = "List of Courses",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            List<Models.Cursos> list = new List<Models.Cursos>()
            {
                new Models.Cursos()
                {
                    Titulo="Curso de Git",
                    Calificacion=8
                },

                new Models.Cursos()
                {
                    Titulo="Curso de Python",
                    Calificacion=10
                },

                new Models.Cursos()
                {
                    Titulo="Curso de Swift",
                    Calificacion=6
                },

                new Models.Cursos()
                {
                    Titulo="Curso de Algoritmos con C",
                    Calificacion=6
                },

                new Models.Cursos()
                {
                    Titulo="Curso de Node.js",
                    Calificacion=10
                },

                new Models.Cursos()
                {
                    Titulo="Curso de MEAN",
                    Calificacion=8
                },

                new Models.Cursos()
                {
                    Titulo="Curso de React.js",
                    Calificacion=6
                }

            };


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
                                          Calificacion,
                                          
                                      }
                                  }
                              }
                          }
                      };

                  })

            };

            //Accomodate margin wich platform
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //Build the page.
           
        
            this.Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                    header,
                    listView
                    }
                }
            };
		}
	}
}