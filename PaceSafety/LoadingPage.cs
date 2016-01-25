using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class LoadingPage : ContentPage
	{
		public LoadingPage ()
		{

			// Create Screen Content
			Content = new ContentView {
				BackgroundColor = Color.FromRgba(255,255,255,0.4),
				Content = new StackLayout {
					Children = {
						new Label {
							Text = "Loading...",
							VerticalOptions = LayoutOptions.Center,
							HorizontalOptions = LayoutOptions.Center
						}
					}
				}
			};
			
		}

		public void Close () {
			Tools.Print ("Closing Myself");
			Navigation.PopModalAsync (false);
		}
	}
}

