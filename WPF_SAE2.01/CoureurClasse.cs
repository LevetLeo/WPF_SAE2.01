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

		private int portableCoureur;

		public int PortableCoureur
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

        public CoureurClasse(int idCoureur, string nomCoureur, string prenomCoureur, string villeCoureur, int portableCoureur, char sexeCoureur, int licenceCoureur, Club codeClub, Federation idFederation)
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
        public static ObservableCollection<CoureurClasse> Read()
        {
            ObservableCollection<CoureurClasse> lesCoureurs = new ObservableCollection<CoureurClasse>();
            string sql = "SELECT num_coureur, code_club, num_federation, nom_coureur, lien_photo, prenom_coureur, ville_coureur, potable, sexe, num_license FROM schemasae201.course";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        int numCoureur = int.Parse(res["num_coureur"].ToString());
                        Club codeClub = (Club)res["code_club"];
                        Federation numFederation = (Federation)res["num_federation"];
                        string nomCoureur = res["nom_coureur"].ToString();
                        string lienPhoto = res["lien_photo"].ToString();
                        string prenomCoureur = res["prenom_coureur"].ToString();
                        string villeCoureur = res["ville_coureur"].ToString();
                        int portable = int.Parse(res["potable"].ToString());
                        Char sexe = Convert.ToChar(res["sexe"]);
                        int numLicence = int.Parse(res["num_licence"].ToString());
                        CoureurClasse nouveau = new CoureurClasse(numCoureur, nomCoureur, prenomCoureur, villeCoureur, portable, sexe, numLicence,codeClub, numFederation);
                        lesCoureurs.Add(nouveau);

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

            return lesCoureurs;
        }
        public static List<int> ReadIdCoureur()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<int> idCoureurs = new List<int>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                idCoureurs.Add(unCoureur.idCoureur);
            }
            return idCoureurs;
        }
        public static List<string> ReadNomCoureur()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<string> nomCoureurs = new List<string>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                nomCoureurs.Add(unCoureur.nomCoureur);

            }
            return nomCoureurs;
        }
        public static List<string> ReadPrenomCoureur()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<string> prenomCoureurs = new List<string>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                prenomCoureurs.Add(unCoureur.prenomCoureur);

            }
            return prenomCoureurs;
        }
        public static List<string> ReadVilleCoureur()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<string> villeCoureurs = new List<string>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                villeCoureurs.Add(unCoureur.nomCoureur);

            }
            return villeCoureurs;
        }
        public static List<int> ReadPortable()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<int> portableCoureurs = new List<int>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                portableCoureurs.Add(unCoureur.portableCoureur);

            }
            return portableCoureurs;
        }
        public static List<char> ReadSexe()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<char> sexeCoureurs = new List<char>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                sexeCoureurs.Add(unCoureur.sexeCoureur);

            }
            return sexeCoureurs;
        }
        public static List<int> ReadLicenseCoureur()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<int> licenceCoureurs = new List<int>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                licenceCoureurs.Add(unCoureur.licenceCoureur);

            }
            return licenceCoureurs;
        }
        public static List<Club> ReadCodeClub()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<Club> CodesClubs = new List<Club>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                CodesClubs.Add(unCoureur.CodeClub);

            }
            return CodesClubs;
        }
        public static List<Federation> ReadIdFederation()
        {
            ObservableCollection<CoureurClasse> LesCoureurs = Read();
            List<Federation> IdFederations = new List<Federation>();
            foreach (CoureurClasse unCoureur in LesCoureurs)
            {
                IdFederations.Add(unCoureur.IdFederation);

            }
            return IdFederations;
        }
    }
}
