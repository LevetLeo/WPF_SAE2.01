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
            this.NumAgent = numAgent;
            this.LoginAgent = loginAgent;
            this.MDP_Agent = mdp_Agent;
        }

        public static ObservableCollection<Agent> Read()
        {
            ObservableCollection<Agent> lesAgents = new ObservableCollection<Agent>();
            string sql = "SELECT num_agent, login_agent, mdp_agent FROM schemasae201.agent";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int numAgent = int.Parse(res["num_agent"].ToString());
                        string loginAgent = res["login_agent"].ToString();
                        string mdpAgent = res["mdp_agent"].ToString();
                        Agent nouveau = new Agent(numAgent, loginAgent, mdpAgent);
                        lesAgents.Add(nouveau);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error parsing DataRow: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("DataTable is null. Check database connection and query.");
            }

            return lesAgents;
        }
        public static List<string> ReadLogin()
        {
            ObservableCollection<Agent> LesAgents = Read();
            List<string> login =  new List<string>();
            foreach (Agent unAgent in LesAgents)
            {
                login.Add(unAgent.LoginAgent);
            }
            return login;
        }
        public static List<string> ReadMdp()
        {
            ObservableCollection<Agent> LesAgents = Read();
            List<string> Mdp = new List<string>();
            string mdpstr;
            foreach (Agent unAgent in LesAgents)
            {
                mdpstr = unAgent.LoginAgent;
                Mdp.Add(mdpstr);

            }
            return Mdp;
        }



    }
}
