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
    
    public partial class Rarity
    {
        public Rarity()
        {
            this.FamiliarTypes = new HashSet<FamiliarType>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public short Rank { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<FamiliarType> FamiliarTypes { get; set; }
    }
}
