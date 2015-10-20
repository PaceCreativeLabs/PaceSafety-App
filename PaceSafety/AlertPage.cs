using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class AlertPage: ContentPage
	{
		public AlertPage ()
		{
			// Set Page Title
			Title = "Alert!";

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

