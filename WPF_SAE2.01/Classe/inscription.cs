using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WPF_SAE2._01.Federation;

namespace WPF_SAE2._01
{
    public class Inscription
    {
		private int numInscription;

		public int NumInscription
		{
			get { return numInscription; }
			set { numInscription = value; }
		}

		public Course numCourse { get; set; }

		private DateTime date_Federation;

		public DateTime Date_Federation
		{
			get { return date_Federation; }
			set { date_Federation = value; }
		}
        private CoureurClasse idCoureur;

        public CoureurClasse IdCoureur
        {
            get { return idCoureur; }
            set { idCoureur = value; }
        }


        public Inscription(int numInscription, Course numCourse, DateTime date_Federation, CoureurClasse idCoureur)
        {
            this.NumInscription = numInscription;
            this.numCourse = numCourse;
            this.Date_Federation = date_Federation;
            this.IdCoureur = idCoureur;
        }
        public static ObservableCollection<Inscription> Read()
        {
            ObservableCollection<Inscription> lesInscriptions = new ObservableCollection<Inscription>();
            string sql = "SELECT * FROM schemasae201.inscription";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int numInscription = int.Parse(res["num_federation"].ToString());
                        Course numCourse = (Course)res["nom_federation"];
                        DateTime date_Federation = Convert.ToDateTime(res["date_inscription"]);
                        CoureurClasse numCoureur = (CoureurClasse)(res["numCoureur"]);
                        Inscription nouveau = new Inscription(numInscription, numCourse, date_Federation,numCoureur);
                        lesInscriptions.Add(nouveau);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error parsing DataRow: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("database non existante");
            }

            return lesInscriptions;
        }

        public int Create()
        {
            String sql = $"insert into Inscription(numInscription,numCourse,date_Federation,idCoureur) "
             + $" values ('{this.numInscription}','{this.numCourse}',"
            + $"'{this.date_Federation}','{this.idCoureur}');";
            return DataAccess.Instance.SetData(sql);
        }

    }
}
