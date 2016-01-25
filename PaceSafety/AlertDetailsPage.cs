using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class AlertDetailsPage : ContentPage
	{
		public AlertDetailsPage (AlertNavigationPage alertManager)
		{
			// MAP MODULE
				// Address
				// Map
			// TEXT MODULE
				// Room -- Floor
			// SEND MODULE
				//Button

			// Create Screen Elements
			var button = new Button {
				Text = "Send Test Alert",
				TextColor = Color.White,
				BackgroundColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				MinimumHeightRequest = 100

			};
			button.Clicked += (sender, e) => {
				alertManager.SendAlert ();
			};


			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						button
					}
				}
			};
		}
	}
}

