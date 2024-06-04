using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Federation
    {
		public enum codeFederation { FFA = 0, FFT = 1,FFG = 2,FFC = 3 }

		private codeFederation idFederation;

		public codeFederation IdFederation
		{
			get { return idFederation; }
			set 
			{ 
					idFederation = value; 
			}
		}

		private string nomFederation;

		public string NomFederation
		{
			get { return nomFederation; }
			set {
				
				nomFederation = value; }
		}

        public Federation(codeFederation idFederation, string nomFederation)
        {
            this.IdFederation = idFederation;
            this.NomFederation = nomFederation;
        }

        public Federation(codeFederation idFederation)
        {
            IdFederation = idFederation;
        }
    }
}
