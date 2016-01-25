using System;
using Xamarin.Forms;
using Xamarin;
using System.Threading.Tasks;

namespace PaceSafety
{
	public class AlertNavigationPage : NavigationPage
	{
		public Action doneAction;
		public Alert alert;
		APIClient api;

		public AlertNavigationPage (APIClient api)
		{
			this.api = api;
			var alertTypePage = new AlertTypePage (this);
			this.PushAsync (alertTypePage, false);

			var cancelButton = new ToolbarItem {
				Text = "CANCEL",
				Order = ToolbarItemOrder.Primary,
				Command = new Command (() => this.cancelAlert() )
			};
			ToolbarItems.Add (cancelButton);
		}

		public void GotoAlertDetails () {
			var alertDetails = new AlertDetailsPage (this);
			SetHasBackButton (alertDetails, false);
			Navigation.PushAsync (alertDetails,false);
		}
		public void cancelAlert () {
			doneAction ();
		}
		public async void SendAlert () {
			// Alert "SENDING"
			var loadingPage = new LoadingPage ();
			Navigation.PushModalAsync (loadingPage,false);

			// Fakedness
			alert.Name = "Generic Person";
			alert.LocationAddress = "1 Pace Plaza";

			// Send
			api.SendAlert (alert, async (success) => {
				Tools.Print("Sent Alert: " + success.ToString());
				await Task.Delay(1000);
				loadingPage.Close();
				doneAction ();
			});
		}
	}
}

