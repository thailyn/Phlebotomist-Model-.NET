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
    
    public partial class event_elite_familiar_types
    {
        public long id { get; set; }
        public long event_id { get; set; }
        public long familiar_type_id { get; set; }
        public double multiplier { get; set; }
    
        public virtual familiar_types familiar_types { get; set; }
        public virtual @event @event { get; set; }
    }
}
