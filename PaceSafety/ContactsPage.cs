using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class ContactsPage: ContentPage
	{
		public ContactsPage (Action doneAction = null) 
		{
			//NavigationPage.TitleIconProperty = null;
			var contacts = Storage.Instance.GetContacts ();
			Tools.Print ("==Contacts==");
			Tools.Print (contacts[0].Name);
			// Set Page Title
			Title = "Contacts";
			var addButton = new ToolbarItem {
				Text = "+",
			};
			ToolbarItems.Add (addButton);
			addButton.Clicked += (sender, e) =>  {
				Navigation.PushAsync(new ContactsPageManualEntry());
			};

			// Create Screen Elements
			var testButton = new Button {
				Text = "Another Button",
				BackgroundColor = Color.Blue
			};

			// Hardcoded buttons
			var contact1 = new Button {
				Text = "Hana Stanojkovic",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
//			This is not working for some reason
//			contact1.Clicked += (sender, e) => { openContactsPageManualEntry(); };

			var contact2 = new Button {
				Text = "Barak Michaely",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
//			This is not working for some reason
//			contact2.Clicked += (sender, e) => { openContactsPageManualEntry(); };

			var contact3 = new Button {
				Text = "John Doe",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
//			This is not working for some reason
//			contact3.Clicked += (sender, e) => { openContactsPageManualEntry(); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Spacing = 0,
					Padding = new Thickness(0,25,0,0),
					Children = {
						contact1,
						new Label {
							Text = "(510) 159-5728",
							HorizontalOptions = LayoutOptions.Center,
							FontSize = 15,
							HeightRequest = 60,
						},
						contact2,
						new Label {
							Text = "(245) 277-4031",
							HorizontalOptions = LayoutOptions.Center,
							FontSize = 15,
							HeightRequest = 60,
						},
						contact3,
						new Label {
							Text = "(778) 916-6514",
							HorizontalOptions = LayoutOptions.Center,
							FontSize = 15,
							HeightRequest = 60,
						},
					}
				}
			};


		}
	}
}

