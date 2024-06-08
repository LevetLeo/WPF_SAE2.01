using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        public static ObservableCollection<Ami> Read()
        {
            ObservableCollection<Ami> lesAmis = new ObservableCollection<Ami>();
            string sql = "SELECT " +
                "num_ami FROM schemasae201.ami";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int numAmi = int.Parse(res["num_ami"].ToString());
                        Ami nouveau = new Ami (numAmi);
                        lesAmis.Add(nouveau);

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

            return lesAmis;
        }
    }
}
