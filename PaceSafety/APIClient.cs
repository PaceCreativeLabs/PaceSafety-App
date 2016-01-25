using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaceSafety
{
	abstract public class APIClient
	{
		protected string serverUrl = "http://sclapp.herokuapp.com"; //"http://localhost:8080"; 
		protected string toPhoneNumber = "15107594352";
		protected string userEmail;

		public APIClient () {}

		abstract protected void Post (string url, Object data, Action<Object,Object> callback);
		abstract protected void Get (string url, bool parse, Action<Object> callback);

		abstract public void SendReport (Report report, Action<bool> callback);
		abstract public void SendAlert (Alert alert, Action<bool> callback);
		abstract public void GetLocations (Action<Locations> callback);

		abstract public void SaveData (string data);
		abstract public string LoadData ();
	}
}

