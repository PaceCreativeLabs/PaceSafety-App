using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class ReportsPage: ContentPage
	{
		public ReportsPage ()
		{
			// Set Page Title
			Title = "Reports";

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

