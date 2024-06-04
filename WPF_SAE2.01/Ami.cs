using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Ami
    {
		private int numAmi;

		public int NumAmi
		{
			get { return numAmi; }
			set { numAmi = value; }
		}

        public Ami(int numAmi)
        {
            this.NumAmi = numAmi;
        }
    }
}
