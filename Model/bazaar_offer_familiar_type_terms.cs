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
    
    public partial class bazaar_offer_familiar_type_terms
    {
        public long id { get; set; }
        public long bazaar_offer_id { get; set; }
        public long familiar_type_id { get; set; }
        public long quantity { get; set; }
    
        public virtual FamiliarType familiar_types { get; set; }
        public virtual bazaar_offers bazaar_offers { get; set; }
    }
}
