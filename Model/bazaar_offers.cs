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
    
    public partial class bazaar_offers
    {
        public bazaar_offers()
        {
            this.bazaar_offer_familiar_type_terms = new HashSet<bazaar_offer_familiar_type_terms>();
            this.bazaar_offer_item_terms = new HashSet<bazaar_offer_item_terms>();
        }
    
        public long id { get; set; }
        public string player_name { get; set; }
        public string date { get; set; }
        public long offered_familiar_id { get; set; }
    
        public virtual ICollection<bazaar_offer_familiar_type_terms> bazaar_offer_familiar_type_terms { get; set; }
        public virtual ICollection<bazaar_offer_item_terms> bazaar_offer_item_terms { get; set; }
        public virtual familiar familiar { get; set; }
    }
}