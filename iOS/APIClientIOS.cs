using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaceSafety.iOS
{
	public class APIClientIOS : APIClient
	{
		public APIClientIOS () {}

		protected override void Post (string url, JObject jsonData, Action<Object> callback) {}
		protected override void Get (string url, Action<JObject> callback) {}

		public override bool SendReport (Report report) 
		{
			return false;
		}
		public override bool SendAlert (Alert alert) 
		{
			return false;
		}
		public override Locations GetLocations (string currentGPSLocation)
		{
			return new Locations ();
		}


		public override void SaveData (string data)
		{
			throw new NotImplementedException ();
		}
		public override string LoadData ()
		{
			throw new NotImplementedException ();
		}

	}
}

