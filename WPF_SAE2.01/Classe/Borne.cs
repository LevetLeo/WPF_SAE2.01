using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        public Borne(int numBorne)
        {
            this.NumBorne = numBorne;
        }

        public static ObservableCollection<Borne> Read()
        {
            ObservableCollection<Borne> lesBornes = new ObservableCollection<Borne>();
            string sql = "SELECT " +
                "* FROM schemasae201.borne";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int numBorne = int.Parse(res["num_borne"].ToString());
                        Borne nouveau = new Borne(numBorne);
                        lesBornes.Add(nouveau);

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

            return lesBornes;
        }
        public static List<int> ReadNumBorne()
        {
            ObservableCollection<Borne> LesBornes = Read();
            List<int> numBornes = new List<int>();
            foreach (Borne uneBorne in LesBornes)
            {
                numBornes.Add(uneBorne.numBorne);

            }
            return numBornes;
        }
    }
}
