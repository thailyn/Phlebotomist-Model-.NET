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
    
    public partial class raid_boss_types
    {
        public raid_boss_types()
        {
            this.raid_boss_familiar_types = new HashSet<raid_boss_familiar_types>();
        }
    
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<raid_boss_familiar_types> raid_boss_familiar_types { get; set; }
    }
}