using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Inscription2
    {
		public Inscription numInscription { get; set; }

        public Coureur numCoureur { get; set; }

		private DateTime temps_Prevue;

		public DateTime Temps_Prevue
		{
			get { return temps_Prevue; }
			set {
				DateTime dt = (new DateTime(00, 00, 00, 00, 00, 00));

				if (value > dt)
					temps_Prevue = value;
				else
					throw new ArgumentException("erreur Inscription2");
			}
		}





	}
}
