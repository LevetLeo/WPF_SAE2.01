using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using static WPF_SAE2._01.Club;

namespace WPF_SAE2._01
{
    public class Federation
    {
		public enum codeFederation { FFA , FFC ,FFG , FFT }

		private int idFederation;

		public int IdFederation
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

        private string codefede;

        public string Codefede
        {
            get { return codefede; }
            set { codefede = value; }
        }



        public Federation(int idFederation, string nomFederation)
        {
            this.IdFederation = idFederation;
            this.NomFederation = nomFederation;
            this.Codefede = Enum.GetNames(typeof(codeFederation))[idFederation];

        }

        public static codeFederation ConvertionStringFederation(string chaine)
        {
            bool success = Enum.TryParse(chaine, out codeFederation fede);
            if (success)
            {
                Console.WriteLine(fede.ToString());
            }
            else
            {
                Console.WriteLine("Couldn't convert");
            }
            return fede;
        }

        public static ObservableCollection<Federation> Read()
        {
            ObservableCollection<Federation> lesFederations = new ObservableCollection<Federation>();
            string sql = "SELECT * FROM schemasae201.federation";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int idFederation = (int)res["num_federation"];
                        string nomFederation = res["nom_federation"].ToString();

                        Federation nouveau = new Federation(idFederation, nomFederation);
                        lesFederations.Add(nouveau);

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

            return lesFederations;
        }
    }
}
