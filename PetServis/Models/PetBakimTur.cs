using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetBakimTur
    {
        public PetBakimTur()
        {
            PetBakim = new HashSet<PetBakim>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual ICollection<PetBakim> PetBakim { get; set; }
    }
}
