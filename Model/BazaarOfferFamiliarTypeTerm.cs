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
    
    public partial class BazaarOfferFamiliarTypeTerm
    {
        public long Id { get; set; }
        public long BazaarOfferId { get; set; }
        public long FamiliarTypeId { get; set; }
        public long Quantity { get; set; }
    
        public virtual FamiliarType FamiliarType { get; set; }
        public virtual BazaarOffer BazaarOffer { get; set; }
    }
}
