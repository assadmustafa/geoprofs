using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace GeoProfs.Models
{
    public class Werknemer
    {
        public int ID { get; set; }
        public int functie_ID { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime geboortedatum { get; set; }
        public int BSN { get; set; }
        public int telefoonnummer { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public int contract_uren { get; set; }
        public double uurloon { get; set; }
        public ICollection<Verlofaanvraag> Verlofs { get; set; }
    }
}
