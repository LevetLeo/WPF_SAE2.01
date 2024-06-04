using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Distance
    {
        public Course NumCourse { get; set; }

		public Borne NumBorne { get; set; }

		private int nb_Km;

		public int Nb_Km
		{
			get { return nb_Km; }
			set 
			{
				if (value < 0)
					throw new ArgumentException("erreur Distance");
				nb_Km = value; 
			}
		}

        public Distance(Course numCourse, Borne numBorne, int nb_Km)
        {
            this.NumCourse = numCourse;
            this.NumBorne = numBorne;
            this.Nb_Km = nb_Km;
        }
        public static ObservableCollection<Distance> Read()
        {
            ObservableCollection<Distance> lesDistances = new ObservableCollection<Distance>();
            string sql = "SELECT * FROM schemasae201.ami";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        Course numCourse = (Course)res["num_course"];
                        Borne numBorne = (Borne)res["num_borne"];
                        int nb_Km = int.Parse(res["nb_km"].ToString());
                        Distance nouveau = new Distance(numCourse, numBorne, nb_Km);
                        lesDistances.Add(nouveau);

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

            return lesDistances;
        }
        public static List<Course> ReadNumCourse()
        {
            ObservableCollection<Distance> lesDistances = Read();
            List<Course> numCourses = new List<Course>();
            foreach (Distance uneDistance in lesDistances)
            {
                numCourses.Add(uneDistance.NumCourse);

            }
            return numCourses;
        }
        public static List<Borne> ReadNumBorne()
        {
            ObservableCollection<Distance> lesDistances = Read();
            List<Borne> numBornes = new List<Borne>();
            foreach (Distance uneDistance in lesDistances)
            {
                numBornes.Add(uneDistance.NumBorne);

            }
            return numBornes;
        }
        public static List<int> ReadNb_Km()
        {
            ObservableCollection<Distance> lesDistances = Read();
            List<int> nbs_Kms = new List<int>();
            foreach (Distance uneDistance in lesDistances)
            {
                nbs_Kms.Add(uneDistance.nb_Km);

            }
            return nbs_Kms;
        }
    }
}
