using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Distance
    {
        public Course NumCourse { get; set; }

		public Borne NumBorne { get; set; }

		private int nb_Km;

		public int Nb_Km
		{
			get { return nb_Km; }
			set 
			{
				if (value < 0)
					throw new ArgumentException("erreur Distance");
				nb_Km = value; 
			}
		}

	}
}
