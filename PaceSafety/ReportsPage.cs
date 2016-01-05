using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PaceSafety
{
	public class ReportsPage: ContentPage
	{
		public APIClient api;

		public ReportsPage ()
		{
			// Set Page Title
			Title = "Reports";

//			// Create Screen Elements
//			var list = new ListView {
//				
//			};
//			list.ItemsSource = new string[]{
//				"mono",
//				"monodroid"
//			};
//			list.IsGroupingEnabled = true;
//			list.GroupDisplayBinding = new Binding ("Title");
//			list.GroupShortNameBinding = new Binding ("ShortName");
//
//
			var button = new Button {
				Text = "Send Test Report",
				TextColor = Color.White,
				BackgroundColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				MinimumHeightRequest = 100
			};
			button.Clicked += (sender, e) => { fakeReport(); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Children = {
						button
					}
				}
			};
		}

		private void fakeReport() {
			var report = new Report ();
			report.Name = "Joseph Josephson";
			report.IncidentType = "Assault";
			report.Email = "bm09148n@pace.edu";
			api.SendReport (report, success => {
				Tools.Print("Sent Report: " + success.ToString());
			});
		}
	}
}

