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

            public CoureurClasse(int idCoureur, string nomCoureur, string prenomCoureur, string villeCoureur, char sexeCoureur, int licenceCoureur, Club codeClub, Federation idFederation)
            {
                this.IdCoureur = idCoureur;
                this.NomCoureur = nomCoureur;
                this.PrenomCoureur = prenomCoureur;
                this.VilleCoureur = villeCoureur;
                this.SexeCoureur = sexeCoureur;
                this.LicenceCoureur = licenceCoureur;
                this.CodeClub = codeClub;
                this.IdFederation = idFederation;
            }

            public CoureurClasse(string nomCoureur, string prenomCoureur, string villeCoureur, int portableCoureur, char sexeCoureur, int licenceCoureur, Club codeClub, Federation idFederation)
        {
            NomCoureur = nomCoureur;
            PrenomCoureur = prenomCoureur;
            VilleCoureur = villeCoureur;
            PortableCoureur = portableCoureur;
            SexeCoureur = sexeCoureur;
            LicenceCoureur = licenceCoureur;
            CodeClub = codeClub;
            IdFederation = idFederation;
        }
        public CoureurClasse(string nomCoureur, string prenomCoureur, string villeCoureur, char sexeCoureur, int licenceCoureur, Club codeClub, Federation idFederation)
        {
            NomCoureur = nomCoureur;
            PrenomCoureur = prenomCoureur;
            VilleCoureur = villeCoureur;
            
            SexeCoureur = sexeCoureur;
            LicenceCoureur = licenceCoureur;
            CodeClub = codeClub;
            IdFederation = idFederation;
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
        /*public int Create(Coureur c)
        {
            String sql = $"insert into client (nom,prenom,email,genre,telephone, dateNaissance)"
            + $" values ('{c.Nom}','{c.Prenom}','{c.Email}'"
            + $",'{(char)c.Genre}','{c.Telephone}', "
            + $"'{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}'); ";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Connexion);
                nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }*/
    }
}
