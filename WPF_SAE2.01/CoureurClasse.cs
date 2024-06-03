using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_SAE2._01
{
    public class CoureurClasse
    {
		private int idCoureur;

		public int IdCoureur
		{
			get { return idCoureur; }
			set { idCoureur = value; }
		}

		private string nomCoureur;

		public string NomCoureur
		{
			get { return nomCoureur; }
			set { nomCoureur = value; }
		}

		private string prenomCoureur;

		public string PrenomCoureur
		{
			get { return prenomCoureur; }
			set { prenomCoureur = value; }
		}

		private string villeCoureur;

		public string VilleCoureur
		{
			get { return villeCoureur; }
			set { villeCoureur = value; }
		}

		private string portableCoureur;

		public string PortableCoureur
		{
			get { return portableCoureur; }
			set { portableCoureur = value; }
		}

		private char sexeCoureur;

		public char SexeCoureur
		{
			get { return sexeCoureur; }
			set {
				if (value is 'H' || value is 'F')
					sexeCoureur = value;
				else
					throw new ArgumentException("erreur Coureur");
			}
		}

		private int licenceCoureur;

		public int LicenceCoureur
		{
			get { return licenceCoureur; }
			set { licenceCoureur = value; }
		}

        public Club CodeClub { get; set; }
		public Federation IdFederation { get; set; }


	}
}
