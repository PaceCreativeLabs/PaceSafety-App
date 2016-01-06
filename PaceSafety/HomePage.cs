using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class HomePage: ContentPage
	{
		public HomePage ()
		{
			// Set Page Properties
			Title = "Pace Safety";
			BackgroundColor = Color.White;

			// Create Screen Elements
			var alertButton = new Button {
				Text = "EMERGENCY ALERT!",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
//				BackgroundColor = Color.Red,
				HeightRequest = 200
			};
			alertButton.Clicked += (sender, e) => { openAlertPage(); };

			var reportButton = new Button {
				Text = "File a Report",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
//				BackgroundColor = Color.Teal,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			reportButton.Clicked += (sender, e) => { openReportsPage(); };

			var infoButton = new Button {
				Text = "Information",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
//				BackgroundColor = Color.Blue,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			infoButton.Clicked += (sender, e) => { openInfoPage(); };

			var contactsButton = new Button {
				Text = "My Emergency Contacts",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
//				BackgroundColor = Color.Silver
			};
			contactsButton.Clicked += (sender, e) => { openContactsPage(); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(50,100,50,0),
					Spacing = 100,
					Children = {
						alertButton,
						new ContentView {
							Content = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = {
									reportButton,
									infoButton,		
								}
							}
						},
						contactsButton
					}
				}
			};
					
		}

		/* Navigation Functions */
		private void openAlertPage () {
			Navigation.PushAsync(new AlertPage ());
		}
		private void openInfoPage () {
			Navigation.PushAsync(new InfoPage ());
		}
		private void openContactsPage () {
			Navigation.PushAsync(new ContactsPage ());
		}
		private void openReportsPage () {
			Navigation.PushAsync(new ReportsPage ());
		}
	}
}

