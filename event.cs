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
    
    public partial class @event
    {
        public @event()
        {
            this.event_elite_familiar_types = new HashSet<event_elite_familiar_types>();
            this.raid_boss_familiar_types = new HashSet<raid_boss_familiar_types>();
        }
    
        public long id { get; set; }
        public string name { get; set; }
        public long event_type_id { get; set; }
        public string date_started { get; set; }
        public string date_ended { get; set; }
    
        public virtual ICollection<event_elite_familiar_types> event_elite_familiar_types { get; set; }
        public virtual event_types event_types { get; set; }
        public virtual ICollection<raid_boss_familiar_types> raid_boss_familiar_types { get; set; }
    }
}
