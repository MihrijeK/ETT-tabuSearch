using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    public class Teacher
    {
		private string id { get; set; }
		private string name { get; set; }

		public Teacher() { }

		public Teacher(string id, string name)
		{
			this.id = id;
			this.name = name;
		}
	}
}
