using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class App : Application
	{
		public App ()
		{
			// Create Custom Navigation Page
			var navigationPage = new NavigationPage(new HomePage () );
			navigationPage.BarBackgroundColor = Color.FromHex("1c6cb6");
			navigationPage.BarTextColor = Color.White;
			// The root page of your application
			MainPage = navigationPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

