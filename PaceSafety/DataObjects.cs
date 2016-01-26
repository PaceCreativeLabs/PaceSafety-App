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
			Description,
			SubjectName;

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
			data.Add ("subjectName", SubjectName);
			return data;
		}
	}

	public enum AlertType { Emergency, Nervous }

	public struct Alert
	{
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

	public struct Contact : IEquatable<Contact>
	{
		public string Name;
		public int Number;
		public AlertType type;

		public bool Equals (Contact contact)
		{
			return (Name == contact.Name && Number == contact.Number && type == contact.type);
		}
	}

	public struct UserData
	{
		public string Username;
		public string FullName;
	}
		

	public sealed class Storage
	{
		private static volatile Storage instance;
		private static object syncRoot = new Object();

		private Storage() {}

		//
		private Report CurrentReport;
		private List<Contact> Contacts;
		private UserData UserData;

		public void SetReport (Report report) {
			CurrentReport = report;
		}
		public Report GetReport () {
			return CurrentReport;
		}

		public List<Contact> GetContacts () {
			return Contacts;
		}
		public void AddContact (Contact contact) {
			if (!Contacts.Contains (contact)) {
				Contacts.Add (contact);
			}
		}
		public void RemoveContact (Contact contact) {
			Contacts.Remove (contact);
		}
		public void SetContact (int index, Contact contact) {
			Contacts [index] = contact;
		}

		public UserData GetUserData () {
			return UserData;
		}
		public void SetUserData (UserData newUserData) {
			UserData = newUserData;
		}

		public void Save () {}
		private void Load () {
			var fakeData = new UserData ();
			fakeData.FullName = "Barak Michaely";
			fakeData.Username = "bm09148n";
			var fakeReport = new Report ();
			fakeReport.Description = "This is the template description";
			var fakeContact = new Contact ();
			fakeContact.Name = "Joey Q.";
			fakeContact.Number = 2125679043;

			Contacts = new List<Contact> ();
			SetReport (fakeReport);
			SetUserData (fakeData);
			AddContact (fakeContact);
		}
		//

		public static Storage Instance
		{
			get 
			{
				if (instance == null) 
				{
					lock (syncRoot) 
					{
						if (instance == null) {
							instance = new Storage();
							instance.Load ();
						}
					}
				}

				return instance;
			}
		}
	}
}

