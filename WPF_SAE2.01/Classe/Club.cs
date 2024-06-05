using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
                /*
                if (value == "C1" || value == "C2" || value == "C3" || value == "C4" || value == "C5")
                {
                    codeCluB = value;
                }
                else
                    throw new ArgumentException("erreur codeclub");
                */
            }
        }
		

        public Club(string nomClub, CodeClub codeCluB)
        {
            this.NomClub = nomClub;
            this.CodeCluB = codeCluB;
        }

        public Club(CodeClub codeCluB)
        {
            CodeCluB = codeCluB;
        }

        public static CodeClub ConvertionStringClub(string chaine)
        {
            bool success = Enum.TryParse(chaine, out CodeClub Codecb);
            if (success)
            {
                Console.WriteLine(Codecb.ToString());
            }
            else
            {
                Console.WriteLine("Couldn't convert");
            }
            return Codecb;
        }

        public static ObservableCollection<Club> Read()
        {
            ObservableCollection<Club> lesClubs = new ObservableCollection<Club>();
            string sql = "SELECT * FROM schemasae201.club";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        

                        string nomClub = res["nom_club"].ToString();
                        Club nouveau = new Club(nomClub, ConvertionStringClub(res["code_club"].ToString()));
                        lesClubs.Add(nouveau);

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

            return lesClubs;
        }
        
    }
}
