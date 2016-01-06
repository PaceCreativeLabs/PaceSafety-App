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
		
			// policies button
			var policiesButton = new Button {
				Text = "Pace Policies",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
				
			};
			policiesButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PoliciesWebPage());
			};

			// Title IX button
			var titleIXButton = new Button {
				Text = "Title IX",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
			};
		// Functionality of button: 
			titleIXButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new TitleIXPage());
			};

			// contact button
			var contactButton = new Button {
				Text = "Contact Info",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
			};
			contactButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PaceContactInfoPage());
			};


			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(50,100,50,0),
					Spacing = 50,
					Children = {
						policiesButton,
						titleIXButton,
						contactButton
					}
				}
			};
		}
	}
}

