using System;
using Xamarin.Forms;

namespace PaceSafety
{
	public class MainNavigationPage: NavigationPage
	{
		NavigationResponder responder;
		public MainNavigationPage (Page page) : base(page)
		{
			
		}

		protected override bool OnBackButtonPressed ()
		{
			Tools.Print ("BACK");
			if (responder != null) responder.onBackButtonPressed ();
			return base.OnBackButtonPressed ();
		}
	}
}

