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



namespace admin

{

	public class adapt : BaseAdapter

	{

		Context context;

		List<mas> hey;

		public adapt(Context context, List<mas> hey):base(){

			this.context = context;

			this.hey = hey;

		}

		public override Java.Lang.Object GetItem (int position)

		{

			return position;

		}

		public override int Count

		{

			get { return this.hey.Count;}

		}

		public override long GetItemId (int position)

		{

			return position;

		}

		public override View GetView (int position, View convertView, ViewGroup parent)

		{

			View row = null;

			if (convertView == null) {

				var lays = context.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;

				row = lays.Inflate (Resource.Layout.bam, parent, false);

			} else {

				row = convertView;

			}

			var label = row.FindViewById (Resource.Id.tName) as TextView;

			var label2 = row.FindViewById (Resource.Id.tLocation) as TextView;



			label.SetText (hey[position].Fullname, TextView.BufferType.Normal);

			label2.SetText (hey[position].Location, TextView.BufferType.Normal);

			return row;

		}

	}

}



