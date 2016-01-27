using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;

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
			var policiesButton = new ImageButton {
//				Text = "Pace Policies",
//				TextColor = Color.FromHex("#2b2a2a"),
//				FontSize = 16,
//				FontFamily = Device.OnPlatform (
//					"OpenSans",
//					null,
//					null
//				), // set only for iOS
				Image = "Policies_FakeButton.png",
				WidthRequest = 200,
				HeightRequest = 200,
				
			};
			policiesButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PoliciesWebPage());
			};

			// Title IX button
			var titleIXButton = new Button {
//				Text = "Title IX",
//				TextColor = Color.FromHex("#2b2a2a"),
//				FontSize = 16,
//				FontFamily = Device.OnPlatform (
//					"OpenSans",
//					null,
//					null
//				), // set only for iOS
				Image = "TitleIX_FakeButton.png",
				WidthRequest = 200,
				HeightRequest = 200,
			};
		// Functionality of button: 
			titleIXButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new TitleIXPage());
			};

			// contact button
			var contactButton = new Button {
//				Text = "Contact Info",
//				TextColor = Color.FromHex("#2b2a2a"),
//				FontSize = 16,
//				FontFamily = Device.OnPlatform (
//					"OpenSans",
//					null,
//					null
//				), // set only for iOS
				Image = "Counseling_FakeButton.png",
				WidthRequest = 200,
				HeightRequest = 200,
			};
			contactButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new PaceContactInfoPage());
			};

			// Emergency Contacts button
			var emergencyButton = new Button {
//				Text = "Emergency Contacts",
//				TextColor = Color.FromHex("#2b2a2a"),
//				FontSize = 16,
//				FontFamily = Device.OnPlatform (
//					"OpenSans",
//					null,
//					null
//				),
				Image = "MyContacts_FakeButton.png",
				WidthRequest = 200,
				HeightRequest = 200,
			};
			emergencyButton.Clicked += (sender, e) =>  {
				Navigation.PushAsync(new ContactsPage());
			};

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(0,0,0,0),
//					Spacing = 50,
					Children = {
						emergencyButton,
						contactButton,
						policiesButton,
						titleIXButton
					}
				}
			};


			// test here



			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(0,50,0,0),
					Children = {
						new ContentView {
							Content = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = {
									emergencyButton,
									contactButton,
								}
							}
						},
						new ContentView {
							Content = new StackLayout {
								Orientation = StackOrientation.Horizontal,
								Children = {
									policiesButton,
									titleIXButton,
								}
							}
						}
					}
				}
			};







			// test ends here

		}
	}
}

