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

        private string nomCourse;

        public string NomCourse
        {
            get { return nomCourse; }
            set { nomCourse = value; }
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

        private double distance;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }


        public Course(int numCourse,double distance,string nomCourse, DateTime heureDepartCourse, double prixInscriptionCourse)
        {
            this.NumCourse = numCourse;
            this.Distance = distance;
            this.NomCourse = nomCourse;
            this.HeureDepartCourse = heureDepartCourse;
            this.PrixInscriptionCourse = prixInscriptionCourse;
        }

        public static ObservableCollection<Course> Read()
        {
            ObservableCollection<Course> lesCourses = new ObservableCollection<Course>();
            string sql = "SELECT * FROM course;";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            
            foreach (DataRow res in dt.Rows)
            {
                try
                {
                    Course nouveau = new Course(int.Parse(res["num_course"].ToString()), double.Parse(res["distance"].ToString()),res["nom_Course"].ToString(), DateTime.Parse(res["heure_depart"].ToString()),double.Parse(res["prix_inscription"].ToString()));
                    lesCourses.Add(nouveau);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                
            }
            return lesCourses;
        }
        public static List<double> ReadDistance()
        {
            ObservableCollection<Course> LesCourses = Read();
            List<double> distanceCourse = new List<double>();

            foreach(Course uneCourse in LesCourses)
            {
                distanceCourse.Add(uneCourse.Distance);
            }
            return distanceCourse;
        }
        public static List<DateTime> ReadHeureDepart()
        {
            ObservableCollection<Course> LesCourses = Read();
            List<DateTime> HeureDepartCourseList = new List<DateTime>();

            foreach (Course uneCourse in LesCourses)
            {
                HeureDepartCourseList.Add(uneCourse.HeureDepartCourse);
            }
            return HeureDepartCourseList;
        }
        public static List<double> ReadPrix()
        {
            ObservableCollection<Course> LesCourses = Read();
            List<double> PrixCourse = new List<double>();

            foreach (Course uneCourse in LesCourses)
            {
                PrixCourse.Add(uneCourse.PrixInscriptionCourse);
            }
            return PrixCourse;
        }
        public static List<string> ReadNom()
        {
            ObservableCollection<Course> LesCourses = Read();
            List<string> NomCourseList = new List<string>();

            foreach (Course uneCourse in LesCourses)
            {
                NomCourseList.Add(uneCourse.NomCourse);
            }
            return NomCourseList;
        }
    }
}
