using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        public Club(string nomClub, CodeClub codeCluB)
        {
            this.NomClub = nomClub;
            this.CodeCluB = codeCluB;
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
                        CodeClub CodeCluB = (CodeClub)res["code_club"];
                        string nomClub = res["nom_club"].ToString();
                        Club nouveau = new Club(nomClub, CodeCluB);
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
        public static List<string> ReadNomClub()
        {
            ObservableCollection<Club> LesClubs = Read();
            List<string> nomClubs = new List<string>();
            foreach (Club unClub in LesClubs)
            {
                nomClubs.Add(unClub.nomClub);

            }
            return nomClubs;
        }
        public static List<CodeClub> ReadCodeClub()
        {
            ObservableCollection<Club> LesClubs = Read();
            List<CodeClub> CodeClubs = new List<CodeClub>();
            foreach (Club unClub in LesClubs)
            {
                CodeClubs.Add(unClub.CodeCluB);

            }
            return CodeClubs;
        }
    }
}
