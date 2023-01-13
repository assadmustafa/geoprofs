namespace GeoProfs.Models
{
    public class Rapport
    {
        public int ID { get; set; }
        public int werknemer_ID { get; set; }
        public int functie_ID { get; set; }
        public int verlofaanvraag_ID { get; set; }
        public int weeknummer { get; set; }
        public double aanwezige_dagen { get; set; }
        public double afwezige_dagen { get; set; }
        public Werknemer Werknemer { get; set; }
        public Functie Functie { get; set; }
        public Verlofaanvraag Verlofaanvraag { get; set; }
    }
}
