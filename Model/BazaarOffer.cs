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
    
    public partial class BazaarOffer
    {
        public BazaarOffer()
        {
            this.FamiliarTypeTerms = new HashSet<BazaarOfferFamiliarTypeTerm>();
            this.ItemTerms = new HashSet<BazaarOfferItemTerm>();
        }
    
        public long Id { get; set; }
        public string PlayerName { get; set; }
        public string Date { get; set; }
        public long OfferedFamiliarId { get; set; }
    
        public virtual ICollection<BazaarOfferFamiliarTypeTerm> FamiliarTypeTerms { get; set; }
        public virtual ICollection<BazaarOfferItemTerm> ItemTerms { get; set; }
        public virtual Familiar OfferedFamiliar { get; set; }
    }
}
