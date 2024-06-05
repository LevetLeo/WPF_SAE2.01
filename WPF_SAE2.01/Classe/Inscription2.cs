using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Inscription2
    {
		public Inscription numInscription { get; set; }

        public CoureurClasse numCoureur { get; set; }

		private DateTime temps_Prevue;

		public DateTime Temps_Prevue
		{
			get { return temps_Prevue; }
			set {
				DateTime dt = (new DateTime(00, 00, 00, 00, 00, 00));

				if (value > dt)
					temps_Prevue = value;
				else
					throw new ArgumentException("erreur Inscription2");
			}
		}

        public Inscription2(Inscription numInscription, CoureurClasse numCoureur, DateTime temps_Prevue)
        {
            this.numInscription = numInscription;
            this.numCoureur = numCoureur;
            this.Temps_Prevue = temps_Prevue;
        }
        public static ObservableCollection<Inscription2> Read()
        {
            ObservableCollection<Inscription2> lesInscriptions2 = new ObservableCollection<Inscription2>();
            string sql = "SELECT * FROM schemasae201.inscription2";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        Inscription numInscription = (Inscription)res["num_federation"];
                        CoureurClasse numCoureur = (CoureurClasse)res["num_coureur"];
                        DateTime tempsPrevu = Convert.ToDateTime(res["temps_prevu"]);
                        Inscription2 nouveau = new Inscription2(numInscription, numCoureur, tempsPrevu);
                        lesInscriptions2.Add(nouveau);

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

            return lesInscriptions2;
        }
        public static List<Inscription> ReadnumInscription()
        {
            ObservableCollection<Inscription2> lesInscriptions2 = Read();
            List<Inscription> numsInscriptions2 = new List<Inscription>();
            foreach (Inscription2 uneInscription2 in lesInscriptions2)
            {
                numsInscriptions2.Add(uneInscription2.numInscription);

            }
            return numsInscriptions2;
        }
    
        public static List<CoureurClasse> ReadnumCoureur()
        {
          ObservableCollection<Inscription2> lesInscriptions2 = Read();
          List<CoureurClasse> numsCoureurs = new List<CoureurClasse>();
           foreach (Inscription2 uneInscription2 in lesInscriptions2)
           {
               numsCoureurs.Add(uneInscription2.numCoureur);
    
           }
            return numsCoureurs;
        }
        public static List<DateTime> ReadTempsPrevu()
        {
            ObservableCollection<Inscription2> lesInscriptions2 = Read();
            List<DateTime> TempsPrevus = new List<DateTime>();
            foreach (Inscription2 uneInscription2 in lesInscriptions2)
            {
                TempsPrevus.Add(uneInscription2.temps_Prevue);

            }
            return TempsPrevus;
        }
    }
}
