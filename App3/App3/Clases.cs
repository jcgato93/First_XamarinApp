using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class Clases : ContentPage
	{
		public Clases (long cursoId)
		{

            var list = Services.ClasesService.ObtenerClases(cursoId);

            Label header = new Label { Text="Listado de Clases"};

            ListView listView = new ListView
            {
                //Origen de datos
                ItemsSource = list,
                RowHeight = 50,

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

                    Label clasesId = new Label { IsVisible = false };
                    clasesId.SetBinding(Label.TextProperty, "CursoId");

                    Label lblCalificacion = new Label()
                    {
                        Text = "Qualification :"
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
                                          clasesId,
                                          Calificacion,

                                      }
                                  }
                              }
                        }
                    };

                })

            };

            listView.ItemTapped += ListView_ItemTapped; ;

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

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var x = (Xamarin.Forms.ListView)sender;
            var clases = (Models.Clases)x.SelectedItem;
            await Navigation.PushAsync(new Videos(clases.LinkVideo));
        }
    }
}