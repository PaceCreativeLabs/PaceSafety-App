﻿using System;
<<<<<<< HEAD
using System.Collections.Generic;
using Newtonsoft.Json;
=======
>>>>>>> PaceSafety-UI
using Xamarin.Forms;

namespace PaceSafety
{
	public class App : Application
	{
		public enum SaveDataType { Reports, UserEmail, Contacts };
		public Dictionary<SaveDataType,Object> savedData;
		public APIClient api;

		public App (APIClient apiClient)
		{
			// Create Custom Navigation Page
<<<<<<< HEAD
			var homePage = new HomePage ();
			api = apiClient;
			homePage.api = api;
			homePage.testAPI ();
			var navigationPage = new NavigationPage(homePage);
			navigationPage.BarBackgroundColor = Color.Blue;
=======
			var navigationPage = new NavigationPage(new HomePage () );
			navigationPage.BarBackgroundColor = Color.FromHex("1c6cb6");
>>>>>>> PaceSafety-UI
			navigationPage.BarTextColor = Color.White;
			// The root page of your application
			MainPage = navigationPage;
		}

		public void Save () {
			api.SaveData (JsonConvert.SerializeObject (savedData));
		}
		public void Load () {
			try {
				var data = JsonConvert.DeserializeObject<Dictionary<SaveDataType,Object>> (api.LoadData ());
				savedData = data;
			}
			catch {
				Tools.Print (".Failed Load.");
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

