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

	public class adapt : BaseAdapter

	{

		Context context;

		List<you> hey;

		public adapt(Context context, List<you> hey):base(){

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

				row = lays.Inflate (Resource.Layout.row, parent, false);

			} else {

				row = convertView;

			}

			var label = row.FindViewById (Resource.Id.medtech) as TextView;

			label.SetText (hey[position].tips, TextView.BufferType.Normal);

			return row;

		}

	}

}



