using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SAE2._01
{
    public class Envoi_SMS
    {
        public Ami numAmi { get; set; }
        public Inscription numInscription { get; set; }

        private string portable_SMS;

        public string Portable_SMS
        {
            get { return portable_SMS; }
            set { portable_SMS = value; }
        }

        public Envoi_SMS(Ami numAmi, Inscription numInscription, string portable_SMS)
        {
            this.numAmi = numAmi;
            this.numInscription = numInscription;
            this.Portable_SMS = portable_SMS;
        }
    }
}
