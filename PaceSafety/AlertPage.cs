using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class AlertPage: ContentPage
	{
		public APIClient api;

		public AlertPage ()
		{
			// Set Page Title
			Title = "Alert!";

			// Create Screen Elements
			var button = new Button {
				Text = "Send Test Alert",
				TextColor = Color.White,
				BackgroundColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				MinimumHeightRequest = 100

			};
			button.Clicked += (sender, e) => { fakeAlert(); };


			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						button
					}
				}
			};
		}

		private void fakeAlert () {
			var alert = new Alert ();
			alert.Name = "Joseph Josephson";
			alert.type = Alert.AlertType.Emergency;
			alert.LocationAddress = "1 Pace Plaza";
			//alert.contactNumbers = new List<string>();
			api.SendAlert (alert, success => {
				Tools.Print("Sent Alert: " + success.ToString());
			});
		}
			
	}
}

