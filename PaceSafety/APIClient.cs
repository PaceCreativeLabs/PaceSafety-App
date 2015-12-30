using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaceSafety
{
	abstract public class APIClient
	{
		protected string userEmail;

		public APIClient () {}

		abstract protected void Post (string url, JObject jsonData, Action<Object> callback);
		abstract protected void Get (string url, Action<JObject> callback);

		abstract public bool SendReport (Report report);
		abstract public bool SendAlert (Alert alert);
		abstract public Locations GetLocations (string currentGPSLocation);

		abstract public void SaveData (string data);
		abstract public string LoadData ();
	}
}

