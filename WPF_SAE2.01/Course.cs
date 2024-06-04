using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Course
    {
		private int numCourse;

		public int NumCourse
		{
			get { return numCourse; }
			set { numCourse = value; }
		}

		private DateTime heureDepartCourse;

		public DateTime HeureDepartCourse
		{
			get { return heureDepartCourse; }
			set { heureDepartCourse = value; }
		}

		private double prixInscriptionCourse;

		public double PrixInscriptionCourse
		{
			get { return prixInscriptionCourse; }
			set {
				if (value < 0)
					prixInscriptionCourse = value;
				else
					throw new ArgumentException("erreur coureur prix");
			}
		}

        private Distance distance;

        public Distance Distance
        {
            get { return distance; }
            set { distance = value; }
        }


        public Course(int numCourse,/*Distance distance,*/ DateTime heureDepartCourse, double prixInscriptionCourse)
        {
            this.NumCourse = numCourse;
            //this.Distance = distance;
            this.HeureDepartCourse = heureDepartCourse;
            this.PrixInscriptionCourse = prixInscriptionCourse;
        }

        public static ObservableCollection<Course> Read()
        {
            ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
            string sql = "SELECT * FROM course;";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        Course nouveau = new Course(int.Parse(res["num_course"].ToString()), /*res["distance"].ToString(),*/ DateTime.Parse(res["heure_depart"].ToString()),double.Parse(res["prix_inscription"].ToString()));
                        lesCourses.Add(nouveau);
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

            return lesCourses;
        }
    }
}
