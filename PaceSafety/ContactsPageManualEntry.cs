using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class ContactsPageManualEntry: ContentPage
	{
		Entry nameField;
		Entry phoneField;

		public ContactsPageManualEntry ()
		{
			// Set Page Title
			Title = "Edit Contact";

//			Contact contact = new Contact {
//				Name = nameField.Text,
//				Number = Convert.ToInt32(phoneField.Text)
//			};

			// NameField
			nameField = new Entry {
				Placeholder = "Enter Their Name",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
//			contact.Name = nameField.Text;
//			nameField.TextChanged += (object sender, TextChangedEventArgs e) => {};


			// PhoneField
			phoneField = new Entry {
				Placeholder = "Add Phone Number",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
//			contact.Number = Convert.ToInt32(phoneField.Text);

//			var saveButton = new Button {
//				Text = "save",
//				FontSize = 15,
//				TextColor = Color.White,
//				FontFamily = Device.OnPlatform (
//					"OpenSans",
//					null,
//					null
//				),
//				BackgroundColor = Color.Green,
//			};
//			saveButton.Clicked += (sender, e) => { AddContact(contact); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Spacing = 10,
					Padding = new Thickness(0,25,0,0),
					Children = {
						nameField,
						phoneField,
//						saveButton,
					}
				}
			};
		}
	}
}

