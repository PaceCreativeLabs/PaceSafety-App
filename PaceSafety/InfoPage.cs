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
			var policiesButton = new Button {
				Text = "Pace Policies",
				TextColor = Color.White,
				BackgroundColor = Color.Blue
			};
			policiesButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PoliciesWebPage());
			};

			var contactButton = new Button {
				Text = "Contact Info",
				TextColor = Color.White,
				BackgroundColor = Color.Green
			};
			contactButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PaceContactInfoPage());
			};

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(50,0,50,0),
					Spacing = 50,
					Children = {
						policiesButton,
						contactButton
					}
				}
			};
		}
	}
}

