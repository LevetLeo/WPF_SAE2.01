using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Club
    {
		public enum CodeClub { C1 =0, C2 =1, C3=2,C4=3, C5=4 }
		private string nomClub;

		public string NomClub
		{
			get { return nomClub; }
			set { nomClub = value; }
		}

		private CodeClub codeCluB;

		public CodeClub CodeCluB
		{
			get { return codeCluB; }
			set 
			{				
				codeCluB = value; 
			}
		}

	}
}
