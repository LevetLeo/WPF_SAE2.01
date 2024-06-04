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

        public Inscription(int numInscription, Course numCourse, DateTime date_Federation)
        {
            this.NumInscription = numInscription;
            this.numCourse = numCourse;
            this.Date_Federation = date_Federation;
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
                        DateTime date_Federation = Convert.ToDateTime(res["nom_federation"]);
                        Inscription nouveau = new Inscription(numInscription, numCourse, date_Federation);
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
                Console.WriteLine("DataTable is null. Check database connection and query.");
            }

            return lesInscriptions;
        }
        public static List<int> ReadnumInscription()
        {
            ObservableCollection<Inscription> lesInscriptions = Read();
            List<int> numsInscriptions = new List<int>();
            foreach (Inscription uneInscription in lesInscriptions)
            {
                numsInscriptions.Add(uneInscription.numInscription);

            }
            return numsInscriptions;
        }
        public static List<Course> ReadnumCourse()
        {
            ObservableCollection<Inscription> lesInscriptions = Read();
            List<Course> numsCourses = new List<Course>();
            foreach (Inscription uneInscription in lesInscriptions)
            {
                numsCourses.Add(uneInscription.numCourse);

            }
            return numsCourses;
        }
        public static List<DateTime> ReadDateFederation()
        {
            ObservableCollection<Inscription> lesInscriptions = Read();
            List<DateTime> DatesFederations = new List<DateTime>();
            foreach (Inscription uneInscription in lesInscriptions)
            {
                DatesFederations.Add(uneInscription.date_Federation);

            }
            return DatesFederations;
        }
    }
}
