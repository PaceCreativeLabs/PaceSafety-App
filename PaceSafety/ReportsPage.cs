using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PaceSafety
{
	public class ReportsPage: ContentPage
	{
		public APIClient api;

		Entry nameField;
		Entry subjectNameField;

		public ReportsPage ()
		{
			var report = Storage.Instance.GetReport ();

			// Set Page Navigation Bar
			Title = "Create a Report";
			var clearButton = new ToolbarItem {
				Text = "Clear All",
				Command = new Command(()=> {
					ClearReport();
				})
			};
			ToolbarItems.Add (clearButton);

			// Name Field
			nameField = new Entry {
				Placeholder = "Enter Your Name",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
			nameField.TextChanged += (object sender, TextChangedEventArgs e) => { DataChanged (); };

			// Date Field
			subjectNameField = new Entry {
				Placeholder = "Enter Subject's Name",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.White,
				TextColor = Color.Black
			};
			subjectNameField.TextChanged += (object sender, TextChangedEventArgs e) => { DataChanged (); };
			// Time
			// Location
			// Subject Name
			// Subject Description

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
				Text = "Send Report",
				TextColor = Color.White,
				BackgroundColor = Color.Green,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				MinimumHeightRequest = 100
			};
			button.Clicked += (sender, e) => { SendReport(); };

			// Create Screen Content
			Content = new ContentView {
				Content = new StackLayout {
					Spacing = 10,
					Children = {
						nameField,
						subjectNameField,
						button
					}
				}
			};

			PopulateFields();
		}

		async void ClearReport(bool prompt = true) {
			if (!prompt) {
				Storage.Instance.SetReport (new Report ());
				PopulateFields ();
				return;
			}

			var clearString = "Clear All";
			var alertTask = DisplayActionSheet ("Are You Sure You Want To Clear All Fields?", "Cancel", clearString);
			var selection = await alertTask;

			if (selection == clearString) {
				Storage.Instance.SetReport (new Report ());
				PopulateFields ();
			}
		}
		void PopulateFields() {
			var report = Storage.Instance.GetReport ();
			nameField.Text = report.Name;
			subjectNameField.Text = report.SubjectName;
		}
		void DataChanged() {
			// save to actual report
			var report = Storage.Instance.GetReport();
			report.Name = nameField.Text;
			report.SubjectName = subjectNameField.Text;
			Storage.Instance.SetReport (report);
		}
		async void SendReport() {
			var report = Storage.Instance.GetReport ();
			report.IncidentType = "Assault";
			report.Email = "bm09148n@pace.edu";
			api.SendReport (report, async (success) => {
				Tools.Print("Sent Report: " + success.ToString());
				if (success) {
					ClearReport(false);
					Navigation.PopAsync();
					var alert = DisplayAlert("Report Sent","Your Report has been recieved","OK");			
				}
			});
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

