using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    public class CRegistratore
    {
        public List<CScontrino> Scontrini { get; set; }
        public int Contatore { get; set; } = 0;

        public CRegistratore()
        {
            Scontrini = new List<CScontrino>();
        }

        public void EmettiScontrino(float imp, DateTime data)
        {
            CScontrino s = new CScontrino(imp, data);

            if (Scontrini.Count == 0 || Scontrini[Scontrini.Count - 1].Emissione.Date != data.Date)
            {
                Contatore = 1;
            }
            else
            {
                Contatore++;
            }

            s.Numero = Contatore;
            Scontrini.Add(s);
        }

        public void CancellaScontrino()
        {
            if (Scontrini.Count == 0)
            {
                return;
            }
            Scontrini[Scontrini.Count - 1] = null;
        }

        public string ListScontrini()
        {
            string stampa = "Scontrini emessi oggi:\n";
            foreach (var scontrino in Scontrini)
            {
                if (scontrino.Emissione == DateTime.Now.Date)
                {
                    stampa += $"Scontrino numero: {scontrino.Numero}, Ammontare: {scontrino.Ammontare}, Emissione: {scontrino.Emissione}\n";
                }
            }
            return stampa;
        }

        public string StampaSettimana(int settimana)
        {
            string stampa = $"Scontrini settimana {settimana}:\n";

            foreach (var scontrino in Scontrini)
            {
                int settimanaScontrino = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(scontrino.Emissione, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                if (settimanaScontrino == settimana)
                {
                    stampa += $"Scontrino numero: {scontrino.Numero}, Ammontare: {scontrino.Ammontare}, Emissione: {scontrino.Emissione}\n";
                }
            }

            return stampa;
        }

        public string StampaMese(int mese)
        {
            string stampa = $"Scontrini mese {mese}:\n";

            foreach (var scontrino in Scontrini)
            {
                if (scontrino.Emissione.Month == mese)
                {
                    stampa += $"Scontrino numero: {scontrino.Numero}, Ammontare: {scontrino.Ammontare}, Emissione: {scontrino.Emissione}\n";
                }
            }
            return stampa;
        }

    }
}
