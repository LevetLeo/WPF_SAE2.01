using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static WPF_SAE2._01.Club;

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
			set { if (value is null) throw new ArgumentNullException("la valeur ne doit pas être null");
				nomCoureur = value; }
		}

		private string prenomCoureur;

		public string PrenomCoureur
		{
			get { return prenomCoureur; }
			set { if (value is null) throw new ArgumentNullException("la valeur ne doit pas être null"); prenomCoureur = value; }
		}

		private string villeCoureur;

		public string VilleCoureur
		{
			get { return villeCoureur; }
			set { if (value is null) throw new ArgumentNullException("la valeur ne doit pas être null"); villeCoureur = value; }
		}

		private string portableCoureur;

		public string PortableCoureur
		{
			get { return portableCoureur; }
			set { if (value is null) throw new ArgumentNullException("la valeur ne doit pas être null"); portableCoureur = value; }
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

        public CoureurClasse(int idCoureur, string nomCoureur, string prenomCoureur, string villeCoureur, string portableCoureur, char sexeCoureur, int licenceCoureur, Club codeClub, Federation idFederation)
        {
            this.IdCoureur = idCoureur;
			this.NomCoureur = nomCoureur;
            this.PrenomCoureur = prenomCoureur;
            this.VilleCoureur = villeCoureur;
            this.PortableCoureur = portableCoureur;
            this.SexeCoureur = sexeCoureur;
            this.LicenceCoureur = licenceCoureur;
            this.CodeClub = codeClub;
            this.IdFederation = idFederation;
        }
        
    }
}
