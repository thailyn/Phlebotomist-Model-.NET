﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhlebotomistModelContainer : DbContext
    {
        public PhlebotomistModelContainer()
            : base("name=PhlebotomistModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<attack_types> attack_types { get; set; }
        public DbSet<BazaarOfferFamiliarTypeTerm> BazaarOfferFamiliarTypeTerms { get; set; }
        public DbSet<bazaar_offer_item_terms> bazaar_offer_item_terms { get; set; }
        public DbSet<bazaar_offers> bazaar_offers { get; set; }
        public DbSet<brigade_familiars> brigade_familiars { get; set; }
        public DbSet<brigade_formation_horizontal_position_types> brigade_formation_horizontal_position_types { get; set; }
        public DbSet<brigade_formation_positions> brigade_formation_positions { get; set; }
        public DbSet<brigade_formation_vertical_position_types> brigade_formation_vertical_position_types { get; set; }
        public DbSet<brigade_formations> brigade_formations { get; set; }
        public DbSet<brigade> brigades { get; set; }
        public DbSet<event_elite_familiar_types> event_elite_familiar_types { get; set; }
        public DbSet<event_types> event_types { get; set; }
        public DbSet<@event> events { get; set; }
        public DbSet<familiar_skills> familiar_skills { get; set; }
        public DbSet<FamiliarTypeSkill> FamiliarTypeSkills { get; set; }
        public DbSet<FamiliarType> FamiliarTypes { get; set; }
        public DbSet<familiar> familiars { get; set; }
        public DbSet<growth> growths { get; set; }
        public DbSet<item_types> item_types { get; set; }
        public DbSet<item> items { get; set; }
        public DbSet<player> players { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<raid_boss_brigade_attacks> raid_boss_brigade_attacks { get; set; }
        public DbSet<raid_boss_familiar_types> raid_boss_familiar_types { get; set; }
        public DbSet<raid_boss_types> raid_boss_types { get; set; }
        public DbSet<raid_bosses> raid_bosses { get; set; }
        public DbSet<Rarity> Rarities1 { get; set; }
        public DbSet<skill_affected_stats> skill_affected_stats { get; set; }
        public DbSet<skill_patterns> skill_patterns { get; set; }
        public DbSet<skill_types> skill_types { get; set; }
        public DbSet<skill> skills { get; set; }
        public DbSet<stat> stats { get; set; }
    }
}
