using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class ContactsPage: ContentPage
	{
		public ContactsPage ()
		{
			// Set Page Title
			Title = "Emergency Contacts";

			// Create Screen Elements
			var testButton = new Button {
				Text = "Another Button",
				BackgroundColor = Color.Blue
			};

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						testButton
					}
				}
			};
		}
	}
}

