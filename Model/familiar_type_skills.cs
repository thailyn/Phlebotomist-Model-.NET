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
    
    public partial class familiar_type_skills
    {
        public long id { get; set; }
        public long familiar_type_id { get; set; }
        public long skill_id { get; set; }
    
        public virtual skill skill { get; set; }
        public virtual FamiliarType familiar_types { get; set; }
    }
}
