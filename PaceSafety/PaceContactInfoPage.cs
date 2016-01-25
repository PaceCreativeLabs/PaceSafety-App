using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class PaceContactInfoPage: ContentPage
	{
		public PaceContactInfoPage ()
		{

			// Set Page Title
			Title = "Contact Information";

			// New York Campus Contact Information
			var nycContactInfo = new Label {
				Text = "New York Campus: \n41 Park Row, Suite 313 \nNew York, 10038 \n(212) 346-1600",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS

			};

			// Pleasantville Campus Contact Information
			var plvContactInfo = new Label {
				Text = "Pleasantville Campus: \nGoldstein Fitness Center, Room 125\n861 Bedford Road - Pleasantville, \nNew York, 10570 \n(914 )773-3760",
				TextColor = Color.FromHex("#2b2a2a"),
				FontSize = 16,
				FontFamily = Device.OnPlatform (
					"OpenSans",
					null,
					null
				), // set only for iOS
			};

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Padding = new Thickness(50,100,50,0),
					Spacing = 50,
					Children = {
						nycContactInfo,
						plvContactInfo
					}
				}
			};
		}
	}
}

