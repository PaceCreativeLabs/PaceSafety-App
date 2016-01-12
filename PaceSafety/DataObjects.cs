using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PaceSafety
{
	public static class Tools
	{
		public static void Print (Object value) {
			System.Diagnostics.Debug.WriteLine (value);
		}
	}


	public struct Report
	{
		public string 
			Name, 
			Email, 
			IncidentDate, 
			IncidentTime, 
			IncidentType,
			IncidentLocation,
			Description;

		public string ToJsonString () {
			return JsonConvert.SerializeObject (ToDictionary ());
		}

		public Dictionary<string,string> ToDictionary () {
			var data = new Dictionary<string,string> ();
			data.Add ("name", Name);
			data.Add ("email", Email);
			data.Add ("date", IncidentDate);
			data.Add ("time", IncidentTime);
			data.Add ("type", IncidentType);
			data.Add ("location", IncidentLocation);
			data.Add ("description", Description);
			return data;
		}
	}

	public struct Alert
	{
		public enum AlertType { Emergency, Nervous }

		public AlertType type;
		public List<string> contactNumbers;
		public string 
			Name,
			Email,
			LocationAddress, // Actual Address or Campus/Building Combo
			LocationCoordinates,
			LocationExtraInfo;

		public string ToJsonString ()
		{
			return JsonConvert.SerializeObject (ToDictionary ());
		}

		public Dictionary<string,string> ToDictionary () {
			var data = new Dictionary<string,string> ();
			data.Add ("type", type.ToString ());
			data.Add ("name", Name);
			data.Add ("email", Email);
			data.Add ("address", LocationAddress);
			data.Add ("coordinates", LocationCoordinates);
			data.Add ("locationExtra", LocationExtraInfo);
			data.Add ("contacts", JsonConvert.SerializeObject (contactNumbers));
			return data;
		}
	}

	public struct Locations
	{
		private Dictionary<string,List<string>> locations;
		public Locations (string jsonString)
		{
			try {
				var data = JsonConvert.DeserializeObject<Dictionary<string,List<string>>> (jsonString);
				locations = data as Dictionary<string,List<string>>;
			}
			catch {
				locations = new Dictionary<string,List<string>> ();	
			}
		}

		public List<string> GetCampuses () {
			return new List<string> (locations.Keys);
		}
		public List<string> GetBuildings (string campus) {
			if (locations.ContainsKey (campus)) {
				return locations [campus];
			}
			return new List<string> ();
		}
	}
}

