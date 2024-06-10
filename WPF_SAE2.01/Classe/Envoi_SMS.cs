using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Envoi_SMS
    {
        public Ami numAmi { get; set; }
        public Inscription numInscription { get; set; }

        private int portable_SMS;

        public int Portable_SMS
        {
            get { return portable_SMS; }
            set { portable_SMS = value; }
        }

        public Envoi_SMS(Ami numAmi, Inscription numInscription, int portable_SMS)
        {
            this.numAmi = numAmi;
            this.numInscription = numInscription;
            this.Portable_SMS = portable_SMS;
        }
        public static ObservableCollection<Envoi_SMS> Read()
        {
            ObservableCollection<Envoi_SMS> lesEnvoi_SMS = new ObservableCollection<Envoi_SMS>();
            string sql = "SELECT * FROM schemasae201.envoi_sms";
            DataTable dt = DataAccess.Instance.GetData(sql);
            Console.WriteLine(dt);

            if (dt != null)
            {
                foreach (DataRow res in dt.Rows)
                {
                    try
                    {
                        Ami numAmi = (Ami)res["num_ami"];
                        Inscription numInscription = (Inscription)res["num_inscription"];
                        int portable_SMS = int.Parse(res["portable_SMS"].ToString());
                        Envoi_SMS nouveau = new Envoi_SMS(numAmi, numInscription, portable_SMS);
                        lesEnvoi_SMS.Add(nouveau);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error parsing DataRow: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("database non existante");
            }

            return lesEnvoi_SMS;
        }
    }
}
