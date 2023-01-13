using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoProfs.Models
{
    public class Functie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int afdeling_ID { get; set; }
        public string naam { get; set; }
        public Afdeling Afdeling { get; set; }

    }
}
