using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class Videos : ContentPage
	{
        string rutaVideo = "";

		public Videos (string iframe)
		{
            rutaVideo = iframe;

            Label header = new Label
            {
                Text = "WebView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            WebView webView = new WebView
            {
                Source= new HtmlWebViewSource { Html = rutaVideo },
                //Source = new UrlWebViewSource
                //{
                //    Url = "http://10.81.44.236/proyectoPI/Views/Home.aspx",
                //},
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    webView
                }
            };
        }
	}
}