using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;

namespace Emergency
{
	[Activity (Label = "Emergency", MainLauncher = true)]
	public class Activity1 : Activity, ILocationListener
	{
		LocationManager locmgr;
		database db = new database();
		public double latitude;
		public double longtitude;
		string locatx;
		string name;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			db.createDB ();

			ListView fi = (ListView)FindViewById (Resource.Id.listView1);
			List<you> yous = new List<you> ();
			you youso = new you();
			youso.tips ="Assess Your Current Emergency Preparedness Level";
			you youso1 = new you();
			youso1.tips ="Create an Emergency Exit Plan and Designate Meeting Areas";
			yous.Add (youso1);
			you youso2 = new you();
			youso2.tips ="Designate Emergency Contacts";
			yous.Add (youso2);
			you youso3 = new you();
			youso3.tips ="Prepare a Personal Emergency Contact Card for Each Family Member";
			yous.Add (youso3);
			you youso4 = new you();
			youso4.tips ="Educate Children on Preparedness";
			yous.Add (youso4);
			you youso5 = new you();
			youso5.tips ="First Aid Kit";
			yous.Add (youso5);
			you youso6 = new you();
			youso6.tips ="Get Connected, Be Informed and Stay Prepared";
			yous.Add (youso6);

			adapt ada = new adapt (this, yous);
			fi.Adapter = ada;
			locmgr = GetSystemService ((Context.LocationService)) as LocationManager;

			Button tbutton = (Button)FindViewById (Resource.Id.tButton);
			EditText input = new EditText (this);
			tbutton.Click += delegate{
				var dialog = new Dialog(this);
				dialog.SetTitle("Login");
				dialog.SetContentView(Resource.Layout.login);

				Button bOK = (Button)dialog.FindViewById(Resource.Id.bLogin);
				EditText fulln = (EditText)dialog.FindViewById(Resource.Id.fText);
				EditText locat = (EditText)dialog.FindViewById(Resource.Id.aTxt);

				locat.SetText(latitude.ToString() + ", " + longtitude.ToString(),EditText.BufferType.Normal);

				bOK.Click += delegate {
					name = fulln.Text;
					locatx = locat.Text;
					var dial = new Dialog(this);
					dial.SetTitle("Choose the appropriate choice");;
					dial.SetContentView(Resource.Layout.choices);	

					ImageButton im3 = (ImageButton)dial.FindViewById (Resource.Id.imageButton3);
					ImageButton im1 = (ImageButton)dial.FindViewById (Resource.Id.imageButton1);
					ImageButton im2 = (ImageButton)dial.FindViewById (Resource.Id.imageButton2);

					im3.Click += delegate {
						db.insertData(name,locatx,"police");
						Toast.MakeText(this,"Sent to police station",ToastLength.Short).Show ();
						dial.Cancel();
						dialog.Cancel();
					};
					im1.Click += delegate {
						db.insertData(name,locatx,"ambulance");
						Toast.MakeText(this,"Sent to hospital",ToastLength.Short).Show ();
						dial.Cancel();
						dialog.Cancel();
					};
					im2.Click += delegate {
						db.insertData(name,locatx,"fireman");
						Toast.MakeText(this,"Sent to fire station",ToastLength.Short).Show ();
						dial.Cancel();
						dialog.Cancel();
					};
					dial.Show ();
				};
				dialog.Show ();
			};
		}

		public void OnProviderDisabled (string provider)
		{
			throw new NotImplementedException ();
		}

		public void OnProviderEnabled (string provider)
		{
			throw new NotImplementedException ();
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
			if(status == Availability.OutOfService){
				Criteria locationCriteria = new Criteria();

				locationCriteria.Accuracy = Accuracy.Coarse;
				locationCriteria.PowerRequirement = Power.Medium;

				provider = locmgr.GetBestProvider(locationCriteria, true);

				if(provider != null)
				{
					locmgr.RequestLocationUpdates (provider, 2000, 1, this);
				} 
				else 
				{
					Console.WriteLine ("no provider available");
				}
			}
		}

		public void OnLocationChanged (Android.Locations.Location location)
		{
			latitude = location.Latitude;
			longtitude = location.Longitude;
		}
		protected override void OnResume ()
		{
			base.OnResume ();
			string provider = LocationManager.GpsProvider;

			if(locmgr.IsProviderEnabled(provider)){
				locmgr.RequestLocationUpdates (provider, 2000, 1, this);
		}else{
				Console.WriteLine (provider + " is not available");
			}
		}
	}
}

