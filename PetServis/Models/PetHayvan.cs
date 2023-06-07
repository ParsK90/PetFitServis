using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetHayvan
    {
        public PetHayvan()
        {
            PetAsiHareket = new HashSet<PetAsiHareket>();
            PetBakim = new HashSet<PetBakim>();
        }

        public int Id { get; set; }
        public int? SahipId { get; set; }
        public int? HayvanCinsTurId { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Chip { get; set; }
        public string Renk { get; set; }
        public double? Kilo { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual PetHayvanCinsTur HayvanCinsTur { get; set; }
        public virtual PetMusteri Sahip { get; set; }
        public virtual ICollection<PetAsiHareket> PetAsiHareket { get; set; }
        public virtual ICollection<PetBakim> PetBakim { get; set; }
    }
}
