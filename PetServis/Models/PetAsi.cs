using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetAsi
    {
        public PetAsi()
        {
            PetAsiHareket = new HashSet<PetAsiHareket>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public double? Doz { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual ICollection<PetAsiHareket> PetAsiHareket { get; set; }
    }
}
