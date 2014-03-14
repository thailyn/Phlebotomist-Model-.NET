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
    
    public partial class Stat
    {
        public Stat()
        {
            this.AffectingSkills = new HashSet<SkillAffectedStat>();
            this.FoeDefensiveModifierSkills = new HashSet<Skill>();
            this.ModifierSkills = new HashSet<Skill>();
            this.familiar_type_stat_values = new HashSet<familiar_type_stat_values>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<SkillAffectedStat> AffectingSkills { get; set; }
        public virtual ICollection<Skill> FoeDefensiveModifierSkills { get; set; }
        public virtual ICollection<Skill> ModifierSkills { get; set; }
        public virtual ICollection<familiar_type_stat_values> familiar_type_stat_values { get; set; }
    }
}
