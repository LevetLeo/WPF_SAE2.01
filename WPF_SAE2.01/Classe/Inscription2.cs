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
        public int Create()
        {
            String sql = $"insert into Inscription2(numInscription,numCoureur,temps_Prevue) "
             + $" values ('{this.numInscription}','{this.numCoureur}',"
            + $"'{this.temps_Prevue}');";
            return DataAccess.Instance.SetData(sql);
        }
    }
}
