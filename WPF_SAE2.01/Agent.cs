using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        public Agent(int numAgent, string loginAgent, string mdp_Agent)
        {
            NumAgent = numAgent;
            LoginAgent = loginAgent;
            MDP_Agent = mdp_Agent;
        }

        public static ObservableCollection<Agent> Read()
		{

            ObservableCollection<Agent> lesAgents = new ObservableCollection<Agent>();
            String sql = "SELECT num_agent,login_agent, mdp_agent FROM agent";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
				Agent nouveau = new Agent(int.Parse(res["numAgent"].ToString()),res["login_agent"].ToString(),res["mdp_agent"].ToString());
                
                lesAgents.Add(nouveau);
            }
            return lesAgents;
        }


    }
}
