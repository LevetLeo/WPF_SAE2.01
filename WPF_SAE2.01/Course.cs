using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Course
    {
		private int numCourse;

		public int NumCourse
		{
			get { return numCourse; }
			set { numCourse = value; }
		}

		private DateTime heureDepartCourse;

		public DateTime HeureDepartCourse
		{
			get { return heureDepartCourse; }
			set { heureDepartCourse = value; }
		}

		private double prixInscriptionCourse;

		public double PrixInscriptionCourse
		{
			get { return prixInscriptionCourse; }
			set {
				if (value < 0)
					prixInscriptionCourse = value;
				else
					throw new ArgumentException("erreur coureur prix");
			}
		}



	}
}
