using System;

using SQLite;

using System.Linq;

using System.Collections.Generic;





namespace admin

{

	public class database

	{

		SQLiteConnection db;



		public void createDB()

		{

			var documents = "/sdcard";

			db = new SQLiteConnection(System.IO.Path.Combine(documents,"emera.db"));

			db.CreateTable<mas> ();

		}

		public void dropTable(){

			var documents = "/sdcard";

			db = new SQLiteConnection(System.IO.Path.Combine(documents,"emera.db"));

			db.DropTable<mas> ();

		}

		public List<mas> GetAll(){

			var query = from c in db.Table<mas> ()

				select c;

			return query.ToList ();

		}

	}

}



