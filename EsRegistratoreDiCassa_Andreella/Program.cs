using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EsRegistratoreDiCassa_Andreella
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            List<CCliente> clienti = new List<CCliente>();

            clienti.Add(new CCliente("Mario", "Rossi", true));
    
            CArticolo pane = new CArticoloAlimentare(123321, "Pane", 2, 2026);
            CArticolo latte = new CArticoloAlimentare(123322, "Latte", 3, 2025);
            
            CArticolo farina = new CArticoloAlimentare(123323, "Farina", 1, 2024);

            CArticolo quaderno = new CArticoloNonAlimentare(123324, "Quaderno", 5, Materiale.carta);
            CArticolo penna = new CArticoloNonAlimentare(123325, "Penna", 2, Materiale.plastica);

            clienti[0].AggiungiArticolo(pane);
            clienti[0].AggiungiArticolo(latte);
            clienti[0].AggiungiArticolo(farina);
            clienti[0].AggiungiArticolo(quaderno);
            clienti[0].AggiungiArticolo(penna);

            clienti[0].Sconta();

            Console.WriteLine("Scontrino per il cliente: " + clienti[0].Nome + " " + clienti[0].Cognome);
            
            string scontrino = "";
            int tot = 0;
            foreach (CArticolo articolo in clienti[0].Articoli)
            {
                scontrino += articolo.Codice + " - " + articolo.Descrizione + " - " + articolo.Prezzo + " euro\n";
                tot += articolo.Prezzo;
            }
            scontrino += "Totale: " + tot + " euro";
            Console.WriteLine(scontrino);

            foreach (CCliente cliente in clienti)
            {
                foreach (CArticolo articolo in cliente.Articoli)
                {
                    if (articolo.Codice == pane.Codice)
                    {
                        Console.WriteLine("Il cliente " + cliente.Nome + " " + cliente.Cognome + " ha diritto a uno sconto per avere comprato: " + articolo.Descrizione);
                    }
                }
            }
        }

    }
}
