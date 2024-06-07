using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

        private string licenceCoureur;

        public string LicenceCoureur
        {
            get { return licenceCoureur; }
            set { licenceCoureur = value; }
        }

        private string lienPhotoCoureur;

        public string LienPhotoCoureur
        {
            get { return lienPhotoCoureur; }
            set { lienPhotoCoureur = value; }
        }


        public Club.CodeClub CodeClub { get; set; }
        public Federation.codeFederation Federation { get; set; }

        

        public CoureurClasse(int idCoureur)
        {
            this.IdCoureur = idCoureur;
        }
        public CoureurClasse(string nomCoureur, string prenomCoureur, string villeCoureur, char sexeCoureur, string licenceCoureur, Club.CodeClub codeClub, Federation.codeFederation federation)
        {
            this.NomCoureur = nomCoureur;
            this.PrenomCoureur = prenomCoureur;
            this.VilleCoureur = villeCoureur;
            this.SexeCoureur = sexeCoureur;
            this.LicenceCoureur = licenceCoureur;
            this.CodeClub = codeClub;
            this.Federation = federation;
        }

        public CoureurClasse(string nomCoureur, string prenomCoureur, string villeCoureur, char sexeCoureur, string licenceCoureur, Club.CodeClub codeClub, Federation.codeFederation federation, string portableCoureur, string lienPhotoCoureur) : this (nomCoureur,prenomCoureur,villeCoureur,sexeCoureur,licenceCoureur,codeClub,federation) 
        {
            this.PortableCoureur = portableCoureur;
            this.LienPhotoCoureur = lienPhotoCoureur;
        }


        public static ObservableCollection<CoureurClasse> Read()
        {
            ObservableCollection<CoureurClasse> lesCoureurs = new ObservableCollection<CoureurClasse>();
            string sql = "SELECT * FROM schemasae201.coureur";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        string numCoureur = res["num_coureur"].ToString();

                        Club.CodeClub codeClub = Club.ConvertionStringClub(res["code_club"].ToString());
                        Federation.codeFederation fede = (Federation.codeFederation)res["num_federation"];

                        string nomCoureur = res["nom_coureur"].ToString();
                        string lienPhoto = res["lien_photo"].ToString();
                        string prenomCoureur = res["prenom_coureur"].ToString();
                        string villeCoureur = res["ville_coureur"].ToString();
                        string lienPhotoCoureur = res["lien_photo"].ToString();
                        string portable = res["potable"].ToString();
                        Char sexe = Convert.ToChar(res["sexe"]);
                        string numLicence = res["num_licence"].ToString();

                        CoureurClasse nouveau = new CoureurClasse(nomCoureur, prenomCoureur, villeCoureur, sexe, numLicence, codeClub, fede, portable, lienPhotoCoureur);
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
        public int Create()
        {
            String sql = $"insert into Coureur(ClubCoureur,FederationCoureur ,nomCoureur,lienPhoto prenomCoureur,villeCoureur,potable,sexeCoureur, LicenceCoureur) "
             +$" values ('{this.CodeClub}','{this.Federation}',"
            +$"'{this.NomCoureur}','{this.PrenomCoureur}','{this.villeCoureur}'"
            + $"'{this.portableCoureur}','{this.SexeCoureur}',{this.LicenceCoureur}'"
            + $");";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update into Coureur(ClubCoureur,FederationCoureur ,nomCoureur,lienPhoto prenomCoureur,villeCoureur,potable,sexeCoureur, LicenceCoureur) "
             + $" values ('{this.CodeClub}','{this.Federation}',"
            + $"'{this.NomCoureur}','{this.PrenomCoureur}','{this.villeCoureur}'"
            + $"'{this.portableCoureur}','{this.SexeCoureur}',{this.LicenceCoureur}'"
            + $");";
            return DataAccess.Instance.SetData(sql);
        }
    }
}
