using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class AlertTypePage : ContentPage
	{
		AlertNavigationPage alertManager;

		public AlertTypePage (AlertNavigationPage alertManager)
		{
			this.alertManager = alertManager;

			// Create Screen Elements
			var emergencyButton = new Button {
				Text = "Emergency Alert",
				TextColor = Color.White,
				BackgroundColor = Color.Gray,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				MinimumHeightRequest = 300

			};
			emergencyButton.Clicked += (sender, e) => { 
				alertManager.alert.type = AlertType.Emergency;
				alertManager.GotoAlertDetails();
			};

			var nervousButton = new Button {
				Text = "Nervous Alert",
				TextColor = Color.White,
				BackgroundColor = Color.Gray,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				MinimumHeightRequest = 300,
			};
			nervousButton.Clicked += (sender, e) => { 
				alertManager.alert.type = AlertType.Nervous;
				alertManager.GotoAlertDetails();
			};


			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.CenterAndExpand,
					Spacing = 50,
					Children = {
						emergencyButton,
						nervousButton
					}
				}
			};
		}
	}
}

