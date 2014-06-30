//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Phlebotomist.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brigade
    {
        public Brigade()
        {
            this.Familiars = new HashSet<BrigadeFamiliars>();
            this.RaidBossAttacks = new HashSet<RaidBossBrigadeAttacks>();
            this.FamiliarTypes = new HashSet<BrigadeFamiliarType>();
        }
    
        public long Id { get; set; }
        public long BrigadeFormationId { get; set; }
        public Nullable<long> PlayerId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<BrigadeFamiliars> Familiars { get; set; }
        public virtual BrigadeFormation Formation { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<RaidBossBrigadeAttacks> RaidBossAttacks { get; set; }
        public virtual ICollection<BrigadeFamiliarType> FamiliarTypes { get; set; }
    }
}
