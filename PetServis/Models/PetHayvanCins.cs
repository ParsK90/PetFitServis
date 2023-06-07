using System;
using System.Collections.Generic;

namespace PetServis.Models
{
    public partial class PetHayvanCins
    {
        public PetHayvanCins()
        {
            PetHayvanCinsTur = new HashSet<PetHayvanCinsTur>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public short? Aktif { get; set; }

        public virtual ICollection<PetHayvanCinsTur> PetHayvanCinsTur { get; set; }
    }
}
