using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
	public class Position
	{
		string direction;
		string local;

		public Position() { }

		public Position(string direction, string local)
		{
			this.direction = direction;
			this.local = local;
		}

		public string Direction   // property
		{
			get { return direction; }
			set { direction = value; }
		}

		public string Local   // property
		{
			get { return local; }
			set { local = value; }
		}
	}
}