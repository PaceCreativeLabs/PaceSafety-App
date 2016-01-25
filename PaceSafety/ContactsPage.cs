using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class ContactsPage: ContentPage
	{
		public ContactsPage (Action doneAction) 
		{
			//NavigationPage.TitleIconProperty = null;
			var contacts = Storage.Instance.GetContacts ();
			Tools.Print ("==Contacts==");
			Tools.Print (contacts[0].Name);
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

