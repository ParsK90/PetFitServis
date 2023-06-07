using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetBakim
    {
        public int Id { get; set; }
        public int? HayvanId { get; set; }
        public int? BakimTurId { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual PetBakimTur BakimTur { get; set; }
        public virtual PetHayvan Hayvan { get; set; }
    }
}
