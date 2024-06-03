

using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SAE2._01;

namespace WPF_SAE2._01
{

    public class ApplicationData
    {

        private ObservableCollection<Coureur> lesCoureurs;
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        

        public ObservableCollection<Coureur> LesCoureurs
        {
            get
            {
                return this.LesCoureurs;
            }

            set
            {
                this.LesCoureurs = value;
            }
        }

        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }



        public ApplicationData()
        {

            this.ConnexionBD();
            this.Read();

        }
        public void ConnexionBD()
        {
            Connexion = new NpgsqlConnection();
            Connexion.ConnectionString = "Server=srv-peda-new;" +
                            "port=5433;" +
                            "Database=sae2.01;" +
                            "Search Path = sae2.01Marathon;" +
                            "uid=guzmanma;" +
                            "password=VnZlZ5;";
        }
        public void Read()
        {
            this.LesCoureurs = new ObservableCollection<Coureur>();
        }

    }

}
