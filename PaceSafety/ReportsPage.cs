using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PaceSafety
{
	public class ReportsPage: ContentPage
	{
		public ReportsPage ()
		{
			// Set Page Title
			Title = "Reports";

			// Create Screen Elements
			var list = new ListView {
				
			};
			list.ItemsSource = new string[]{
				"mono",
				"monodroid"
			};
			list.IsGroupingEnabled = true;
			list.GroupDisplayBinding = new Binding ("Title");
			list.GroupShortNameBinding = new Binding ("ShortName");


			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						list
					}
				}
			};
		}




	}
}

