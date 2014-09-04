using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Emergency
{
	[Activity (Label = "cho")]			
	public class cho : Activity
	{
		public string fname;
		public string location;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.choices);

			database db = new database ();
			db.createDB ();

			ImageButton3.
		}
	}
}

