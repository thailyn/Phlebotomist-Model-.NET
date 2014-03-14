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
    
    public partial class FamiliarType
    {
        public FamiliarType()
        {
            this.BazaarOfferTerms = new HashSet<BazaarOfferFamiliarTypeTerm>();
            this.EliteEvents = new HashSet<EventEliteFamiliarType>();
            this.Skills = new HashSet<FamiliarTypeSkill>();
            this.NextEvolutions = new HashSet<FamiliarType>();
            this.PreviousEvolutions = new HashSet<FamiliarType>();
            this.Familiars = new HashSet<Familiar>();
            this.RaidBosses = new HashSet<RaidBossFamiliarTypes>();
            this.familiar_type_stat_values = new HashSet<familiar_type_stat_values>();
        }
    
        public long Id { get; set; }
        public Nullable<long> BbId { get; set; }
        public string Name { get; set; }
        public long RarityId { get; set; }
        public short NumStars { get; set; }
        public short MaxStars { get; set; }
        public long GrowthId { get; set; }
        public long Worth { get; set; }
        public long RaceId { get; set; }
        public short Tradable { get; set; }
        public string LastWords { get; set; }
        public Nullable<long> PrevEvolutionId { get; set; }
        public Nullable<long> NextEvolutionId { get; set; }
    
        public virtual ICollection<BazaarOfferFamiliarTypeTerm> BazaarOfferTerms { get; set; }
        public virtual ICollection<EventEliteFamiliarType> EliteEvents { get; set; }
        public virtual ICollection<FamiliarTypeSkill> Skills { get; set; }
        public virtual ICollection<FamiliarType> NextEvolutions { get; set; }
        public virtual FamiliarType NextEvolution { get; set; }
        public virtual ICollection<FamiliarType> PreviousEvolutions { get; set; }
        public virtual FamiliarType PreviousEvolution { get; set; }
        public virtual Race Race { get; set; }
        public virtual Growth Growth { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<RaidBossFamiliarTypes> RaidBosses { get; set; }
        public virtual ICollection<familiar_type_stat_values> familiar_type_stat_values { get; set; }
    }
}
