using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetMusteri
    {
        public PetMusteri()
        {
            PetHayvan = new HashSet<PetHayvan>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual ICollection<PetHayvan> PetHayvan { get; set; }
    }
}
