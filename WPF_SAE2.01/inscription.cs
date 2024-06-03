using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Inscription
    {
		private int numInscription;

		public int NumInscription
		{
			get { return numInscription; }
			set { numInscription = value; }
		}

		public Course numCourse { get; set; }

		private DateTime date_Federation;

		public DateTime Date_Federation
		{
			get { return date_Federation; }
			set { date_Federation = value; }
		}



	}
}
