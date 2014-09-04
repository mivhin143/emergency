using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using SQLite;



namespace Emergency

{

	public class mas

	{

		[PrimaryKey, AutoIncrement]

		public int Id { get; set; }		//POGI SI MIRVHI

		public string Fullname { get; set; }

		public string Location { get; set; }

		public string Types {get; set;}

	}

}



