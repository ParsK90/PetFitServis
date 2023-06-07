using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetAsiHareket
    {
        public int Id { get; set; }
        public int? HayvanId { get; set; }
        public int? AsiId { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual PetAsi Asi { get; set; }
        public virtual PetHayvan Hayvan { get; set; }
    }
}
