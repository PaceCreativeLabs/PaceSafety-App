using System;
using System.Collections.Generic;
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
				Text = "Alert",
				TextColor = Color.White,
				BackgroundColor = Color.Red,
				HeightRequest = 200
			};
			alertButton.Clicked += (sender, e) => { openAlertPage(); };

			var reportButton = new Button {
				Text = "Report",
				TextColor = Color.White,
				BackgroundColor = Color.Teal,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			reportButton.Clicked += (sender, e) => { openReportsPage(); };

			var infoButton = new Button {
				Text = "Info",
				TextColor = Color.White,
				BackgroundColor = Color.Blue,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			infoButton.Clicked += (sender, e) => { openInfoPage(); };

			var contactsButton = new Button {
				Text = "My Contacts",
				TextColor = Color.White,
				BackgroundColor = Color.Silver
			};
			contactsButton.Clicked += (sender, e) => { openContactsPage(); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(50,0,50,0),
					Spacing = 50,
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

