using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GeoProfs.Models
{
    [Flags]
    public enum verlof_reden
    {
        ziek = 0,
        persoonlijk = 1, 
        vakantie = 2, 
        anders = 3
    }

    public enum status
    {
        goedgekeurd = 0,
        afgekeurd = 1,
        processing = 2
    }
    public class Verlofaanvraag
    {
        public int ID { get; set; }
        [Display(Name = "Werknemer ID")]
        public int werknemer_ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Begindatum")]
        public DateTime begin_datum { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Einddatum")]
        public DateTime eind_datum { get; set; }
        [Display(Name = "Beschrijving")]
        public string beschrijving { get; set; }
        public Werknemer Werkenemer { get; set; }
        [Display(Name = "Reden")]
        public verlof_reden? verlof_reden { get; set; }
        public status? status { get; set; }

    }
}
