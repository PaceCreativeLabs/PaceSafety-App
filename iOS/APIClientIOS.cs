using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PaceSafety.iOS
{
	public class APIClientIOS : APIClient
	{
		public APIClientIOS () {}

		protected override void Post (string url, Object data, Action<Object> callback) 
		{
			var webClient = new WebClient ();
			var formattedUrl = new Uri(url);

			webClient.UploadValuesCompleted += (object sender, UploadValuesCompletedEventArgs e) => {
				if (e.Error != null) Tools.Print(e.Error);
				Tools.Print(Encoding.UTF8.GetString(e.Result));
			};
			if (data is NameValueCollection) webClient.UploadValuesAsync (formattedUrl, data as NameValueCollection);
			else callback (null);
		}
		protected override void Get (string url, bool parse, Action<Object> callback) 
		{
			var webClient = new WebClient();
			var formattedUrl = new Uri(url);

			webClient.DownloadStringCompleted += (s, e) => {
				if (e.Error != null) Tools.Print(e.Error);
				if (!parse) {
					callback(e.Result);
					return;
				}

				JObject json = null;
				try { json = JObject.Parse (e.Result); }
				catch { /* Error Parsing Response */ }
				finally { callback (json); }
			};
			webClient.Encoding = Encoding.UTF8;
			webClient.DownloadStringAsync(formattedUrl);
		}

		public override void SendReport (Report report, Action<bool> callback) 
		{
			var url = serverUrl + "/report";
			var collection = DictionaryToNameValue (report.ToDictionary ());

			Post (url, collection, data => {
				try {
					Tools.Print(data);
					callback(true);
				}catch {
					Tools.Print("Error");
					callback(false);
				}
			});
		}
		public override void SendAlert (Alert alert, Action<bool> callback) 
		{
			var url = serverUrl + "/alert";
			NameValueCollection collection = DictionaryToNameValue (alert.ToDictionary ()) as NameValueCollection;
			collection.Add ("to", toPhoneNumber); // for testing different phones

			Post (url, collection, data => {
				try {
					Tools.Print(data);
					callback(true);
				}catch {
					Tools.Print("Error");
					callback(false);
				}
			});
		}
		public override void GetLocations (Action<Locations> callback)
		{
			var url = serverUrl + "/locations";

			Get (url,false, data => {
				var l = new Locations (data as string);
				callback(l);
			});
		}


		public override void SaveData (string data)
		{
			throw new NotImplementedException ();
		}
		public override string LoadData ()
		{
			throw new NotImplementedException ();
		}
			
		public Object DictionaryToNameValue (Dictionary<string,string> d) {
			var collection = new NameValueCollection ();
			foreach (KeyValuePair<string,string> pair in d) {
				collection.Add (pair.Key, pair.Value);
			}
			return collection;
		}
	}
}

