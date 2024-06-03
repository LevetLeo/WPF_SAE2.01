using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Agent
    {
		private int numAgent;

		public int NumAgent
		{
			get { return numAgent; }
			set { numAgent = value; }
		}

		private string loginAgent;

		public string LoginAgent
		{
			get { return loginAgent; }
			set { loginAgent = value; }
		}

		private string mdp_agent;

		public string MDP_Agent
		{
			get { return mdp_agent; }
			set { mdp_agent = value; }
		}


	}
}
