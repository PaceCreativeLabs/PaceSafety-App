using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace PaceSafety
{
	public class HomePage: ContentPage
	{
		public APIClient api;

		public HomePage ()
		{
			// Set Page Properties
			Title = "Pace Safety";
			BackgroundColor = Color.White;

//			// Images
			var alertImage = new Image { Aspect = Aspect.AspectFit };
			alertImage.Source = ImageSource.FromFile("AlertButton.png");

			var reportImage = new Image { Aspect = Aspect.AspectFit };
			reportImage.Source = ImageSource.FromFile("FileAReport.png");

			var informationImage = new Image { Aspect = Aspect.AspectFit };
			informationImage.Source = ImageSource.FromFile("Information.png");

			// Button Setup 

			var alertButton = new ImageButton {
				Orientation = XLabs.Enums.ImageOrientation.ImageOnTop,
				WidthRequest = 250,
				HeightRequest = 300,
//				Image = "AlertButton.png",
				Image = "Emergency_FakeButton.png",
			};
			alertButton.Clicked += (sender, e) => { openAlertPage(); };

			var reportButton = new ImageButton {
				Orientation = XLabs.Enums.ImageOrientation.ImageToLeft,
				WidthRequest = 200,
				HeightRequest = 200,
//				Image = "FileAReport.png",
				Image = "Report_FakeButton.png",
			};
			reportButton.Clicked += (sender, e) => { openReportsPage(); };

			var informationButton = new ImageButton {
				Orientation = XLabs.Enums.ImageOrientation.ImageToLeft,
				WidthRequest = 200,
				HeightRequest = 200,
//				Image = "Information.png",
				Image = "Information_FakeButton.png"
			};
			informationButton.Clicked += (sender, e) => { openInfoPage(); };

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
					Padding = new Thickness(0,25,0,0),
//					Spacing = -	5,
					Children = {
//						alertButton,
						new ContentView {
							Content = new StackLayout {
//								Padding = new Thickness(75,20,50,0),
								Children = {
									alertButton,
//									new Label
//									{
//										Text = "EMERGENCY ALERT!",
//										TextColor = Color.FromHex ("#2b2a2a"),
//										FontSize = 20,
//										FontAttributes = FontAttributes.Bold,
//										FontFamily = Device.OnPlatform (
//											"OpenSans",
//											null,
//											null
//										), // set only for iOS
//										HeightRequest = 75,
//									},
								}
							}
						},
						new ContentView {
							Content = new StackLayout {
								Padding = new Thickness(0,0,50,0),
								Orientation = StackOrientation.Horizontal,
								Children = {
										reportButton,
										informationButton,
								}
							}
						},
//						new ContentView {
//							Content = new StackLayout {
//								Padding = new Thickness(0,0,0,50),
//								Orientation = StackOrientation.Horizontal,
//								Children = {
//									new Label
//									{
//										Text = "File a Report",
//										TextColor = Color.FromHex ("#2b2a2a"),
//										FontSize = 15,
//										FontFamily = Device.OnPlatform (
//											"OpenSans",
//											null,
//											null
//										), // set only for iOS
//										HorizontalOptions = LayoutOptions.Start,
//									},
//									new Label
//									{
//										Text = "Information",
//										TextColor = Color.FromHex ("#2b2a2a"),
//										FontSize = 15,
//										FontFamily = Device.OnPlatform (
//											"OpenSans",
//											null,
//											null
//										), // set only for iOS
//										HorizontalOptions = LayoutOptions.End,
//									},
//								}
//							}
//						}
					}
				}
			};
		}

		public void testAPI () {
			api.GetLocations (locations => {
				Tools.Print("Locations:::");
				Tools.Print(locations.GetCampuses()[1]);
			});
		}

		/* Navigation Functions */
		private void openAlertPage () {
			var alertNav = new AlertNavigationPage (api);
			alertNav.doneAction = () => {
				Navigation.PopModalAsync ();
			};
			Navigation.PushModalAsync (alertNav);
		}
		private void openInfoPage () {
			Navigation.PushAsync(new InfoPage ());
		}
		private void openContactsPage () {
			Navigation.PushAsync(new ContactsPage (null));
		}
		private void openReportsPage () {
			var reportsPage = new ReportsPage ();
			reportsPage.api = api;
			Navigation.PushAsync(reportsPage);
		}

	}
}

