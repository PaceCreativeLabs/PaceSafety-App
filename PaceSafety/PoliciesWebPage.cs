using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class PoliciesWebPage: ContentPage
	{
		public PoliciesWebPage ()
		{

			// Set Page Title
			Title = "Pace Policies";

			var source = new UrlWebViewSource ();
			source.Url = "http://pace.edu/sexual-assault";
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

