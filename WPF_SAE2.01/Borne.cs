using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Borne
    {
		private int numBorne;

		public int NumBorne
		{
			get { return numBorne; }
			set {
				if (value >= 1 && value <= 5)
					numBorne = value;
				else
					throw new ArgumentException("borne erreur");
			}
		}


	}
}
