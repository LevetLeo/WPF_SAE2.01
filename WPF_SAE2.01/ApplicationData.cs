

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



        private ObservableCollection<CoureurClasse> lesCoureurs;
        private NpgsqlConnection connexion = null;   // futur lien à la BD


        public ObservableCollection<CoureurClasse> LesCoureurs
        {
            get
            {
                return this.lesCoureurs;
            }

            set
            {
                this.lesCoureurs = value;
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
            this.LesCoureurs = CoureurClasse.Read();

        }



        public void ConnexionBD()
        {
            //data.ConnexionBD();
        }
       
        public void Read()
        {
            this.LesCoureurs = new ObservableCollection<CoureurClasse>();
        }

    }
}
