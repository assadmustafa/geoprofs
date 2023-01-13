using GeoProfs.Models;
using System;
using System.Linq;

namespace GeoProfs.Data
{
    public class DbInitializer
    {
        public static void Initialize(BedrijfContext context)
        {
            // Checks if the database exists
            context.Database.EnsureCreated();

            // Look for any werknemers.
            if (context.Werknemers.Any())
            {
                return;   // DB has been seeded
            }

            // Add Verloofaanvraag
            var verlofaanvragen = new Verlofaanvraag[]
            {
                new Verlofaanvraag{ID=1,werknemer_ID=1,begin_datum= DateTime.Parse("2023-01-01"),eind_datum= DateTime.Parse("2023-01-10"),beschrijving="Ik ga op vakantie.",verlof_reden=verlof_reden.vakantie}
            };
            foreach (Verlofaanvraag v in verlofaanvragen)
            {
                context.Verlofaanvraagen.Add(v);
            }
            context.SaveChanges();

            // Add Werknemer
            var werknemers = new Werknemer[]
            {
                new Werknemer { voornaam = "Assad", achternaam = "Mustafa", geboortedatum = DateTime.Parse("1995-01-01"), BSN = 667859, telefoonnummer = 0628085799, email = "assad@hotmail.com", wachtwoord = "1234", contract_uren = 720, uurloon = 18.85 }
            };
            foreach (Werknemer w in werknemers)
            {
                context.Werknemers.Add(w);
            }
            context.SaveChanges();

            // Add Functie
            var functies = new Functie[]
            {
                new Functie { ID=1,afdeling_ID=1,naam="Software-Developer" }
            };
            foreach (Functie f in functies)
            {
                context.Functies.Add(f);
            }
            context.SaveChanges();

            // Add Rapport
            var rapporten = new Rapport[]
            {
                new Rapport { ID=1,werknemer_ID=1,functie_ID=1,verlofaanvraag_ID=1,weeknummer=1,aanwezige_dagen=75.88,afwezige_dagen=7.2 }
            };
            foreach (Rapport r in rapporten)
            {
                context.Rapporten.Add(r);
            }
            context.SaveChanges();

            // Add Afdeling
            var afdelingen = new Afdeling[]
            {
                new Afdeling { ID=1,naam="ICT" }
            };
            foreach (Afdeling a in afdelingen)
            {
                context.Afdelingen.Add(a);
            }
            context.SaveChanges();
        }
    }
};