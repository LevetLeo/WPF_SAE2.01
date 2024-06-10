using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_SAE2._01
{
    public class DataAccess
    {
        private static DataAccess instance;
        
        /*public static string strConnexion = "Server=srv-peda-new;" +
                            "port=5433;" +
                            "Database=SAE201Marathon;" +
                            "Search Path =SchemaSAE201;" +
                            "uid=guzmanma;" +
                            "password=VnZlZ5;";
        */
        

        public DataAccess()
        {


        }
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }

        public void ConnexionBD(string strConnexion)
        {
            
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
                Console.WriteLine("connexion : ");
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox 
            }
            Connexion = new NpgsqlConnection();
            Connexion.ConnectionString = strConnexion;
            Connexion.Open();
            Console.WriteLine("connexion : ");
        }

        
        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
                Console.WriteLine("déconnexion : ");
            }
            catch (Exception e)
            { 
                Console.WriteLine("pb à la déconnexion : " + e); 
            }
            
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }
        public int SetData(string setSQL)
        {

            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
        public ObservableCollection<CoureurClasse> DataGridCoureur()
        {
            ObservableCollection<CoureurClasse>  lesCoureurs  = CoureurClasse.Read();
            return lesCoureurs;
        }
    }
}