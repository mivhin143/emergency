using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Threading;

namespace admin
{
	[Activity (Label = "admin", MainLauncher = true)]
	public class Activity1 : Activity
	{
		database db = new database();
		ListView listx;
		NotificationManager notificationManager;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			db.createDB ();
			listx = (ListView)FindViewById (Resource.Id.lview);
			Button pb = (Button)FindViewById (Resource.Id.pButton);
			Button ab = (Button)FindViewById (Resource.Id.aButton);
			Button fb = (Button)FindViewById (Resource.Id.fButton);

			new Thread (new ThreadStart(() => {
				checknew (this.ApplicationContext);
			})).Start ();
		}

		public void checknew(Context conts){
			int count = 0;
			int change = 0;
			int bam = 123;
			notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			Notification n = new Notification (Resource.Drawable.asda,"New Emergency");
			PendingIntent pending=PendingIntent.GetActivity(conts,0, new Intent(),0);
			while (true) {
				List<mas> laro = db.GetAll ();
				List<mas> larohey = new List<mas> ();
				if (count.ToString () == change.ToString ()) {
				} else {
					notificationManager.Cancel (bam);
					n.SetLatestEventInfo(conts,"New Emergency","Police Emergency",pending);
					notificationManager.Notify (bam, n);
					change = count;
				}
				foreach (mas std in laro) {
					if (std.Types == "police") {
						larohey.Add (std);
					}
				}
				count = larohey.Count;
				adapt ada = new adapt (this, larohey);
				RunOnUiThread (() => listx.Adapter = ada);
			}
		}
	}
}


