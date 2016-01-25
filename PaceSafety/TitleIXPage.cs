using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class TitleIXPage: ContentPage
	{
		public TitleIXPage ()
		{

			// Set Page Title
			Title = "Title IX Rights";

			var source = new UrlWebViewSource ();
			source.Url = "http://knowyourix.org/title-ix/title-ix-the-basics/";
			var webView = new WebView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Source = source
			};
			webView.Navigating += (object sender, WebNavigatingEventArgs e) => {
				System.Diagnostics.Debug.WriteLine("Loading");
			};
			webView.Navigated += (object sender, WebNavigatedEventArgs e) => {
				System.Diagnostics.Debug.WriteLine("Done");
			};

			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						webView
					}	
				}
			};
		}
	}
}

