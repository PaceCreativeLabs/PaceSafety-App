using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class InfoPage: ContentPage
	{
		public InfoPage ()
		{
			// Set Page Title
			Title = "Information";

			// Create Screen Elements
			var testButton = new Button {
				Text = "Another Button",
				BackgroundColor = Color.Blue
			};

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						testButton
					}
				}
			};
		}
	}
}

