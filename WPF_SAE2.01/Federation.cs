using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
                        codeFederation idFederation = (codeFederation)res["num_federation"];
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
        public static List<codeFederation> ReadIdFederation()
        {
            ObservableCollection<Federation> lesFederations = Read();
            List<codeFederation> idFederations = new List<codeFederation>();
            foreach (Federation uneDistance in lesFederations)
            {
                idFederations.Add(uneDistance.IdFederation);

            }
            return idFederations;
        }
        public static List<string> ReadNomFederation()
        {
            ObservableCollection<Federation> lesFederations = Read();
            List<string> nomFederations = new List<string>();
            foreach (Federation uneDistance in lesFederations)
            {
                nomFederations.Add(uneDistance.nomFederation);

            }
            return nomFederations;
        }
    }
}
