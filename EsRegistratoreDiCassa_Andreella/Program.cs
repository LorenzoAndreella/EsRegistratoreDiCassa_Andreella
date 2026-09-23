using System;
using System.Collections.Generic;

namespace EsRegistratoreDiCassa_Andreella
{
    internal class Program
    {
        public static List<CCliente> clienti = new List<CCliente>();

        public static void Main(string[] args)
        {

            int aggiuntaCliente;
            do
            {
                Console.WriteLine("Quanti clienti vuoi aggiungere?");
            } while (!int.TryParse(Console.ReadLine(), out aggiuntaCliente) || aggiuntaCliente <= 0);

            for (int i = 0; i < aggiuntaCliente; i++)
            {
                clienti.Add(AggiungiCliente());
                Console.WriteLine("Cliente aggiunto: " + clienti[i].Nome + " " + clienti[i].Cognome);

                int numArticoli;
                do
                {
                    Console.WriteLine("Quanti articoli vuoi aggiungere?");
                } while (!int.TryParse(Console.ReadLine(), out numArticoli) || numArticoli <= 0);

                for (int j = 0; j < numArticoli; j++)
                {
                    CArticolo articolo = AggiungiArticolo();
                    clienti[i].AggiungiArticolo(articolo);
                    Console.WriteLine("Articolo aggiunto: " + articolo.Descrizione);
                }

                clienti[i].Sconta();

            }

            foreach (CCliente cliente in clienti)
            {
                Console.WriteLine("Cliente: " + cliente.Nome + " " + cliente.Cognome);
                Console.WriteLine("Articoli acquistati:");
                Console.WriteLine(StampaScontrino(cliente));

            }

            long codiceSconto;
            do
            {
                Console.WriteLine("Inserisci il codice dell'articolo per inviare gli sconti:");

            } while (!long.TryParse(Console.ReadLine(), out codiceSconto) || codiceSconto <= 0);

            Console.WriteLine(InvioSconti(codiceSconto));

        }

        public static CCliente AggiungiCliente()
        {
            string nome = "";
            do
            {
                Console.WriteLine("Inserisci nome cliente:");
                nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(nome));

            string cognome = "";
            do
            {
                Console.WriteLine("Inserisci cognome cliente:");
                cognome = Console.ReadLine();
            } while (string.IsNullOrEmpty(cognome));

            string cartaFedelta = "";
            do
            {
                Console.WriteLine("Hai la carta fedeltà? (si / no)");
                cartaFedelta = Console.ReadLine();
            } while (cartaFedelta != "si" && cartaFedelta != "no");
            bool carta = false;
            if (cartaFedelta == "si")
            {
                carta = true;
            }
            CCliente cliente = new CCliente(nome, cognome, carta);
            return cliente;
        }

        public static CArticolo AggiungiArticolo()
        {
            CArticolo articolo = null;

            int scelta;
            do
            {
                Console.WriteLine("Prodotto da aggiungere: 1.Alimentare 2.Non Alimentare");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 2);

            long codice;
            do
            {
                Console.WriteLine("Inserisci codice articolo:");
            } while (!long.TryParse(Console.ReadLine(), out codice) || codice <= 0);

            string desc;
            do
            {
                Console.WriteLine("Inserisci descrizione articolo:");
                desc = Console.ReadLine();
            } while (string.IsNullOrEmpty(desc));

            int prezzo;
            do
            {
                Console.WriteLine("Inserisci prezzo articolo:");
            } while (!int.TryParse(Console.ReadLine(), out prezzo) || prezzo <= 0);

            switch (scelta)
            {
                case 1:
                    int annoScadenza;
                    do
                    {
                        Console.WriteLine("Inserisci anno di scadenza:");
                    } while (!int.TryParse(Console.ReadLine(), out annoScadenza) || annoScadenza < DateTime.Now.Year || annoScadenza > 2050);
                    articolo = new CArticoloAlimentare(codice, desc, prezzo, annoScadenza);
                    break;
                case 2:
                    string tipoMateriale;
                    do
                    {
                        Console.WriteLine("Inserisci tipo di materiale:");
                        tipoMateriale = Console.ReadLine();
                    } while (string.IsNullOrEmpty(tipoMateriale));
                    articolo = new CArticoloNonAlimentare(codice, desc, prezzo, tipoMateriale);
                    break;
            }
            return articolo;
        }

        public static string StampaScontrino(CCliente cliente)
        {
            string scontrino = "";
            int tot = 0;
            foreach (CArticolo articolo in cliente.Articoli)
            {
                scontrino += articolo.Codice + " - " + articolo.Descrizione + " - " + articolo.Prezzo + " euro\n";
                tot += articolo.Prezzo;
            }
            scontrino += "Totale: " + tot + " euro";
            return scontrino;
        }

        public static string InvioSconti(long codice)
        {
            string sconti = "";
            foreach (CCliente cliente in clienti)
            {
                foreach (CArticolo articolo in cliente.Articoli)
                {
                    if (articolo.Codice == codice)
                    {
                        sconti += "\n" + "Il cliente " + cliente.Nome + " " + cliente.Cognome + " ha diritto ad uno sconto per avere comprato: " + articolo.Descrizione;
                    }
                }
            }
            return sconti;
        }

    }
}
