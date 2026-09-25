using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public class CScontrino
    {
        public float Ammontare { get; set; }
        public DateTime Emissione { get; set; }
        public int Numero { get; set; }

        public CScontrino(float ammontare, DateTime emissione)
        {
            Ammontare = ammontare;
            Emissione = emissione;
            Numero = 0;
        }

        public string Stampa()
        {
            return $"Scontrino numero: {Numero}, Ammontare: {Ammontare}, Emissione: {Emissione}";
        }
    }
}
