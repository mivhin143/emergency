using System;

using SQLite;

using System.Linq;

using System.Collections.Generic;





namespace Emergency

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

		public void insertData(string fullname, string location, string type){

			var data = new mas { Fullname = fullname, Location = location, Types = type };

			db.Insert (data);

			db.Commit ();

		}

	}

}



