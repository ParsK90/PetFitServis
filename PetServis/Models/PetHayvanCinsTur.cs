using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetHayvanCinsTur
    {
        public PetHayvanCinsTur()
        {
            PetHayvan = new HashSet<PetHayvan>();
        }

        public int Id { get; set; }
        public int? HayvanCinsId { get; set; }
        public string Aciklama { get; set; }
        public string EkAciklama { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual PetHayvanCins HayvanCins { get; set; }
        public virtual ICollection<PetHayvan> PetHayvan { get; set; }
    }
}
